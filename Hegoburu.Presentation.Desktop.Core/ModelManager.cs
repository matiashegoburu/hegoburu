using System;
using System.Linq;
using System.Collections.Generic;

namespace Hegoburu.Presentation.Desktop.Core
{
    public class ModelManager : IModelManager
    {
        protected static IModelManager _instance;
        public static IModelManager Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new ModelManager();

                return _instance;
            }
        }

        private List<object> TrackedModels { get; set; }

        public ModelManager()
        {
            TrackedModels = new List<object>(); 
        }

        public TModel Get<TModel, TItem>(TItem item)
			where TModel : Model<TItem>
			where TItem : new()
        {
            var trackedItem = TrackedModels
				.OfType<TModel>()
				.SingleOrDefault(m => m.IsSameAs<TModel>(item));

            if (null == trackedItem)
            {
                trackedItem = Model<TItem>.Build<TModel>(item);
                Track<TModel, TItem>(trackedItem);
            }

            return trackedItem;
        }

        public TModel Get<TModel, TItem>()
			where TModel : Model<TItem>
			where TItem : new()
        {
            var trackedItem = TrackedModels
				.OfType<TModel>()
				.SingleOrDefault(m => m.IsSameAs<TModel,TItem>());

            if (null == trackedItem)
            {
                trackedItem = Model<TItem>.Build<TModel>();
                Track<TModel, TItem>(trackedItem);
            }

            return trackedItem;
        }

        public void Track<TModel, TItem>(TModel model)
			where TModel : Model<TItem>
			where TItem : new()
        {
            if (TrackedModels.OfType<TModel>().Any(m => m.IsSameAs(model)))
                return;

            TrackedModels.Add(model);
        }

        public void Untrack<TModel, TItem>(TModel model)
			where TModel : Model<TItem>
			where TItem : new()
        {
            var itemToRemove = TrackedModels
				.OfType<TModel>()
				.SingleOrDefault(m => m.IsSameAs(model));

            if (null == itemToRemove)
                return;

            TrackedModels.Remove(itemToRemove);
        }
    }
}

