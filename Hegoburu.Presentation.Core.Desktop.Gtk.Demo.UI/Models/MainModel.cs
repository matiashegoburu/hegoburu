using System;
using Hegoburu.Presentation.Desktop.Core;

namespace Hegoburu.Presentation.Core.Desktop.Gtk.Demo.UI.Models
{
	public class MainModel 
		: Model<object>
	{
		public MainModel (object item) 
			: base(item, (i1, i2) => true)
		{
		}
	}
}

