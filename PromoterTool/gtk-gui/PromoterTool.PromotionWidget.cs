
// This file has been generated by the GUI designer. Do not modify.
namespace PromoterTool
{
	public partial class PromotionWidget
	{
		private global::Gtk.VBox vbox3;
		private global::Gtk.VBox vbox5;
		private global::Gtk.HBox hbox5;
		private global::Gtk.Label label3;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Entry mSearchTerm;
		private global::Gtk.Button mButtonSearch;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment;
		private global::Gtk.VBox vbox7;
		private global::Gtk.CheckButton mCheckWordpress;
		private global::Gtk.CheckButton mCheckHubpages;
		private global::Gtk.CheckButton mBlogEngine;
		private global::Gtk.CheckButton mExpressionEngine;
		private global::Gtk.CheckButton mCheckNormal;
		private global::Gtk.Label GtkLabel7;
		private global::Gtk.Frame frame2;
		private global::Gtk.Alignment GtkAlignment1;
		private global::Gtk.VBox vbox2;
		private global::Gtk.CheckButton mCheckPagerank;
		private global::Gtk.CheckButton mCommentLuv;
		private global::Gtk.CheckButton mKeywordLuv;
		private global::Gtk.CheckButton mTopCommenter;
		private global::Gtk.Label GtkLabel12;
		private global::Gtk.VBox vbox6;
		private global::Gtk.ProgressBar mSearchProgress;
		private global::PromoterTool.GoogleChooser mLocale;
		private global::Gtk.Label label4;
		private global::Gtk.HScale mMinPagerank;
		private global::Gtk.Label label5;
		private global::Gtk.HScale mSearchDepth;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label8;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView mSearchResults;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PromoterTool.PromotionWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "PromoterTool.PromotionWidget";
			// Container child PromoterTool.PromotionWidget.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			this.vbox3.BorderWidth = ((uint)(6));
			// Container child vbox3.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Search Term (anything you would type into google):");
			this.hbox5.Add (this.label3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.label3]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			this.vbox5.Add (this.hbox5);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox5]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.mSearchTerm = new global::Gtk.Entry ();
			this.mSearchTerm.CanFocus = true;
			this.mSearchTerm.Name = "mSearchTerm";
			this.mSearchTerm.IsEditable = true;
			this.mSearchTerm.InvisibleChar = '•';
			this.hbox4.Add (this.mSearchTerm);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.mSearchTerm]));
			w3.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.mButtonSearch = new global::Gtk.Button ();
			this.mButtonSearch.WidthRequest = 100;
			this.mButtonSearch.CanFocus = true;
			this.mButtonSearch.Name = "mButtonSearch";
			this.mButtonSearch.UseUnderline = true;
			this.mButtonSearch.Label = global::Mono.Unix.Catalog.GetString ("Search");
			this.hbox4.Add (this.mButtonSearch);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.mButtonSearch]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox5.Add (this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox4]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox3.Add (this.vbox5);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.vbox5]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.mCheckWordpress = new global::Gtk.CheckButton ();
			this.mCheckWordpress.CanFocus = true;
			this.mCheckWordpress.Name = "mCheckWordpress";
			this.mCheckWordpress.Label = global::Mono.Unix.Catalog.GetString ("Wordpress");
			this.mCheckWordpress.Active = true;
			this.mCheckWordpress.DrawIndicator = true;
			this.mCheckWordpress.UseUnderline = true;
			this.vbox7.Add (this.mCheckWordpress);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.mCheckWordpress]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.mCheckHubpages = new global::Gtk.CheckButton ();
			this.mCheckHubpages.CanFocus = true;
			this.mCheckHubpages.Name = "mCheckHubpages";
			this.mCheckHubpages.Label = global::Mono.Unix.Catalog.GetString ("Hubpages");
			this.mCheckHubpages.Active = true;
			this.mCheckHubpages.DrawIndicator = true;
			this.mCheckHubpages.UseUnderline = true;
			this.vbox7.Add (this.mCheckHubpages);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.mCheckHubpages]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.mBlogEngine = new global::Gtk.CheckButton ();
			this.mBlogEngine.CanFocus = true;
			this.mBlogEngine.Name = "mBlogEngine";
			this.mBlogEngine.Label = global::Mono.Unix.Catalog.GetString ("Blog Engine");
			this.mBlogEngine.Active = true;
			this.mBlogEngine.DrawIndicator = true;
			this.mBlogEngine.UseUnderline = true;
			this.vbox7.Add (this.mBlogEngine);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.mBlogEngine]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.mExpressionEngine = new global::Gtk.CheckButton ();
			this.mExpressionEngine.CanFocus = true;
			this.mExpressionEngine.Name = "mExpressionEngine";
			this.mExpressionEngine.Label = global::Mono.Unix.Catalog.GetString ("Expression Engine");
			this.mExpressionEngine.Active = true;
			this.mExpressionEngine.DrawIndicator = true;
			this.mExpressionEngine.UseUnderline = true;
			this.vbox7.Add (this.mExpressionEngine);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.mExpressionEngine]));
			w10.Position = 3;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.mCheckNormal = new global::Gtk.CheckButton ();
			this.mCheckNormal.CanFocus = true;
			this.mCheckNormal.Name = "mCheckNormal";
			this.mCheckNormal.Label = global::Mono.Unix.Catalog.GetString ("Other");
			this.mCheckNormal.Active = true;
			this.mCheckNormal.DrawIndicator = true;
			this.mCheckNormal.UseUnderline = true;
			this.vbox7.Add (this.mCheckNormal);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.mCheckNormal]));
			w11.Position = 4;
			w11.Expand = false;
			w11.Fill = false;
			this.GtkAlignment.Add (this.vbox7);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel7 = new global::Gtk.Label ();
			this.GtkLabel7.Name = "GtkLabel7";
			this.GtkLabel7.LabelProp = global::Mono.Unix.Catalog.GetString ("Search only:");
			this.GtkLabel7.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel7;
			this.hbox1.Add (this.frame1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.frame1]));
			w14.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(12));
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.mCheckPagerank = new global::Gtk.CheckButton ();
			this.mCheckPagerank.CanFocus = true;
			this.mCheckPagerank.Name = "mCheckPagerank";
			this.mCheckPagerank.Label = global::Mono.Unix.Catalog.GetString ("Check Pagerank (slower)");
			this.mCheckPagerank.Active = true;
			this.mCheckPagerank.DrawIndicator = true;
			this.mCheckPagerank.UseUnderline = true;
			this.vbox2.Add (this.mCheckPagerank);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.mCheckPagerank]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.mCommentLuv = new global::Gtk.CheckButton ();
			this.mCommentLuv.CanFocus = true;
			this.mCommentLuv.Name = "mCommentLuv";
			this.mCommentLuv.Label = global::Mono.Unix.Catalog.GetString ("CommentLuv");
			this.mCommentLuv.DrawIndicator = true;
			this.mCommentLuv.UseUnderline = true;
			this.vbox2.Add (this.mCommentLuv);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.mCommentLuv]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.mKeywordLuv = new global::Gtk.CheckButton ();
			this.mKeywordLuv.CanFocus = true;
			this.mKeywordLuv.Name = "mKeywordLuv";
			this.mKeywordLuv.Label = global::Mono.Unix.Catalog.GetString ("KeywordLuv");
			this.mKeywordLuv.DrawIndicator = true;
			this.mKeywordLuv.UseUnderline = true;
			this.vbox2.Add (this.mKeywordLuv);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.mKeywordLuv]));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.mTopCommenter = new global::Gtk.CheckButton ();
			this.mTopCommenter.CanFocus = true;
			this.mTopCommenter.Name = "mTopCommenter";
			this.mTopCommenter.Label = global::Mono.Unix.Catalog.GetString ("Top Commentator");
			this.mTopCommenter.DrawIndicator = true;
			this.mTopCommenter.UseUnderline = true;
			this.vbox2.Add (this.mTopCommenter);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.mTopCommenter]));
			w18.Position = 3;
			w18.Expand = false;
			w18.Fill = false;
			this.GtkAlignment1.Add (this.vbox2);
			this.frame2.Add (this.GtkAlignment1);
			this.GtkLabel12 = new global::Gtk.Label ();
			this.GtkLabel12.Name = "GtkLabel12";
			this.GtkLabel12.LabelProp = global::Mono.Unix.Catalog.GetString ("Options:");
			this.GtkLabel12.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel12;
			this.hbox1.Add (this.frame2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.frame2]));
			w21.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.mSearchProgress = new global::Gtk.ProgressBar ();
			this.mSearchProgress.HeightRequest = 10;
			this.mSearchProgress.Name = "mSearchProgress";
			this.vbox6.Add (this.mSearchProgress);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.mSearchProgress]));
			w22.Position = 0;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.mLocale = new global::PromoterTool.GoogleChooser ();
			this.mLocale.Events = ((global::Gdk.EventMask)(256));
			this.mLocale.Name = "mLocale";
			this.vbox6.Add (this.mLocale);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.mLocale]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.WidthRequest = 150;
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Min Pagerank");
			this.vbox6.Add (this.label4);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.label4]));
			w24.Position = 2;
			w24.Expand = false;
			w24.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.mMinPagerank = new global::Gtk.HScale (null);
			this.mMinPagerank.CanFocus = true;
			this.mMinPagerank.Name = "mMinPagerank";
			this.mMinPagerank.Adjustment.Lower = -1;
			this.mMinPagerank.Adjustment.Upper = 10;
			this.mMinPagerank.Adjustment.PageIncrement = 2;
			this.mMinPagerank.Adjustment.StepIncrement = 1;
			this.mMinPagerank.Adjustment.Value = -1;
			this.mMinPagerank.DrawValue = true;
			this.mMinPagerank.Digits = 0;
			this.mMinPagerank.ValuePos = ((global::Gtk.PositionType)(1));
			this.vbox6.Add (this.mMinPagerank);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.mMinPagerank]));
			w25.Position = 3;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Search Depth");
			this.vbox6.Add (this.label5);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.label5]));
			w26.Position = 4;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.mSearchDepth = new global::Gtk.HScale (null);
			this.mSearchDepth.CanFocus = true;
			this.mSearchDepth.Name = "mSearchDepth";
			this.mSearchDepth.UpdatePolicy = ((global::Gtk.UpdateType)(1));
			this.mSearchDepth.Adjustment.Lower = 1;
			this.mSearchDepth.Adjustment.Upper = 5;
			this.mSearchDepth.Adjustment.PageIncrement = 1;
			this.mSearchDepth.Adjustment.PageSize = 1;
			this.mSearchDepth.Adjustment.StepIncrement = 1;
			this.mSearchDepth.Adjustment.Value = 1;
			this.mSearchDepth.DrawValue = true;
			this.mSearchDepth.Digits = 0;
			this.mSearchDepth.ValuePos = ((global::Gtk.PositionType)(1));
			this.vbox6.Add (this.mSearchDepth);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.mSearchDepth]));
			w27.Position = 5;
			w27.Expand = false;
			w27.Fill = false;
			this.hbox1.Add (this.vbox6);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox6]));
			w28.Position = 2;
			w28.Expand = false;
			w28.Fill = false;
			this.vbox3.Add (this.hbox1);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Search Results (double click to open):");
			this.hbox2.Add (this.label8);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label8]));
			w30.Position = 0;
			w30.Expand = false;
			w30.Fill = false;
			this.vbox3.Add (this.hbox2);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox2]));
			w31.Position = 2;
			w31.Expand = false;
			w31.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.mSearchResults = new global::Gtk.TreeView ();
			this.mSearchResults.CanFocus = true;
			this.mSearchResults.Name = "mSearchResults";
			this.GtkScrolledWindow.Add (this.mSearchResults);
			this.vbox3.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow]));
			w33.Position = 3;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.mButtonSearch.Clicked += new global::System.EventHandler (this.OnSearchClicked);
			this.mCheckWordpress.Toggled += new global::System.EventHandler (this.OnRefilter);
			this.mCheckHubpages.Toggled += new global::System.EventHandler (this.OnRefilter);
			this.mBlogEngine.Toggled += new global::System.EventHandler (this.OnRefilter);
			this.mExpressionEngine.Toggled += new global::System.EventHandler (this.OnRefilter);
			this.mCheckNormal.Toggled += new global::System.EventHandler (this.OnRefilter);
			this.mMinPagerank.ValueChanged += new global::System.EventHandler (this.OnRefilter);
			this.mSearchResults.RowActivated += new global::Gtk.RowActivatedHandler (this.OnResultActivated);
			this.mSearchResults.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnSearchResultsBtnPress);
			this.mSearchResults.PopupMenu += new global::Gtk.PopupMenuHandler (this.OnPopupMenu);
		}
	}
}
