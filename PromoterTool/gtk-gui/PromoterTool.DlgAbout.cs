
// This file has been generated by the GUI designer. Do not modify.
namespace PromoterTool
{
	public partial class DlgAbout
	{
		private global::Gtk.Label label10;
		private global::Gtk.Label label6;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PromoterTool.DlgAbout
			this.Name = "PromoterTool.DlgAbout";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child PromoterTool.DlgAbout.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Red Blue Web Software</b>\n");
			this.label10.UseMarkup = true;
			w1.Add (this.label10);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(w1 [this.label10]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("This toolkit was designed to help you with finding\nright information for your marketing campaigns online. \n\nIf you need any custom features \nor would like to ask a question, visit: \n<a href=\"http://redbluewebsites.com\">http://redbluewebsites.com</a>\n\nMartin\n\n<a href=\"https://plus.google.com/u/0/109211047415515630423\">Connect with me on google+</a>");
			this.label6.UseMarkup = true;
			this.label6.Justify = ((global::Gtk.Justification)(2));
			w1.Add (this.label6);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(w1 [this.label6]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Internal child PromoterTool.DlgAbout.ActionArea
			global::Gtk.HButtonBox w4 = this.ActionArea;
			w4.Name = "dialog1_ActionArea";
			w4.Spacing = 10;
			w4.BorderWidth = ((uint)(5));
			w4.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w5 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w4 [this.buttonCancel]));
			w5.Expand = false;
			w5.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w6 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w4 [this.buttonOk]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 388;
			this.DefaultHeight = 264;
			this.Show ();
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelQuit);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}