using System;
using System.Collections.Generic;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities
{
	public class PersonaEntity
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public int DNI { get; set; }
		public List<TelefonoEntity> Telefonos { get; set; }

		public PersonaEntity ()
		{
			Telefonos = new List<TelefonoEntity> ();
		}
	}
}

