using System;
using Gtk;
using Hegoburu.Presentation.Desktop.Core;
using System.Collections.ObjectModel;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Controllers;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		var mainModel = ModelManager.GetInstance ().Get<MainModel, object> ();
		var mainWidgetView = ViewManager.GetInstance ().Get<MainModel, object, MainWidgetController, MainWidgetView> (mainModel);
		this.fixed3.Add (mainWidgetView);
		this.ShowAll ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
