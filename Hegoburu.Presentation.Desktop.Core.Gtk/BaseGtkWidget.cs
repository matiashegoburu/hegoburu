using System;
using Hegoburu.Presentation.Desktop.Core;
using Gtk;
using System.ComponentModel;

[System.ComponentModel.ToolboxItem(true)]
public partial class BaseGtkWidget<TModel, TItem, TController, TView> 
	: Gtk.Bin
	, IView<TModel, TItem, TController, TView>
	where TItem : new()
	where TModel : Model<TItem>
	where TView : BaseGtkWidget<TModel, TItem, TController, TView>
	where TController : Controller<TView, TModel, TItem, TController>
{
	#region IView implementation
    TModel model;

    public TModel Model
    {
        get
        {
            return model;
        }
        protected set
        {
            var isNewModel = value != model;

            if (null != model && isNewModel)
                UnbindModel();

            model = value;

            if (Realized)
                ModelChanged();

            if (null != model && isNewModel)
                BindModel();
        }
    }

    public TController Controller { get; protected set; }
	#endregion

    protected bool Realized { get; private set; }

    public BaseGtkWidget(TModel model)
    {
        Model = model;
        Controller = InitializeController();
    }

    public override void Dispose()
    {
        UnbindModel();
        Model.Dispose();

        ViewManager
			.GetInstance()
			.Untrack<TModel, TItem, TController, TView>((TView)this);

        base.Dispose();
    }

    protected virtual TController InitializeController()
    {
        return (TController)Activator.CreateInstance(typeof(TController), this, Model);
    }

    protected virtual void BindModel()
    {
        Model.PropertyChanged += HandlePropertyChanged;
        Model.Deleting += HandleModelDeleting;
    }

    protected virtual void UnbindModel()
    {
        Model.PropertyChanged -= HandlePropertyChanged;
        Model.Deleting -= HandleModelDeleting;
    }

    protected virtual void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    protected virtual void HandleModelDeleting(object sender, EventArgs e)
    {
        Destroy();
    }

    protected virtual void ModelChanged()
    {
        throw new NotImplementedException();
    }

    protected virtual void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Dispose();
    }

    protected override void OnDestroyed()
    {
        base.OnDestroyed();
        Dispose();
    }

    protected override void OnRealized()
    {
        base.OnRealized();
        Realized = true;
        ModelChanged();
    }
}


