using System;
using Gtk;
using Hegoburu.Presentation.Desktop.Core;

public class BaseGtkWindow<TModel, TItem, TController, TView>
	: Gtk.Window
	, IView<TModel, TItem, TController, TView>
	where TModel : Model<TItem>
	where TView : BaseGtkWindow<TModel, TItem, TController, TView>
	where TController : Controller<TView, TModel, TItem, TController>
	where TItem : new()
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

    public BaseGtkWindow(TModel model): base (Gtk.WindowType.Toplevel)
    {
        Model = model;
        Controller = InitializeController();
    }

    public override void Dispose()
    {
        UnbindModel();
        Model.Dispose();

        ViewManager
			.Instance
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

    protected virtual void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
