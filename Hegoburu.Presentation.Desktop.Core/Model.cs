using System;
using System.ComponentModel;
using System.Linq;
using FluentAop;
using Proxi;

namespace Hegoburu.Presentation.Desktop.Core
{
	public class Model<TItem> : IModel<TItem>
		where TItem : new()
	{
		#region INotifyPropertyChanged implementation
		public virtual event PropertyChangedEventHandler PropertyChanged;
		#endregion

		public virtual event DeletingEventHandler Deleting;

		TItem _item;

		public virtual TItem Item {
			get {
				return _item;
			}
			set {
				_item = value;
				HandleItemUpdated ();
				OnPropertyChanged ("Item");
			}
		}

		protected virtual Func<TItem, TItem, bool> IsSameItem { 
			get {
				return (i1, i2) => i1.Equals (i2);
			}
		}

		public Model ()
		{			
		}

		protected virtual void Initialize (TItem item)
		{
			Item = item;
		}

		internal static TModel Build<TModel> (TItem item)
			where TModel : Model<TItem>
		{
			var model = (TModel)Activator.CreateInstance (typeof(TModel));
			model.Initialize (item);

			var modelProxy = new Proxy<TModel> ()
				.Target (model)
				.InterceptAllSetters ()
					.OnInvoke (mi => {
				Console.WriteLine (mi.Method.Name + " Intercepted!" + mi.Arguments.First ());
				mi.Method.Invoke (mi.Target, mi.Arguments);
			}
			)
				.Save ();

			return modelProxy;
		}

		internal static TModel Build<TModel> ()
			where TModel : Model<TItem>
		{
			var item = new TItem ();
			return Build <TModel> (item);
		}

		internal virtual void HandleItemUpdated ()
		{
		}

		public virtual void OnPropertyChanged (string name)
		{
			if (PropertyChanged != null)
				PropertyChanged (this, new PropertyChangedEventArgs (name));
		}

		public virtual bool IsSameAs (Model<TItem> model)
		{
			var isSameModelType = model.GetType () == this.GetType () || model.GetType ().BaseType == this.GetType ();
			var isSameItem = IsSameItem (this.Item, model.Item);

			return isSameModelType && isSameItem;
		}

		public virtual bool IsSameAs<TModel> (TItem item)
			where TModel : Model<TItem>
		{
			var isSameModelType = typeof(TModel) == this.GetType () || typeof(TModel) == this.GetType ().BaseType;
			var isSameItem = IsSameItem (this.Item, item);

			return isSameModelType && isSameItem;
		}

		public virtual bool IsSameAs<TModel, TItem> ()
			where TModel : Model<TItem>
			where TItem : new()
		{
			var isSameModelType = typeof(TModel) == this.GetType () || typeof(TModel) == this.GetType ().BaseType;
			var isSameItem = typeof(TItem) == this.Item.GetType ();

			return isSameModelType && isSameItem;
		}

		public virtual bool IsInUse ()
		{
			return 
				PropertyChanged != null 
				&& PropertyChanged.GetInvocationList ().Any ();
		}

		public virtual void Delete ()
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

