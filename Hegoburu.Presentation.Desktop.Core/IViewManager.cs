using System;

namespace Hegoburu.Presentation.Desktop.Core
{
    public interface IViewManager
    {
        TView Get<TModel, TItem, TController, TView>(TItem item)
            where TModel : Model<TItem>
            where TController : Controller<TView, TModel, TItem, TController>
            where TView: IView<TModel, TItem, TController, TView>
            where TItem : new();

        TView Get<TModel, TItem, TController, TView>(TModel model)
            where TModel : Model<TItem>
            where TController : Controller<TView, TModel, TItem, TController>
            where TView: IView<TModel, TItem, TController, TView>
                where TItem : new();

        void Track<TModel, TItem, TController, TView>(TView view)
            where TModel : Model<TItem>
            where TController : Controller<TView, TModel, TItem, TController>
            where TView: IView<TModel, TItem, TController, TView>
                where TItem : new();

        void Untrack<TModel, TItem, TController, TView>(TView view)
            where TModel : Model<TItem>
            where TController : Controller<TView, TModel, TItem, TController>
            where TView: IView<TModel, TItem, TController, TView>
                where TItem : new();
    }
}

