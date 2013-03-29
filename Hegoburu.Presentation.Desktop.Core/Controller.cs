using System;

namespace Hegoburu.Presentation.Desktop.Core
{
	public class Controller<TView, TModel, TItem, TController>
		where TModel : Model<TItem>
		where TController : Controller<TView, TModel, TItem, TController>
		where TView : IView<TModel, TItem, TController, TView>
	{
		public TModel Model { get; protected set; }
		public TView View { get; protected set; } 

		public Controller (TView view, TModel model)
		{
			View = view;
			Model = model;
		}
	}
}

