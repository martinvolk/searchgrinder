using System;
using System.Web;
using Gtk;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

public partial class MainWindow : Gtk.Window
{
	private DataManager mData;
	private string mDatabaseFile = "";
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build();
		
		if(File.Exists("default.sgd"))
			File.Delete("default.sgd");
		
		//LoadProject("default.sgd");
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void onSearchClicked (object sender, System.EventArgs e)
	{
	}
	
	private void LoadProject(string name){
		mData = new DataManager(name);
		
		//mRankings.LoadData(mData);
		//mPromotion.LoadData(mData);
		mEmailWidget.LoadData(mData);
	}
	
	private void SaveProject(string filename){
		if(filename != "")
			mData.SaveAs(filename);
		
		//mRankings.SaveData(mData);
		//mPromotion.SaveData(mData);
		//mEmailWidget.SaveData(mData);
	}
	protected virtual void OnSave (object sender, System.EventArgs e)
	{
		SaveProject(mDatabaseFile);
	}
	
	protected virtual void OnFileOpen (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog dlg = new Gtk.FileChooserDialog(
		    	"Open Project",
	          this,
	          FileChooserAction.Open,
	          "Cancel", ResponseType.Cancel,
	          "Open", ResponseType.Accept);
		if(dlg.Run() == (int)ResponseType.Accept){
			//LoadProject(dlg.Filename);
			//mDatabaseFile = dlg.Filename;
		}
		dlg.Destroy();
	}
	
	protected virtual void OnFileSave (object sender, System.EventArgs e)
	{
		if(mDatabaseFile != ""){
			SaveProject(mDatabaseFile);
			return;
		}
		
		Gtk.FileChooserDialog dlg = new Gtk.FileChooserDialog(
		    	"Save Project",
	          this,
	          FileChooserAction.Save,
	          "Cancel", ResponseType.Cancel,
	          "Save", ResponseType.Accept);
		if(dlg.Run() == (int)ResponseType.Accept){
			SaveProject(dlg.Filename);
			mDatabaseFile = dlg.Filename;
		}
		dlg.Destroy();
	}
	
	protected virtual void OnFileQuit (object sender, System.EventArgs e)
	{
		Application.Quit();
	}
	
	
	protected virtual void OnFileSaveAs (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog dlg = new Gtk.FileChooserDialog(
		    	"Save As",
	          this,
	          FileChooserAction.Save,
	          "Cancel", ResponseType.Cancel,
	          "Save", ResponseType.Accept);
		if(dlg.Run() == (int)ResponseType.Accept){
			SaveProject(dlg.Filename);
			mDatabaseFile = dlg.Filename;
		}
		dlg.Destroy();
	}
	
	protected virtual void OnHelpOpenClicked (object sender, System.EventArgs e)
	{
		System.Diagnostics.Process.Start("http://redbluewebsites.com/contact/");
	}
	
	protected virtual void OnAboutClicked (object sender, System.EventArgs e)
	{
		PromoterTool.DlgAbout dlg = new PromoterTool.DlgAbout();
		dlg.Show();
	}
	
	
	
	
}

