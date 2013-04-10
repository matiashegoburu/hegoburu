using System;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using Hegoburu.Presentation.Desktop.Core;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models
{
	public class TelefonoModel : Model<TelefonoEntity>
	{
		public TelefonoModel ()
		{
		}

		protected override Func<TelefonoEntity, TelefonoEntity, bool> IsSameItem {
			get {
				return (t1, t2) => t1.ToString () == t2.ToString ();
			}
		}

		public virtual int Pais { get; set; }

		public virtual int Area { get; set; }

		public virtual int Numero{ get; set; }
	}
}

