using System;
using System.Data;
using System.Collections.Generic;

using System.IO;
//using Mono.Data.Sqlite;
using Gtk;

public class DataManager{
	private IDbConnection mDb = null;
	private string mFileName;
	
	public DataManager(string file){
		LoadDatabase(file);
	}
	
	public void SaveAs(string file){
		if(mDb == null) return;
		mDb.Close();
		if(mFileName != file){
			try{
				File.Copy(mFileName, file, true);
			}
			catch(Exception e){
				Gtk.MessageDialog dlg = new Gtk.MessageDialog(null, Gtk.DialogFlags.Modal, Gtk.MessageType.Info, Gtk.ButtonsType.Ok, 
				                "Error: "+e.Message                               );
				dlg.Run();
				dlg.Destroy();
				
				LoadDatabase(mFileName);
				return;
			}
		}
		LoadDatabase(file);
	}
	
	public void LoadDatabase(string file){
		if(mDb == null) return;
		
		bool create = !File.Exists(file);
		
		string connectionString = "URI=file:"+file+",version=3";
		if(mDb != null)
			mDb.Close();
		try{
			//mDb = (IDbConnection) new SqliteConnection(connectionString);
			//mDb.Open();
		}
		catch(Exception e){
			Gtk.MessageDialog dlg = new Gtk.MessageDialog(null, Gtk.DialogFlags.Modal, Gtk.MessageType.Info, Gtk.ButtonsType.Ok, 
				                "Error: "+e.Message                               );
				dlg.Run();
				dlg.Destroy();
		}
		if(create)
			CreateDatabase(file);
		
		mFileName = file;
	}
	
	public string GetOption(string name, string def){
		if(mDb == null) return "";
		IDataReader rd = RunQuery("select option_value from options where option_name = '"+name+"';");
		
		if(!rd.Read())
			return def;
		return rd.GetString(0);
	}
	
	public void SetOption(string name, string val){
		if(mDb == null) return;
		string opt = GetOption(name, "");
		if(opt == "")
			RunCommand("insert into options(option_name, option_value) values('"+name+"', '"+val+"');");
		else
			RunCommand("update options set option_value = '"+val+"' where option_name = '"+name+"'");
	}
	
	public IDataReader RunQuery(string query){
		if(mDb == null) return null;
		IDbCommand cmd = mDb.CreateCommand();
		cmd.CommandText = query;
		IDataReader rd = cmd.ExecuteReader();
		cmd.Dispose();
		return rd;
	}
	
	/**
	 * Reads all the values returned by the query and returns them as a string list
	 */
	public string [] GetValueList(string query){
		List<string> res = new List<string>();
		if(mDb == null) return res.ToArray();
		IDataReader rd = RunQuery(query);
		
		while(rd.Read()){
			for(int c=0;c<rd.FieldCount; c++){
				res.Add(rd.GetValue(c).ToString());
			}
		}
		return res.ToArray();
	}
	
	public void RunCommand(string query){
		if(mDb == null) return;
		IDbCommand cmd = mDb.CreateCommand();
		cmd.CommandText = query;
		cmd.ExecuteNonQuery();
		cmd.Dispose();
	}
	
	
	private void CreateDatabase(string file){
		RunCommand("create table keywords(keyword varchar(256) primary key, seoc int(11))");
		RunCommand("create table domains(domain varchar(256) primary key, extlinks int(11))");
		RunCommand("create table rankings(domain varchar(256), keyword varchar(256), position int(11), url varchar(256))");
		RunCommand("create table emails(email varchar(64), query varchar(256), campaign varchar(256), source varchar(512))");
		RunCommand("create table options(option_name varchar(256) primary key, option_value varchar(256))");
	}
}
