using System;

namespace Hegoburu.Presentation.Desktop.Core
{
    public interface IModelManager
    {
        TModel Get<TModel, TItem>(TItem item)
            where TModel : Model<TItem>
                where TItem : new();

        TModel Get<TModel, TItem>()
            where TModel : Model<TItem>
                where TItem : new();

        void Track<TModel, TItem>(TModel model)
            where TModel : Model<TItem>
                where TItem : new();

        void Untrack<TModel, TItem>(TModel model)
            where TModel : Model<TItem>
                where TItem : new();
    }
}

