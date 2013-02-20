using System;
using System.Data;
using System.Collections.Generic;

class Project{
	private List<string> mKeywords;
	private string mDomains;
	
	public List<string> Keywords{
		get{
			return mKeywords;
		}
		set{
			mKeywords = value;
		}
	}
	
	public string Domains{
		get{
			return mDomains;
		}
		set{
			mDomains = value;
		}
	}
}
