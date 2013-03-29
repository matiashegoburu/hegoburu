using System;
using Hegoburu.Presentation.Desktop.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models
{
	public class PersonaListModel : Model<List<PersonaEntity>>
	{
		public PersonaListModel (List<PersonaEntity> item) 
			: base(item, (i1, i2) => true)
		{
			Personas = new ModelList<PersonaModel, PersonaEntity> (item);
		}

		public ModelList<PersonaModel, PersonaEntity> Personas { get; set; } 

		public override void Dispose ()
		{
			base.Dispose ();
			Personas.Dispose ();
		}
	}
}

