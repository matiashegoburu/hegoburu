using System;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using Hegoburu.Presentation.Desktop.Core;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Repository;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Controllers
{
	public class PersonaEditorWidgetController
		: Controller<PersonaEditorWidgetView, PersonaModel, PersonaEntity, PersonaEditorWidgetController>
	{
		private PersonaRepository _personaRepository;

		public event EventHandler<PersonaAgregadaEventArgs> PersonaAgregada;

		public PersonaEditorWidgetController (PersonaEditorWidgetView view, PersonaModel model) 
			: base(view, model)
		{
			_personaRepository = new PersonaRepository ();
		}

		public void Agregar ()
		{
			_personaRepository.Save (Model.Item);

			if (PersonaAgregada != null)
				PersonaAgregada (this, new PersonaAgregadaEventArgs (Model));
		}

		public class PersonaAgregadaEventArgs : EventArgs
		{
			public PersonaModel Persona { get; private set; }

			public PersonaAgregadaEventArgs (PersonaModel persona)
			{
				Persona = persona;
			}
		}
	}
}

