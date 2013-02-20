using System;
//using Twitterizer;
using System.Threading;

namespace PromoterTool
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class TwitterWidget : Gtk.Bin
	{
		Gtk.ListStore mResultsList;
		Thread mSearchWorker;
		
		public TwitterWidget ()
		{
			this.Build ();
			
			string [] titles = new string[]{"User", "Followers", "Following"};
			mSearchWorker = new Thread(SearchWorker);
			
			for(int c=0;c<titles.Length;c++){
				Gtk.TreeViewColumn col = new Gtk.TreeViewColumn();
				col.Title = titles[c];
				col.Resizable = true;
				
				Gtk.CellRendererText rend = new Gtk.CellRendererText();
				col.SortColumnId = c;
				col.PackStart(rend, true);
				col.AddAttribute(rend, "markup", c);
				
				mSearchResults.AppendColumn(col);
			}
			
			mResultsList = new Gtk.ListStore(typeof(string), typeof(int), typeof(string));
			mSearchResults.Model = mResultsList;
		}
		private void SearchWorker(){
			ManualResetEvent ev = new ManualResetEvent(false);
			Gtk.Application.Invoke(delegate{
				mButtonSearch.Sensitive = false;
				ev.Set();
			});
			ev.WaitOne();
			
			
			//var results = TwitterSearch.Search(mSearchEntry.Text);
			
			//foreach(TwitterSearchResult res in results.ResponseObject){
			//	Console.WriteLine(res.FromUserScreenName + " " + res.Text);
			//}
			
			Gtk.Application.Invoke(delegate{
				mButtonSearch.Sensitive = true;
			});
		}
		
		protected virtual void onTwitterSearch (object sender, System.EventArgs e)
		{
			if(mSearchWorker.IsAlive)
				mSearchWorker.Abort();
			mSearchWorker = new Thread(SearchWorker);
			mSearchWorker.Start();
		}
	}
}

