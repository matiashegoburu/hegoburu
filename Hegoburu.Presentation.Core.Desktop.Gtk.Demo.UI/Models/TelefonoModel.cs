using System;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using Hegoburu.Presentation.Desktop.Core;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models
{
	public class TelefonoModel : Model<TelefonoEntity>
	{
		public TelefonoModel (TelefonoEntity item) 
			: base(item, (t1, t2) => t1.ToString() == t2.ToString())
		{
		}

		public int Pais {
			get {
				return Item.Pais;
			}
			set {
				Item.Pais = value;
				OnPropertyChanged ("Pais");
			}
		}

		public int Area {
			get {
				return Item.Area;
			}
			set {
				Item.Area = value;
				OnPropertyChanged ("Area");
			}
		}

		public int Numero {
			get {
				return Item.Numero;
			}
			set {
				Item.Numero = value;
			}
		}
	}
}

