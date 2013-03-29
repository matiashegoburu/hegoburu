using System;
using System.Linq;
using Hegoburu.Presentation.Desktop.Core;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona;
using System.Collections.ObjectModel;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Repository;
using System.Collections.Generic;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Controllers
{
	public class PersonaListWidgetController 
		: Controller<PersonaListWidgetView, PersonaListModel, List<PersonaEntity>, PersonaListWidgetController>
	{
		public event EventHandler<EventArgs> AgregarClicked;

		private PersonaRepository _personaRepository;

		public PersonaListWidgetController (PersonaListWidgetView view, PersonaListModel model) 
			: base(view, model)
		{
			_personaRepository = new PersonaRepository ();
		}

		public void Agregar ()
		{
			if (AgregarClicked != null)
				AgregarClicked (this, EventArgs.Empty);
		}

		public void Cargar ()
		{
			var ivwPersonas = View.AllChildren.OfType<global::Gtk.VPaned> ().First ().Child1 as global::Gtk.IconView;
			var list = new global::Gtk.ListStore (typeof(int), typeof(string));
			foreach (var persona in Model.Item)
				list.AppendValues (persona.DNI, string.Format ("{0} {1}", persona.Nombre, persona.Apellido));
			ivwPersonas.Model = list;
			ivwPersonas.TextColumn = 1;
			ivwPersonas.SelectionMode = global::Gtk.SelectionMode.Single;
		}

		public void Refrescar ()
		{
			Model.Personas.Clear ();
			var personas = _personaRepository.Get ();
			personas.ForEach (p => Model.Personas.Add (ModelManager.GetInstance ().Get<PersonaModel, PersonaEntity> (p)));

			Cargar ();

		}
	}
}

