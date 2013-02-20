
// This file has been generated by the GUI designer. Do not modify.
namespace PromoterTool
{
	public partial class TwitterWidget
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox5;
		private global::Gtk.Label label1;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Entry mSearchEntry;
		private global::Gtk.Button mButtonSearch;
		private global::Gtk.HBox hbox6;
		private global::Gtk.VBox vbox3;
		private global::Gtk.Label label2;
		private global::Gtk.Entry entry2;
		private global::Gtk.Label label5;
		private global::Gtk.Entry entry4;
		private global::Gtk.VBox vbox4;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment;
		private global::Gtk.VBox vbox5;
		private global::Gtk.CheckButton mRecommend;
		private global::Gtk.CheckButton mHelp;
		private global::Gtk.CheckButton checkbutton5;
		private global::Gtk.CheckButton checkbutton7;
		private global::Gtk.CheckButton checkbutton8;
		private global::Gtk.Label GtkLabel6;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView mSearchResults;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PromoterTool.TwitterWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "PromoterTool.TwitterWidget";
			// Container child PromoterTool.TwitterWidget.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(6));
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Search Twitter:");
			this.hbox5.Add (this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			this.vbox2.Add (this.hbox5);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox5]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.mSearchEntry = new global::Gtk.Entry ();
			this.mSearchEntry.CanFocus = true;
			this.mSearchEntry.Name = "mSearchEntry";
			this.mSearchEntry.IsEditable = true;
			this.mSearchEntry.InvisibleChar = '•';
			this.hbox4.Add (this.mSearchEntry);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.mSearchEntry]));
			w3.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.mButtonSearch = new global::Gtk.Button ();
			this.mButtonSearch.WidthRequest = 150;
			this.mButtonSearch.CanFocus = true;
			this.mButtonSearch.Name = "mButtonSearch";
			this.mButtonSearch.UseUnderline = true;
			this.mButtonSearch.Label = global::Mono.Unix.Catalog.GetString ("Search Twitter");
			this.hbox4.Add (this.mButtonSearch);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.mButtonSearch]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add (this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox4]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Min Followers:");
			this.vbox3.Add (this.label2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label2]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.entry2 = new global::Gtk.Entry ();
			this.entry2.CanFocus = true;
			this.entry2.Name = "entry2";
			this.entry2.Text = global::Mono.Unix.Catalog.GetString ("1111");
			this.entry2.IsEditable = true;
			this.entry2.InvisibleChar = '•';
			this.vbox3.Add (this.entry2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.entry2]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Max Following:");
			this.vbox3.Add (this.label5);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label5]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.entry4 = new global::Gtk.Entry ();
			this.entry4.CanFocus = true;
			this.entry4.Name = "entry4";
			this.entry4.Text = global::Mono.Unix.Catalog.GetString ("1000");
			this.entry4.IsEditable = true;
			this.entry4.InvisibleChar = '•';
			this.vbox3.Add (this.entry4);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.entry4]));
			w9.Position = 3;
			w9.Expand = false;
			w9.Fill = false;
			this.hbox6.Add (this.vbox3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.vbox3]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.mRecommend = new global::Gtk.CheckButton ();
			this.mRecommend.CanFocus = true;
			this.mRecommend.Name = "mRecommend";
			this.mRecommend.Label = global::Mono.Unix.Catalog.GetString ("Looking for recommendation");
			this.mRecommend.Active = true;
			this.mRecommend.DrawIndicator = true;
			this.mRecommend.UseUnderline = true;
			this.vbox5.Add (this.mRecommend);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.mRecommend]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.mHelp = new global::Gtk.CheckButton ();
			this.mHelp.CanFocus = true;
			this.mHelp.Name = "mHelp";
			this.mHelp.Label = global::Mono.Unix.Catalog.GetString ("Looking for help");
			this.mHelp.Active = true;
			this.mHelp.DrawIndicator = true;
			this.mHelp.UseUnderline = true;
			this.vbox5.Add (this.mHelp);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.mHelp]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.checkbutton5 = new global::Gtk.CheckButton ();
			this.checkbutton5.CanFocus = true;
			this.checkbutton5.Name = "checkbutton5";
			this.checkbutton5.Label = global::Mono.Unix.Catalog.GetString ("Looking for solution");
			this.checkbutton5.Active = true;
			this.checkbutton5.DrawIndicator = true;
			this.checkbutton5.UseUnderline = true;
			this.vbox5.Add (this.checkbutton5);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.checkbutton5]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.checkbutton7 = new global::Gtk.CheckButton ();
			this.checkbutton7.CanFocus = true;
			this.checkbutton7.Name = "checkbutton7";
			this.checkbutton7.Label = global::Mono.Unix.Catalog.GetString ("Looking for employees");
			this.checkbutton7.Active = true;
			this.checkbutton7.DrawIndicator = true;
			this.checkbutton7.UseUnderline = true;
			this.vbox5.Add (this.checkbutton7);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.checkbutton7]));
			w14.Position = 3;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.checkbutton8 = new global::Gtk.CheckButton ();
			this.checkbutton8.CanFocus = true;
			this.checkbutton8.Name = "checkbutton8";
			this.checkbutton8.Label = global::Mono.Unix.Catalog.GetString ("Looking for work");
			this.checkbutton8.Active = true;
			this.checkbutton8.DrawIndicator = true;
			this.checkbutton8.UseUnderline = true;
			this.vbox5.Add (this.checkbutton8);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.checkbutton8]));
			w15.Position = 4;
			w15.Expand = false;
			w15.Fill = false;
			this.GtkAlignment.Add (this.vbox5);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel6 = new global::Gtk.Label ();
			this.GtkLabel6.Name = "GtkLabel6";
			this.GtkLabel6.LabelProp = global::Mono.Unix.Catalog.GetString ("Find prospects..");
			this.GtkLabel6.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel6;
			this.vbox4.Add (this.frame1);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.frame1]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			this.hbox6.Add (this.vbox4);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.vbox4]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			this.vbox2.Add (this.hbox6);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox6]));
			w20.Position = 2;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.mSearchResults = new global::Gtk.TreeView ();
			this.mSearchResults.CanFocus = true;
			this.mSearchResults.Name = "mSearchResults";
			this.GtkScrolledWindow.Add (this.mSearchResults);
			this.vbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
			w22.Position = 3;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.mButtonSearch.Clicked += new global::System.EventHandler (this.onTwitterSearch);
		}
	}
}
