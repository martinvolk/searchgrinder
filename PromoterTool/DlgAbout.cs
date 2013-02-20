using System;
namespace PromoterTool
{
	public partial class DlgAbout : Gtk.Dialog
	{
		
		
		
		public DlgAbout ()
		{
			this.Build ();
			
		}
		
		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Destroy();
		}
		protected virtual void OnButtonCancelQuit (object sender, System.EventArgs e)
		{
			Destroy();
		}
		
		
	}
}

