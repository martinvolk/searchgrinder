using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data;
using Gtk;
using System.IO;
//using CsvHelper;

namespace PromoterTool
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class EmailsWidget : Gtk.Bin
	{
		private Thread mSearchWorker;
		private Gtk.ListStore mResultList;
		private Gtk.TreeModelFilter mFilter;
		private Dictionary<string, string[]> mProcessedEmails;
		private Dictionary<string, bool> mLatestQuery;
		private string[] mColumnTitles;
		
		private bool isSearching = false;
		private bool doAbortSearch = false;
		
		public EmailsWidget ()
		{
			this.Build ();
			
			mSearchWorker = new Thread(ThreadSearch);
			mResultList = new Gtk.ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
			mProcessedEmails = new Dictionary<string, string[]>();
			mLatestQuery = new Dictionary<string, bool>();
			
			mComboFilterCat.InsertText(0, "-- All Domains --");
			mComboFilterCat.InsertText(1, "Only gmail, yahoo etc.");
			mComboFilterCat.InsertText(2, "Only Other Domains");
			
			mColumnTitles = new string[]{"E-Mail", "Query", "Campaign", "Source URL", "Domain", "Date Added"};
			
			Gtk.CellRendererToggle toggle = new Gtk.CellRendererToggle();
			toggle.Activatable = true;
			toggle.Mode = Gtk.CellRendererMode.Activatable;
			
			Gtk.CellRenderer [] rends = new Gtk.CellRenderer[]{
				new Gtk.CellRendererText(),
				new Gtk.CellRendererText(),
				new Gtk.CellRendererText(),
				new Gtk.CellRendererText(),
				new Gtk.CellRendererText(),
				new Gtk.CellRendererText()
			};
			
			for(int c=0;c<mColumnTitles.Length;c++){
				Gtk.TreeViewColumn col = new Gtk.TreeViewColumn();
				col.Clicked += (sender, e) => Refilter();
				col.Title = mColumnTitles[c];
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
				
				mEmailResults.AppendColumn(col);
			}
			
			mFilter = new Gtk.TreeModelFilter(mResultList, null);
			mFilter.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc(FilterResults);
			
			Gtk.TreeModelSort mSorter = new Gtk.TreeModelSort(mFilter);
			mEmailResults.Model = mSorter;
			
			mComboFilterCat.Active = 0;
		}
		
		private bool IsEmailVisible(string [] row){
			if(row[0] == null) return false;
			
			if(row.Length < 4 || (mCheckLatestOnly.Active && !mLatestQuery.ContainsKey(row[0])))
				return false;
			try{
				Regex r = new Regex(".+?@(hotmail|gmail|yahoo|live|spray|telia|swipnet|bredband|msn|tele2|glocalnet)\\..*", RegexOptions.IgnoreCase);
				//if(mComboFilterCat.Active != 0 && mComboFilterCat.ActiveText != row[2])
				//	return false;
				if(mComboFilterCat.Active == 1 && r.IsMatch(row[0]))
					return true;
				if(mComboFilterCat.Active == 2 && !r.IsMatch(row[0]))
					return true;
				if(mComboFilterCat.Active == 0)
					return true;
			}catch(Exception e){
				Console.WriteLine(e);
			}
			return false;
		}
		private bool FilterResults(Gtk.TreeModel model, Gtk.TreeIter iter){
			string [] row={
				(string)mResultList.GetValue(iter, 0),
				(string)mResultList.GetValue(iter, 1),
				(string)mResultList.GetValue(iter, 2),
				(string)mResultList.GetValue(iter, 3),
				(string)mResultList.GetValue(iter, 4),
				(string)mResultList.GetValue(iter, 5)
			};
			return IsEmailVisible(row);
		}
		
		private void AddResult(string [] line){
			try{
				if(line[0] == null) return;
				mProcessedEmails.Add(line[0]+"-"+line[2], line);
				mLatestQuery[line[0]] = true;
				mResultList.AppendValues(line[0], line[1], line[2], line[3], line[4], line[5]); 
				mEmailList.Buffer.Insert(mEmailList.Buffer.EndIter, line[0]+",\n");
				mResultTotal.Text= "("+mProcessedEmails.Values.Count+")";
			}
			catch(Exception e){
				return;
			}
			
		}
		private void ClearResults(){
			mResultList.Clear();
			mProcessedEmails.Clear();
			mEmailList.Buffer.Clear();
			mLatestQuery.Clear ();
		}
		
		private bool getEmails(string url, 
                            Dictionary<string, bool> visited_urls, 
                            int current_level=0, int max_depth=1,
		                    string status_prefix = "Processing: "){
			
			
			if(doAbortSearch)
				return false;
			
			if(visited_urls == null)
				visited_urls = new Dictionary<string, bool>();
			
			string status = "";
			Gtk.Application.Invoke(delegate { 
				mStatus.Text = status = status_prefix+url;
			});
			
			string content = "";
			try{
				Console.WriteLine("Downloading "+url);
				content = new System.Net.WebClient().DownloadString(url);
			}catch(Exception e){
				Console.WriteLine (e.Message);
				return false;
			}
			
			var mailreg = new Regex(@"\b([A-Z0-9._%-]+)@([A-Z0-9.-]+\.[A-Z]{2,6})\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			var matches = mailreg.Matches(content);
			
			foreach(Match match in matches){
				Console.WriteLine(" -- found: "+match.Value);
				
				if(!mProcessedEmails.ContainsKey(match.Value)){
					ManualResetEvent ev = new ManualResetEvent(false);
				
					Gtk.Application.Invoke(delegate { 
						string[] values = new string[]{
							match.Value, 
							mSearchQuery.Text, 
							mEntryCampaignName.Text, 
							url,
							match.Groups[2].Value,
							DateTime.Now.ToString()
						};
						this.AddResult(values); 
						ev.Set();
					});
					
					ev.WaitOne();
				}
			}
			
			if(current_level >= max_depth){
				return false;
			}
			
			Console.WriteLine("Checking links...");
			// search sub pages
			var urls = (new Regex("<a[^>]+href=\"([^\"]+)\"[^>]*>").Matches(content));
			int match_count = 0;
			foreach(Match match in urls){
				if(match.Groups.Count < 2) continue;
				string link = match.Groups[1].Value;
				var uri = new Uri(new Uri(url), link);
				if(!visited_urls.ContainsKey(uri.AbsoluteUri) && 
				   !(mCheckSingleDomain.Active && (new Uri(url)).Host != uri.Host)){
					Console.WriteLine("Diving into: "+uri.AbsoluteUri);
					getEmails (uri.AbsoluteUri, visited_urls, current_level+1, max_depth, status_prefix+" ["+match_count+"/"+urls.Count+"]: ");
					visited_urls[uri.AbsoluteUri] = true;
				}
				match_count++;
			}
			
			return true;
		}
		
		private void DisableControls(){
			Gtk.Application.Invoke(delegate{
				mSearchQuery.Sensitive = false;
				mBtnSearch.Label = "Cancel Search";
			});
		}
		
		private void EnableControls(){
			Gtk.Application.Invoke(delegate{
				mBtnSearch.Sensitive = true;
				mSearchQuery.Sensitive = true;
				mBtnSearch.Label = "Find Emails";
				mProgress.Fraction = 0;
				mStatus.Text = "Ready!";
			});
		}
		private void ThreadSearch(){
			string original_label = "";
			
			if(isSearching){
				doAbortSearch = true;
				mSearchWorker.Abort();
				return;
			}
			
			DisableControls();
			
			isSearching = true;
			mLatestQuery.Clear ();
			
			//Dictionary<string, Google.SearchResult> links = new Dictionary<string, Google.SearchResult>();
			
			
			
			if((new Regex(@"http://.*")).IsMatch(mSearchQuery.Text)){
				getEmails(mSearchQuery.Text, null, 0, (int)mScaleDepth.Value);
			}
			// do a google search first 
			else{
				Gtk.Application.Invoke(delegate { 
					mStatus.Text = "Gathering google search results for query...";
				});
				Google.SearchResult [] res = Google.GetSearchResults(mSearchQuery.Text, 100, (int)mScaleNumPages.Value, 0, "com");
				int i = 0;
				
				foreach(Google.SearchResult r in res){
					// scan the search result for all emails on page
					try{
						Gtk.Application.Invoke(delegate { 
							mStatus.Text = "Processing ["+i+"/"+res.Length+"]: "+r.url;
						});
						
						getEmails(r.url, null, 0, (int)mScaleDepth.Value, "Processing ["+i+"/"+res.Length+"]: ");
					}
					catch(Exception e){
						Console.WriteLine(e.Message);
					}
					
					Gtk.Application.Invoke(delegate{
						mProgress.Fraction = (float)i/((res.Length>0)?res.Length:1);
					});
					i++;
					
					if(doAbortSearch)
						break;
				}
			}
				
			EnableControls();
			doAbortSearch = false;
			isSearching = false;
		}
		public void SaveData(DataManager data){
			data.RunCommand("delete from emails;");
			foreach(string [] row in mProcessedEmails.Values){
				data.RunCommand(string.Format(
					"insert into emails(email, query, campaign, source) values('{0}', '{1}', '{2}','{3}');",
					row[0], row[1], row[2], row[3]));
			}
		}
	
		public void LoadData(DataManager data){
			IDataReader r = data.RunQuery("select * from emails;");
			while(r.Read()){
				this.AddResult(new string[] {r.GetString(0), r.GetString(1), r.GetString(2), r.GetString(3), "", ""});//r.GetString(4), r.GetString(5)});
			}
			this.Refilter();
		}
		private void Refilter(){
			mFilter.Refilter();
			Dictionary<string, string> campaigns = new Dictionary<string, string>();
			
			
			mEmailList.Buffer.Clear();
			
			int c=0;
			Gtk.TreeIter iter; 
			if(mEmailResults.Model.GetIterFirst(out iter)) {
				do {
					string email = mEmailResults.Model.GetValue(iter, 0).ToString();
					mEmailList.Buffer.Insert(mEmailList.Buffer.EndIter, email+",\n");
				} while(mEmailResults.Model.IterNext(ref iter));
			}
			
			foreach(string [] row in mProcessedEmails.Values){
				if(IsEmailVisible(row)){
					c++;
					//mEmailList.Buffer.Insert(mEmailList.Buffer.EndIter, row[0]+",\n");
					if(!campaigns.ContainsKey(row[2]))
						campaigns.Add(row[2], row[2]);
				}
				mResultTotal.Text = "("+c+")";
			}
			
		}
		
		protected void onSearchClicked (object sender, System.EventArgs e)
		{
			if(isSearching == true){
				doAbortSearch = true;
				return;
			}
			mSearchWorker = new Thread(ThreadSearch);
			mSearchWorker.Start();
		}
		private bool ExportToCsvFile(TreeView treeView, string path)
		{
			Gtk.TreeIter iter; 
			if(treeView.Model.GetIterFirst(out iter)) {
				using (StreamWriter streamWriter = new StreamWriter(path, false))
		    	{
					streamWriter.WriteLine(string.Join(",", mColumnTitles));
					do {
						List<string> cols = new List<string>();
						for(int c=0;c<treeView.Model.NColumns; c++){
							cols.Add("\""+treeView.Model.GetValue(iter, c).ToString()+"\"");
						}
						try{
							streamWriter.WriteLine(string.Join(",", cols.ToArray()));
						} catch(Exception e){
							Console.WriteLine(e.Message);
						}
					} while(treeView.Model.IterNext(ref iter));
				}
			}
			return true;
		}
		protected void onExportCsvClicked (object sender, System.EventArgs e)
		{
			Gtk.FileChooserDialog dlg = new Gtk.FileChooserDialog(
			    	"Save Results",
		          MainClass.MainWindow,
		          FileChooserAction.Save,
		          "Cancel", ResponseType.Cancel,
		          "Save", ResponseType.Accept);
			if(dlg.Run() == (int)ResponseType.Accept){
				ExportToCsvFile(mEmailResults, dlg.Filename);
			}
			dlg.Destroy();
		}

		protected void onExportListClicked (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void onClearResultsClicked (object sender, System.EventArgs e)
		{
			this.ClearResults();
		}

		protected void onRecordTypeChanged (object sender, System.EventArgs e)
		{
			this.Refilter();
		}

		protected void onCampaignFilterFocus (object o, Gtk.FocusInEventArgs args)
		{
			Refilter();
		}

		protected void onLatestQueryClicked (object sender, System.EventArgs e)
		{
			Refilter();
		}

		protected void onSearchKeyPress (object o, Gtk.KeyPressEventArgs args)
		{
			if(args.Event.Key == Gdk.Key.Return)
				onSearchClicked(o, null);
		}
	}
}

