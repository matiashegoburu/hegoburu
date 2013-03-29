using System;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Controllers;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class PersonaListWidgetView 
		: BaseGtkWidget<PersonaListModel, List<PersonaEntity>, PersonaListWidgetController, PersonaListWidgetView>
	{
		public PersonaListWidgetView (PersonaListModel model) : base(model)
		{
			this.Build ();
		}

		protected override PersonaListWidgetController InitializeController ()
		{
			return new PersonaListWidgetController (this, Model);
		}

		protected override void BindModel ()
		{
			base.BindModel ();
			Model.Personas.CollectionChanged += HandleCollectionChanged;
		}

		protected override void UnbindModel ()
		{
			base.UnbindModel ();
			Model.Personas.CollectionChanged -= HandleCollectionChanged;
		}

		void HandleCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			var list = ivwPersonas.Model as global::Gtk.ListStore;

			switch (e.Action) {
			case NotifyCollectionChangedAction.Add:
				foreach (PersonaModel item in e.NewItems)
					list.AppendValues (item.DNI, string.Format ("{0} {1}", item.Nombre, item.Apellido));
				break;
			
			case NotifyCollectionChangedAction.Reset:
				list.Clear ();
				break;
			}
		}

		protected override void ModelChanged ()
		{
			Controller.Cargar ();
		}

		protected void OnBtnAgregarClicked (object sender, EventArgs e)
		{
			Controller.Agregar ();
		}
	}
}
