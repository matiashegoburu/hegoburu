using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Hegoburu.Presentation.Desktop.Core
{
	public class ItemChangedEventArgs : EventArgs
	{

		public ItemChangedEventArgs (object item, string propertyName)
		{
			Item = item;
			PropertyName = propertyName;
		}

		public object Item { get; private set; }
		public string PropertyName { get; private set; }
	}

	public class ModelList<TModel, TItem> 
		: ObservableCollection<TModel>
		, IDisposable
		where TModel : Model<TItem>
		where TItem : new()
	{
		protected List<TItem> Source{ get; set; }

		public event EventHandler<ItemChangedEventArgs> ItemChanged;

		public ModelList (List<TItem> source)
		{
			Source = source; 

			foreach (var item in source) {
				var itemModel = ModelManager.GetInstance ().Get<TModel, TItem> (item);
				itemModel.PropertyChanged += HandlePropertyChanged;
				Add (itemModel);
			}
		}

		void HandlePropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (ItemChanged != null)
				ItemChanged (this, new ItemChangedEventArgs (sender, e.PropertyName));
		}

		protected override void OnCollectionChanged (NotifyCollectionChangedEventArgs e)
		{
			base.OnCollectionChanged (e);

			switch (e.Action) {
			case NotifyCollectionChangedAction.Add:
				foreach (TModel itemModel in e.NewItems) {
					itemModel.PropertyChanged += HandlePropertyChanged;
					Source.Add (itemModel.Item);
				}
				break;

			case NotifyCollectionChangedAction.Remove:
				foreach (TModel itemModel in e.OldItems) {
					itemModel.PropertyChanged -= HandlePropertyChanged;
					Source.Remove (itemModel.Item);
				}

				break;

			case NotifyCollectionChangedAction.Reset:
				foreach (var model in this)
					model.PropertyChanged -= HandlePropertyChanged;

				Source.Clear ();

				break;
			
			case NotifyCollectionChangedAction.Replace:
				throw new NotImplementedException ();
			//Source [e.OldStartingIndex] = e.NewItems.First ();
			//break;
			}
		}

		#region IDisposable implementation
		public void Dispose ()
		{
			foreach (var model in this) {
				model.PropertyChanged -= HandlePropertyChanged;
				model.Dispose ();
			}
		}
		#endregion

	}
}

