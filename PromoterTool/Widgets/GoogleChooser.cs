using System;
namespace PromoterTool
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GoogleChooser : Gtk.Bin
	{
		
		public GoogleChooser ()
		{
			this.Build ();
		}
		public string TopLevelDomain{
			get{
				return mGoogleLocale.ActiveText;
			}
			set{
				
			}
		}
	}
}

