using System;
using System.ComponentModel;

namespace Hegoburu.Presentation.Desktop.Core
{
	public interface IModel<TItem> 
		: INotifyPropertyChanged
		, IDisposable
	{
		#region INotifyPropertyChanged implementation
		event PropertyChangedEventHandler PropertyChanged;
		#endregion

		event DeletingEventHandler Deleting;

		TItem Item { get; set; }

		void OnPropertyChanged (string name);

		bool IsSameAs (Model<TItem> model);

		bool IsSameAs<TModel> (TItem item) where TModel : Model<TItem>;

		bool IsSameAs<TModel, TItem> ()
			where TModel : Model<TItem>
				where TItem : new();

		bool IsInUse ();

		void Delete ();
	}
}

