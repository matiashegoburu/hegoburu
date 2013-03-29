using System;
using System.ComponentModel;
using System.Linq;

namespace Hegoburu.Presentation.Desktop.Core
{
	public class Model<TItem> 
		: INotifyPropertyChanged
		, IDisposable
	{
		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		public event DeletingEventHandler Deleting;

		TItem _item;

		public TItem Item {
			get {
				return _item;
			}
			set {
				_item = value;
				HandleItemUpdated ();
				OnPropertyChanged ("Item");
			}
		}

		protected Func<TItem, TItem, bool> _isSameItem;

		internal protected Model (TItem item) : this(item, (i1, i2) => i1.Equals(i2))
		{
		}

		internal protected Model (
			TItem item
			, Func<TItem, TItem, bool> isSameItem)
		{
			_item = item;
			_isSameItem = isSameItem;
		}

		internal static TModel Build<TModel> (TItem item)
			where TModel : Model<TItem>
		{
			return (TModel)Activator.CreateInstance (typeof(TModel), item);
		}

		internal static TModel Build<TModel, TItem> ()
			where TModel : Model<TItem>
			where TItem : new()
		{
			var item = new TItem ();
			return (TModel)Activator.CreateInstance (typeof(TModel), item);
		}

		protected virtual void HandleItemUpdated ()
		{
		}

		public void OnPropertyChanged (string name)
		{
			if (PropertyChanged != null)
				PropertyChanged (this, new PropertyChangedEventArgs (name));
		}

		public bool IsSameAs (Model<TItem> model)
		{
			var isSameModelType = model.GetType () == this.GetType ();
			var isSameItem = _isSameItem (this.Item, model.Item);

			return isSameModelType && isSameItem;
		}

		public bool IsSameAs<TModel> (TItem item)
			where TModel : Model<TItem>
		{
			var isSameModelType = typeof(TModel) == this.GetType ();
			var isSameItem = _isSameItem (this.Item, item);

			return isSameModelType && isSameItem;
		}

		public bool IsSameAs<TModel, TItem> ()
			where TModel : Model<TItem>
			where TItem : new()
		{
			var isSameModelType = typeof(TModel) == this.GetType ();
			var isSameItem = typeof(TItem) == this.Item.GetType ();

			return isSameModelType && isSameItem;
		}

		public bool IsInUse ()
		{
			return 
				PropertyChanged != null 
				&& PropertyChanged.GetInvocationList ().Any ();
		}

		public void Delete ()
		{
			ModelManager.GetInstance ().Untrack<Model<TItem>, TItem> (this);
			if (Deleting != null)
				Deleting (this, EventArgs.Empty);
		}

		#region IDisposable implementation
		public virtual void Dispose ()
		{
			if (PropertyChanged != null && PropertyChanged.GetInvocationList ().Any ())
				return;

			ModelManager.GetInstance ().Untrack<Model<TItem>, TItem> (this);

			if (Deleting != null)
				Deleting (this, EventArgs.Empty);
		}
		#endregion
	}
}

