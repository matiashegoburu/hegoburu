using System;
using System.Linq;
using System.Collections.Generic;

namespace Hegoburu.Presentation.Desktop.Core
{
	public class ModelManager
	{
		private static ModelManager ModelManagerInstance { get; set; }
		public static Func<ModelManager> GetInstance = 
			() =>
			{
				if (null == ModelManagerInstance)
					ModelManagerInstance = new ModelManager ();

				return ModelManagerInstance;
			};

		private List<object> TrackedModels { get; set; }

		public ModelManager ()
		{
			TrackedModels = new List<object> (); 
		}

		public TModel Get<TModel, TItem> (TItem item)
			where TModel : Model<TItem>
		{
			var trackedItem = TrackedModels
				.OfType<TModel> ()
				.SingleOrDefault (m => m.IsSameAs<TModel> (item));

			if (null == trackedItem) {
				trackedItem = Model<TItem>.Build<TModel> (item);
				Track<TModel, TItem> (trackedItem);
			}

			return trackedItem;
		}

		public TModel Get<TModel, TItem> ()
			where TModel : Model<TItem>
			where TItem : new()
		{
			var trackedItem = TrackedModels
				.OfType<TModel> ()
				.SingleOrDefault (m => m.IsSameAs<TModel,TItem> ());

			if (null == trackedItem) {
				trackedItem = Model<TItem>.Build<TModel, TItem> ();
				Track<TModel, TItem> (trackedItem);
			}

			return trackedItem;
		}

		public void Track<TModel, TItem> (TModel model)
			where TModel : Model<TItem>
		{
			if (TrackedModels.OfType<TModel> ().Any (m => m.IsSameAs (model)))
				return;

			TrackedModels.Add (model);
		}

		public void Untrack<TModel, TItem> (TModel model)
			where TModel : Model<TItem>
		{
			var itemToRemove = TrackedModels
				.OfType<TModel> ()
				.SingleOrDefault (m => m.Equals (model));

			if (null == itemToRemove)
				return;

			TrackedModels.Remove (itemToRemove);
		}
	}
}

