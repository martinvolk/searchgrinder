using System;
using Gtk;
using System.Windows;

namespace PromoterTool
{
	class MainClass
	{
		public static MainWindow MainWindow;
		public static void Main (string[] args)
		{
			try{
				Application.Init ();
				MainClass.MainWindow = new MainWindow ();
				MainClass.MainWindow.Show ();
				Application.Run ();
			}
			catch(Exception e){
				Gtk.MessageDialog dlg = new Gtk.MessageDialog(null, Gtk.DialogFlags.Modal, Gtk.MessageType.Info, Gtk.ButtonsType.Ok, 
				                "Error: "+e.Message                               );
				dlg.Run();
				dlg.Destroy();
				Console.WriteLine(e.Message);
			}
		}
	}
}

