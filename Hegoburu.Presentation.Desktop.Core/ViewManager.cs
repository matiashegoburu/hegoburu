using System;
using System.Collections.Generic;
using System.Linq;

namespace Hegoburu.Presentation.Desktop.Core
{
    public class ViewManager : IViewManager
    {
        protected static IViewManager _instance;
        public static IViewManager Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new ViewManager();

                return _instance;
            }
        }

        private List<object> TrackedViews { get; set; }

        public ViewManager()
        {
            TrackedViews = new List<object>(); 
        }

        public TView Get<TModel, TItem, TController, TView>(TItem item)
			where TModel : Model<TItem>
			where TController : Controller<TView, TModel, TItem, TController>
			where TView: IView<TModel, TItem, TController, TView>
			where TItem : new()
        {
            var trackedItem = TrackedViews
				.OfType<TView>()
				.SingleOrDefault(v => v.Model.IsSameAs<TModel>(item));

            if (null == trackedItem)
            {
                var model = Model<TItem>.Build<TModel>(item);
                trackedItem = (TView)Activator.CreateInstance(typeof(TView), model);
                Track<TModel, TItem, TController, TView>(trackedItem);
            }

            return trackedItem;
        }

        public TView Get<TModel, TItem, TController, TView>(TModel model)
			where TModel : Model<TItem>
			where TController : Controller<TView, TModel, TItem, TController>
			where TView: IView<TModel, TItem, TController, TView>
			where TItem : new()
        {
            var trackedItem = TrackedViews
				.OfType<TView>()
				.SingleOrDefault(v => v.Model.IsSameAs(model));

            if (null == trackedItem)
            {
                trackedItem = (TView)Activator.CreateInstance(typeof(TView), model);
                Track<TModel, TItem, TController, TView>(trackedItem);
            }

            return trackedItem;
        }

        public void Track<TModel, TItem, TController, TView>(TView view)
			where TModel : Model<TItem>
			where TController : Controller<TView, TModel, TItem, TController>
			where TView: IView<TModel, TItem, TController, TView>
			where TItem : new()
        {
            if (TrackedViews.OfType<TView>().Any(v => v.Model.IsSameAs(view.Model)))
                return;

            TrackedViews.Add(view);
        }

        public void Untrack<TModel, TItem, TController, TView>(TView view)
			where TModel : Model<TItem>
			where TController : Controller<TView, TModel, TItem, TController>
			where TView: IView<TModel, TItem, TController, TView>
			where TItem : new()
        {
            var itemToRemove = TrackedViews
				.OfType<TView>()
				.SingleOrDefault(v => v.Model.IsSameAs(view.Model));

            if (null == itemToRemove)
                return;

            TrackedViews.Remove(itemToRemove);
        }
    }
}