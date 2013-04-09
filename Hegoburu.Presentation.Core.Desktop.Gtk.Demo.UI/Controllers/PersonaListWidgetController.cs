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
	public class EditarEventArgs : EventArgs
	{
		public int Id { get; set; }
	}

	public class PersonaListWidgetController 
		: Controller<PersonaListWidgetView, PersonaListModel, List<PersonaEntity>, PersonaListWidgetController>
	{
		public event EventHandler<EventArgs> AgregarClicked;

		public event EventHandler<EditarEventArgs> EditarClicked;

		private PersonaRepository _personaRepository;

		public PersonaListWidgetController (PersonaListWidgetView view, PersonaListModel model) 
			: base(view, model)
		{
			_personaRepository = new PersonaRepository ();
			model.Personas.ItemChanged += HandleItemChanged;
		}

		void HandleItemChanged (object sender, ItemChangedEventArgs e)
		{
			Refrescar ();
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

		public void Editar ()
		{
			var ivwPersonas = View.AllChildren.OfType<global::Gtk.VPaned> ().First ().Child1 as global::Gtk.IconView;
			var path = ivwPersonas.SelectedItems.First ();
			var store = ivwPersonas.Model as  global::Gtk.ListStore;

			global::Gtk.TreeIter iter;
			store.GetIter (out iter, path);
			var id = (int)store.GetValue (iter, 0);
			if (EditarClicked != null)
				EditarClicked (this, new EditarEventArgs{Id = id});
		}

		public void Refrescar ()
		{
//			Model.Personas.Clear ();
//			var personas = _personaRepository.Get ();
//			personas.ForEach (p => Model.Personas.Add (ModelManager.GetInstance ().Get<PersonaModel, PersonaEntity> (p)));

			Cargar ();

		}
	}
}

