
// This file has been generated by the GUI designer. Do not modify.
namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona
{
	public partial class PersonaEditorWidgetView
	{
		private global::Gtk.Fixed fixed1;
		private global::Gtk.Label lblDNI;
		private global::Gtk.Label lblApellido;
		private global::Gtk.Entry txtDNI;
		private global::Gtk.Label lblNombre;
		private global::Gtk.Entry txtNombre;
		private global::Gtk.Entry txtApellido;
		private global::Gtk.Button btnOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona.PersonaEditorWidgetView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona.PersonaEditorWidgetView";
			// Container child Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Views.Persona.PersonaEditorWidgetView.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.lblDNI = new global::Gtk.Label ();
			this.lblDNI.Name = "lblDNI";
			this.lblDNI.LabelProp = global::Mono.Unix.Catalog.GetString ("DNI:");
			this.fixed1.Add (this.lblDNI);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.lblDNI]));
			w1.X = 20;
			w1.Y = 24;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.lblApellido = new global::Gtk.Label ();
			this.lblApellido.Name = "lblApellido";
			this.lblApellido.LabelProp = global::Mono.Unix.Catalog.GetString ("Apellido:");
			this.fixed1.Add (this.lblApellido);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.lblApellido]));
			w2.X = 19;
			w2.Y = 85;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.txtDNI = new global::Gtk.Entry ();
			this.txtDNI.CanFocus = true;
			this.txtDNI.Name = "txtDNI";
			this.txtDNI.IsEditable = true;
			this.txtDNI.InvisibleChar = '•';
			this.fixed1.Add (this.txtDNI);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.txtDNI]));
			w3.X = 121;
			w3.Y = 17;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.lblNombre = new global::Gtk.Label ();
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.LabelProp = global::Mono.Unix.Catalog.GetString ("Nombre:");
			this.fixed1.Add (this.lblNombre);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.lblNombre]));
			w4.X = 19;
			w4.Y = 56;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.txtNombre = new global::Gtk.Entry ();
			this.txtNombre.CanFocus = true;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.IsEditable = true;
			this.txtNombre.InvisibleChar = '•';
			this.fixed1.Add (this.txtNombre);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.txtNombre]));
			w5.X = 121;
			w5.Y = 50;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.txtApellido = new global::Gtk.Entry ();
			this.txtApellido.CanFocus = true;
			this.txtApellido.Name = "txtApellido";
			this.txtApellido.IsEditable = true;
			this.txtApellido.InvisibleChar = '•';
			this.fixed1.Add (this.txtApellido);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.txtApellido]));
			w6.X = 124;
			w6.Y = 85;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnOk = new global::Gtk.Button ();
			this.btnOk.CanFocus = true;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseUnderline = true;
			this.btnOk.Label = global::Mono.Unix.Catalog.GetString ("Ok");
			this.fixed1.Add (this.btnOk);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.btnOk]));
			w7.X = 245;
			w7.Y = 243;
			this.Add (this.fixed1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.txtDNI.EditingDone += new global::System.EventHandler (this.OnTxtDNIEditingDone);
			this.txtNombre.EditingDone += new global::System.EventHandler (this.OnTxtNombreEditingDone);
			this.txtApellido.EditingDone += new global::System.EventHandler (this.OnTxtApellidoEditingDone);
			this.btnOk.Clicked += new global::System.EventHandler (this.OnBtnOkClicked);
		}
	}
}
