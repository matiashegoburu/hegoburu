using System;
using System.Collections.Generic;
using Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Entities;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.DAL.Repository
{
	public class PersonaRepository
	{
		private static List<PersonaEntity> Personas { get; set; }

		public PersonaRepository ()
		{
			if (Personas == null)
				Personas = new List<PersonaEntity> ();
		}

		public List<PersonaEntity> Get ()
		{
			return Personas;
		}

		public void Save (PersonaEntity persona)
		{
			if (Personas.Contains (persona))
				return;

			Personas.Add (persona);
		}

		public void Delete (PersonaEntity persona)
		{
			Personas.Remove (persona);
		}
	}
}

