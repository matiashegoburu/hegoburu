using System;

namespace Hegoburu.Presentation.Desktop.Core
{
	public interface IView<TModel, TItem, TController, TView>
		: IDisposable
		where TModel : Model<TItem>
		where TView : IView<TModel, TItem, TController, TView>
		where TController: Controller<TView, TModel, TItem, TController>
		where TItem : new()
	{
		TModel Model { get; }
		TController Controller { get; }
	}
	
}
