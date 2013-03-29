using System;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Controllers;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona
{
	using Persona = Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities.PersonaEntity;

	[System.ComponentModel.ToolboxItem(true)]
	public partial class PersonaEditorWidgetView 
		: BaseGtkWidget<PersonaModel, PersonaEntity, PersonaEditorWidgetController, PersonaEditorWidgetView>
	{
		public PersonaEditorWidgetView (PersonaModel model) : base(model)
		{
			this.Build ();
		}

		protected override void HandlePropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			txtDNI.Text = Model.DNI.ToString ();
			txtNombre.Text = Model.Nombre;
			txtApellido.Text = Model.Apellido;
		}

		protected void OnTxtDNIEditingDone (object sender, EventArgs e)
		{
			Model.DNI = int.Parse (txtDNI.Text);
		}

		protected void OnTxtNombreEditingDone (object sender, EventArgs e)
		{
			Model.Nombre = txtNombre.Text;
		}

		protected void OnTxtApellidoWidgetRemoved (object sender, EventArgs e)
		{
			Model.Apellido = txtApellido.Text;
		}

		protected override void ModelChanged ()
		{
			txtDNI.Text = Model.DNI.ToString ();
			txtNombre.Text = Model.Nombre;
			txtApellido.Text = Model.Apellido;
		}

		protected void OnBtnOkClicked (object sender, EventArgs e)
		{
			txtDNI.FinishEditing ();
			txtNombre.FinishEditing ();
			txtApellido.FinishEditing ();

			Controller.Agregar ();
		}
	}
}

