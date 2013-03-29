using System;
using Gtk;

namespace Hegoburu.PResentation.Core.Desktop.Gtk.Demo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
