using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace PromoterTool
{
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class PromotionWidget : Gtk.Bin
	{
		private Gtk.ListStore mSearchResultList;
		private Gtk.TreeModelFilter mFilter;
		private Gtk.TreeModelSort mSorter;
		
		private Gtk.Menu mPopupMenu;
		
		private Thread mSearchWorker;
		
		private enum Columns{
			TYPE = 0,
			PR,
			TITLE,
			LINK
		};
		
		private class SearchResult{
			public SearchResult(string _type, Google.SearchResult _r){
				type = _type;
				result = _r;
			}
			
			public string type;
			public Google.SearchResult result;
		}
		
		public PromotionWidget ()
		{
			this.Build ();
			
			mPopupMenu = new Gtk.Menu();
			Gtk.MenuItem it = new Gtk.MenuItem("test");
			mPopupMenu.Append(it);
			
			mSearchWorker = new Thread(ThreadSearch);
			
			string [] titles = new string[]{"T", "PR", "Title", "Link"};
			Gtk.CellRendererToggle toggle = new Gtk.CellRendererToggle();
			
			toggle.Activatable = true;
			toggle.Mode = Gtk.CellRendererMode.Activatable;
			
			
			Gtk.CellRenderer [] rends = new Gtk.CellRenderer[]{
				new Gtk.CellRendererText(),
				new Gtk.CellRendererText(),
				new Gtk.CellRendererText(),
				new Gtk.CellRendererText()
			};
			
			for(int c=0;c<titles.Length;c++){
				Gtk.TreeViewColumn col = new Gtk.TreeViewColumn();
				col.Title = titles[c];
				col.Resizable = true;
				col.SortColumnId = c;
				col.PackStart(rends[c], true);
				
				if(c == -1){
					col.AddAttribute(rends[c], "active", c);
					//col.SetCellDataFunc (rends[c],new Gtk.TreeCellDataFunc (TaskToggleCellDataFunc));
				}
				else{
					col.AddAttribute(rends[c], "markup", c);
				}
				
				mSearchResults.AppendColumn(col);
			}
			
			mSearchResultList = new Gtk.ListStore(typeof(string), typeof(int), typeof(string), typeof(string));
			//mSearchResults.Model = mSearchResultList;
			
			mFilter = new Gtk.TreeModelFilter(mSearchResultList, null);
			mFilter.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc(FilterResults);
			
			mSorter = new Gtk.TreeModelSort(mFilter);
			//mSorter.SetSortColumnId(1, Gtk.SortType.Ascending);
			
			mSearchResults.Model = mSorter;
		}
		
		private void ThreadSearch(){
			Dictionary<string, List<string>> mTerms = new Dictionary<string, List<string>>();
			
			Gtk.Application.Invoke(delegate{mButtonSearch.Sensitive = false;});
			
			string common = "-\"comments closed\"";//-\"approved\"-\"moderated\"-\"you must log\"-\"be logged in\"-\"required to post\"-\"no comments\"-\"you must accept the terms of service\"";
			if(mCheckWordpress.Active){
				List<string> terms = new List<string>();
				
				terms.Add("\"\"leave a comment\" or \"Leave a Reply\"\"");
				terms.Add("\"blog comments powered by DISQUS\"");
				
				mTerms["B"] = terms;
			}
			if(mCheckHubpages.Active){
				List<string> terms = new List<string>();
				
				terms.Add("\"Submit a Comment\" and \"Sign in or sign up and post using a hubpages account\"");
				
				mTerms["HP"] = terms;
			}
			if(mExpressionEngine.Active){
				List<string> terms = new List<string>();
				terms.Add("\"powered by expressionengine\"");
				mTerms["EE"] = terms;
			}
			if(mBlogEngine.Active){
				List<string> terms = new List<string>();
				terms.Add("\"powered by blogengine.net\"");
				mTerms["BE"] = terms;
			}
			if(mCheckNormal.Active){
				List<string> terms = new List<string>();
				terms.Add("");
				mTerms["*"] = terms;
			}
			
			Dictionary<string, SearchResult> links = new Dictionary<string, SearchResult>();
			
			// Perform the search
			int i = 0;
			List<string> list = new List<string>();
			if(mCommentLuv.Active)
				list.Add("commentluv");
			if(mKeywordLuv.Active)
				list.Add("keywordluv");
			if(mTopCommenter.Active)
				list.Add("commentator");
			string comment_types = " AND \""+string.Join(" OR ", list.ToArray())+"\" ";
			
			foreach(KeyValuePair<string, List<string>> p in mTerms){
				foreach(string term in p.Value){
					string str = mSearchTerm.Text+" "+comment_types+" "+term+" "+common;
					Google.SearchResult [] res = Google.GetSearchResults(str, 100, (int)mSearchDepth.Value, 0, mLocale.TopLevelDomain);
					foreach(Google.SearchResult r in res){
						links[r.url] = new SearchResult(p.Key, r);
					}
					Gtk.Application.Invoke(delegate{
						mSearchProgress.Fraction = (float)i/mTerms.Keys.Count;
					});
					i++;
				}
			}
			
			// Update the gui
			Gtk.Application.Invoke(delegate { mSearchResultList.Clear(); });
			
			int c = 0;
			foreach(KeyValuePair<string, SearchResult> p in links){
				var r = p.Value;
				if(mCheckPagerank.Active)
					r.result.rank = Google.GetPageRank(r.result.url);
				else {
					r.result.rank = -1;
				}
				ManualResetEvent ev = new ManualResetEvent(false);
				Gtk.Application.Invoke(delegate { 
					mSearchResultList.AppendValues(r.type, 
					                               r.result.rank, 
					                               r.result.title, 
					                               r.result.url
					                               ); 
					ev.Set();
				});
				ev.WaitOne();
			}
			Gtk.Application.Invoke(delegate{
				mButtonSearch.Sensitive = true;
				mSearchProgress.Fraction = 0;
			});
		}
		public void SaveData(DataManager data){
			data.SetOption("search_blogs", mCheckWordpress.Active.ToString());
			data.SetOption("search_hubpages", mCheckHubpages.Active.ToString());
			data.SetOption("check_pr", mCheckPagerank.Active.ToString());
			data.SetOption("search_normal", mCheckNormal.Active.ToString());
			data.SetOption("search_blogengine", mBlogEngine.Active.ToString());
			data.SetOption("search_expressionengine", mExpressionEngine.Active.ToString());
		}
		public void LoadData(DataManager data){
			mCheckHubpages.Active = bool.Parse(data.GetOption("search_hubpages", "True"));
			mCheckWordpress.Active = bool.Parse(data.GetOption("search_blogs", "True"));
			mCheckPagerank.Active = bool.Parse(data.GetOption("check_pr", "True"));
			mCheckNormal.Active = bool.Parse(data.GetOption("search_normal", "False"));
			mBlogEngine.Active = bool.Parse(data.GetOption("search_blogengine", "True"));
			mExpressionEngine.Active = bool.Parse(data.GetOption("search_expressionengine", "True"));
		}
		private bool FilterResults(Gtk.TreeModel model, Gtk.TreeIter iter){
			int pr = (int)mSearchResultList.GetValue(iter, (int)Columns.PR);
			string type = (string)mSearchResultList.GetValue(iter, (int)Columns.TYPE);
			if(pr < mMinPagerank.Value)
				return false;
			else{
				if(mCheckWordpress.Active && type == "B")
					return true;
				else if(mCheckHubpages.Active && type == "HP")
					return true;
				else if(mCheckNormal.Active && type == "*")
					return true;
				else if(mExpressionEngine.Active && type == "EE")
					return true;
				else if(mBlogEngine.Active && type == "BE")
					return true;
			}
			return false;
		}
		
		protected virtual void OnSearchClicked (object sender, System.EventArgs e)
		{
			if(mSearchWorker.IsAlive)
				mSearchWorker.Abort();
			mSearchWorker = new Thread(ThreadSearch);
			mSearchWorker.Start();
		}
		
		protected virtual void OnResultActivated (object o, Gtk.RowActivatedArgs args)
		{
			Gtk.TreeIter iter;
			mSorter.GetIter(out iter, args.Path);
			
			iter = mFilter.ConvertIterToChildIter(mSorter.ConvertIterToChildIter(iter));
			
			string url = mSearchResultList.GetValue(iter, (int)Columns.LINK).ToString();
			System.Diagnostics.Process.Start(url);
		}
		
		 [GLib.ConnectBefore]
		protected virtual void OnSearchResultsBtnPress (object o, Gtk.ButtonPressEventArgs args)
		{
			/*
			Gtk.Menu mnu = new Gtk.Menu();
            Gtk.MenuItem msel = new Gtk.MenuItem("Mark As Commented");
			msel.Activated += delegate(object sender, EventArgs e) {
				Gtk.TreeIter iter;
			};
            mnu.Add(msel);
            mnu.ShowAll();
            mnu.Popup();
            */
		}
		
		protected virtual void OnPopupMenu (object o, Gtk.PopupMenuArgs args)
		{
			
		}
		
		protected virtual void OnRefilter (object sender, System.EventArgs e)
		{
			mFilter.Refilter();
		}
	}
}

