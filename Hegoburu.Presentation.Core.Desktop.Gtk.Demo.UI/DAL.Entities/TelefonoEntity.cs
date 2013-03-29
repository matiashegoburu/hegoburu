using System;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities
{
	public class TelefonoEntity
	{
		public int Pais { get; set; }
		public int Area { get; set; }
		public int Numero { get; set; }

		public override string ToString ()
		{
			return string.Format ("+{0}-{1}-{2}", Pais, Area, Numero);
		}
	}
}

