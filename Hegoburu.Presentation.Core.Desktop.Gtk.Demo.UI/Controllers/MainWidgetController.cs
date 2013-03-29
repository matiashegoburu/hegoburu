using System;
using Hegoburu.Presentation.Desktop.Core;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models;
using System.Linq;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Controllers
{
	public class MainWidgetController
		: Controller<MainWidgetView, MainModel, object, MainWidgetController>
	{
		public MainWidgetController (MainWidgetView view, MainModel model) 
			: base(view, model)
		{
		}

		internal void HandleAgregarClicked (object sender, EventArgs e)
		{
			var hpaned1 = View.AllChildren.OfType<global::Gtk.HPaned> ().First ();
			if (hpaned1.Child2 != null) {
				var viewToRemove = hpaned1.Child2 as PersonaEditorWidgetView;
				hpaned1.Remove (viewToRemove);

				viewToRemove.Controller.PersonaAgregada -= HandlePersonaAgregada;
				viewToRemove.Destroy ();
			}

			var personaEditorModel = ModelManager.GetInstance ().Get<PersonaModel, PersonaEntity> ();
			var personaEditorView = ViewManager.GetInstance ().Get<PersonaModel, PersonaEntity, PersonaEditorWidgetController, PersonaEditorWidgetView> (personaEditorModel);
			personaEditorView.Controller.PersonaAgregada += HandlePersonaAgregada;

			hpaned1.Add2 (personaEditorView);
			hpaned1.ShowAll ();
		}

		void HandlePersonaAgregada (object sender, PersonaEditorWidgetController.PersonaAgregadaEventArgs e)
		{
			var personaListModel = ModelManager.GetInstance ().Get<PersonaListModel, List<PersonaEntity>> ();
			personaListModel.Personas.Add (e.Persona);
		}
	}
}

