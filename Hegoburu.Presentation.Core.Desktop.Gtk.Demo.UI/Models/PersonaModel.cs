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
		public PersonaModel ()
		{

		}

		protected override void Initialize (PersonaEntity item)
		{
			base.Initialize (item);
			Telefonos = new ModelList<TelefonoModel, TelefonoEntity> (item.Telefonos);
		}

		protected override Func<PersonaEntity, PersonaEntity, bool> IsSameItem {
			get {
				return (p1, p2) => p1.DNI == p2.DNI;
			}
		}

		public virtual int DNI { get; set; }

		public virtual string Nombre { get; set; }

		public virtual string Apellido { get; set; }

		ModelList<TelefonoModel, TelefonoEntity> _telefonos;
		public virtual ModelList<TelefonoModel, TelefonoEntity> Telefonos { get; set; }
	}
}

