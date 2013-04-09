using System;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Controllers;
using Hegoburu.Presentation.Desktop.Core;
using System.Collections.ObjectModel;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using System.Collections.Generic;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class MainWidgetView 
		: BaseGtkWidget<MainModel, object, MainWidgetController, MainWidgetView>
	{
		public MainWidgetView (MainModel model) 
			: base(model)
		{
			this.Build ();

			var personaListModel = ModelManager.GetInstance ().Get<PersonaListModel, List<PersonaEntity>> ();
			var personaListView = ViewManager.GetInstance ().Get<PersonaListModel, List<PersonaEntity>, PersonaListWidgetController, PersonaListWidgetView> (personaListModel);
			hpaned1.Add1 (personaListView);

			personaListView.Controller.AgregarClicked += Controller.HandleAgregarClicked;
			personaListView.Controller.EditarClicked += Controller.HandleEditarClicked;
		}

		protected override void HandlePropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{

		}

		protected override void ModelChanged ()
		{

		}
	}
}

