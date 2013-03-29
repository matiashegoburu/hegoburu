using System;
using Hegoburu.Presentation.Desktop.Core;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.Views.Persona;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.Models;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.DAL.Entities;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.Controllers
{
	public partial class PersonaListWidgetController : Controller<PersonaListWidgetView, PersonaModel, Persona, PersonaListWidgetController>
	{
		public PersonaListWidgetController (PersonaListWidgetView view, PersonaModel model) 
			: base(view, model)
		{
			this.Build ();
		}
	}
}

