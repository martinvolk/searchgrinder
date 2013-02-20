using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
//using NPlot;
using Gdk;
using Gtk;

namespace PromoterTool
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class RankingsWidget : Gtk.Bin
	{
		
		Gtk.ListStore mRankingsList;
		List<string> mResult = new List<string>();
		//NPlot.Gtk.PlotSurface2D mPlot = new NPlot.Gtk.PlotSurface2D();
		
		Thread mSearchWorker;
		
		public string [] Keywords{
			set {
				mKeywords.Buffer.Text = String.Join("\n", value);
			}
			get{
				return mKeywords.Buffer.Text.Split('\n');
			}
		}
		
		public string [] Domains{
			set{
				mDomains.Buffer.Text = String.Join("\n", value);
			}
			get{
				return mDomains.Buffer.Text.Split('\n');
			}
		}
		
		public RankingsWidget ()
		{
			this.Build ();
			
			string [] titles = new string[]{"Keyword", "Rank", "Page"};
			mSearchWorker = new Thread(SearchWorker);
			
			for(int c=0;c<titles.Length;c++){
				Gtk.TreeViewColumn col = new Gtk.TreeViewColumn();
				col.Title = titles[c];
				col.Resizable = true;
				
				Gtk.CellRendererText rend = new Gtk.CellRendererText();
				col.SortColumnId = c;
				col.PackStart(rend, true);
				col.AddAttribute(rend, "markup", c);
				
				mRankTreeView.AppendColumn(col);
			}
			
			mRankingsList = new Gtk.ListStore(typeof(string), typeof(int), typeof(string));
			//mSorter = new Gtk.TreeModelSort(mRankingsList);
			
			mRankTreeView.Model = mRankingsList;
			
			// add plot
			/*
			mPlotContainer.Add(mPlot);
			NPlot.LinePlot p = new NPlot.LinePlot();
			int[] data = new int[10]{5,4,2,6,4,7,4,3,6,3};
            p.DataSource = data;
            p.Label = "Actual";
            //lpActual.Shadow = true;
			mPlot.Add(p);
			mPlot.Add(new NPlot.Grid(), PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
			*/
			//mPlot.Refresh();
		}
		
		private void SearchWorker(){
			string [] keywords = mKeywords.Buffer.Text.Split('\n');
			string [] domains = mDomains.Buffer.Text.Split('\n');
			Console.WriteLine("====");
			
			ManualResetEvent ev = new ManualResetEvent(false);
			Gtk.Application.Invoke(delegate{
				mButtonUpdate.Sensitive = false;
				mResult.Clear();
				ev.Set();
			});
			ev.WaitOne();
			
			float prog = 0;
			foreach(string keyword in keywords){
				Google.SearchResult [] res = Google.GetSearchResults(keyword, 100, (int)mSearchDepth.Value, 0, mLocale.TopLevelDomain);
				foreach(string domain in domains){
					for(int c=0;c<res.Length;c++){
						if(res[c].url.Contains(domain)){
							Console.WriteLine(keyword+"|"+(c+1)+"|"+domain);
							ev = new ManualResetEvent(false);
							Gtk.Application.Invoke(delegate{
								mRankingsList.AppendValues(keyword, c+1, res[c].url);
								mResult.Add(keyword+";"+(c+1)+";"+res[c].url);
								ev.Set();
							});
							ev.WaitOne();
							break;
						}
					}
				}
				prog++;
				
				Gtk.Application.Invoke(delegate{mProgress.Fraction = prog / keywords.Length;});
			}
			Gtk.Application.Invoke(delegate{mProgress.Fraction = 0;});
			Gtk.Application.Invoke(delegate{mButtonUpdate.Sensitive = true;});
		}
		protected virtual void OnUpdateClicked (object sender, System.EventArgs e)
		{
			mRankingsList.Clear();
			
			if(mSearchWorker.IsAlive)
				mSearchWorker.Abort();
			mSearchWorker = new Thread(SearchWorker);
			mSearchWorker.Start();
		}
		public void SaveData(DataManager data){
			// Clear the database keywords
			data.RunCommand("delete from keywords");
			data.RunCommand("delete from domains");
			
			foreach(string keyword in Keywords){
				data.RunCommand("insert into keywords(keyword) values('"+keyword+"')");
			}
			foreach(string domain in Domains){
				data.RunCommand("insert into domains(domain) values('"+domain+"')");
			}
		}
		
		public void LoadData(DataManager data){
			Keywords = data.GetValueList("select keyword from keywords");
			Domains = data.GetValueList("select domain from domains");
		}
		protected virtual void onSaveResultsClicked (object sender, System.EventArgs e)
		{
			Gtk.FileChooserDialog dlg = new Gtk.FileChooserDialog(
				"Save Keywords Results To CSV",
				null,
				FileChooserAction.Save,
				"Cancel", ResponseType.Cancel,
			    "Save", ResponseType.Accept);
			if(dlg.Run() == (int)ResponseType.Accept){
				StreamWriter f = new StreamWriter(dlg.Filename+".csv");
				foreach(string s in mResult){
					f.WriteLine(s);
				}
				f.Close();
			}
			dlg.Destroy();
		}
	}
}

