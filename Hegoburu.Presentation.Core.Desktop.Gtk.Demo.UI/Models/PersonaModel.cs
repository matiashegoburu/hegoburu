using System;
using System.Linq;
using Hegoburu.Presentation.Desktop.Core;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models
{
	public class PersonaModel : Model<PersonaEntity>
	{
		public PersonaModel (PersonaEntity item) 
			: base(item, (p1, p2) => p1.DNI == p2.DNI)
		{
			Telefonos = new ModelList<TelefonoModel, TelefonoEntity> (item.Telefonos);
		}

		public int DNI {
			get {
				return Item.DNI;
			}
			set {
				Item.DNI = value;
				OnPropertyChanged ("DNI");
			}
		}

		public string Nombre {
			get {
				return Item.Nombre;
			}
			set {
				Item.Nombre = value;
				OnPropertyChanged ("Nombre");
			}
		}

		public string Apellido {
			get {
				return Item.Apellido;
			}
			set {
				Item.Apellido = value;
				OnPropertyChanged ("Apellido");
			}
		}

		ModelList<TelefonoModel, TelefonoEntity> _telefonos;
		public ModelList<TelefonoModel, TelefonoEntity> Telefonos {
			get {
				return _telefonos;
			}
			set {
				_telefonos = value;
				OnPropertyChanged ("Telefonos");
			}
		}
	}
}

