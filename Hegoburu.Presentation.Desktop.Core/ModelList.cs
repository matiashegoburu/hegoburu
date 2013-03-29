using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Hegoburu.Presentation.Desktop.Core
{
	public class ModelList<TModel, TItem> 
		: ObservableCollection<TModel>
		, IDisposable
		where TModel : Model<TItem>
	{
		protected List<TItem> Source{ get; set; }

		public ModelList (List<TItem> source)
		{
			Source = source; 

			foreach (var item in source) {
				var itemModel = ModelManager.GetInstance ().Get<TModel, TItem> (item);
				Add (itemModel);
			}
		}

		protected override void OnCollectionChanged (NotifyCollectionChangedEventArgs e)
		{
			base.OnCollectionChanged (e);

			switch (e.Action) {
			case NotifyCollectionChangedAction.Add:
				foreach (TModel itemModel in e.NewItems)
					Source.Add (itemModel.Item);
				break;

			case NotifyCollectionChangedAction.Remove:
				foreach (TModel itemModel in e.OldItems)
					Source.Remove (itemModel.Item);
				break;

			case NotifyCollectionChangedAction.Reset:
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
			foreach (var model in this)
				model.Dispose ();
		}
		#endregion

	}
}

