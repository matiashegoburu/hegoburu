using System;
using Hegoburu.Presentation.Desktop.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models
{
	public class PersonaListModel : Model<List<PersonaEntity>>
	{
		protected override void Initialize (List<PersonaEntity> item)
		{
			base.Initialize (item);
			Personas = new ModelList<PersonaModel, PersonaEntity> (item);
		}

		protected override Func<List<PersonaEntity>, List<PersonaEntity>, bool> IsSameItem {
			get {
				return (i1, i2) => true;
			}
		}

		public virtual ModelList<PersonaModel, PersonaEntity> Personas { get; set; } 

		public override void Dispose ()
		{
			base.Dispose ();
			Personas.Dispose ();
		}
	}
}

