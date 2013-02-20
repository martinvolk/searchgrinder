using System;
using System.Web;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;
using HtmlAgilityPack;
using Gtk;
using System.Threading;

class Google
{
	public class SearchResult{
		public string url;
		public string title;
		public string content;
		public int rank = -1;
	}
	
    private const UInt32 myConst = 0xE6359A60;
    private static void _Hashing(ref UInt32 a, ref UInt32 b, ref UInt32 c)
    {
        a -= b; a -= c; a ^= c >> 13;
        b -= c; b -= a; b ^= a << 8;
        c -= a; c -= b; c ^= b >> 13;
        a -= b; a -= c; a ^= c >> 12;
        b -= c; b -= a; b ^= a << 16;
        c -= a; c -= b; c ^= b >> 5;
        a -= b; a -= c; a ^= c >> 3;
        b -= c; b -= a; b ^= a << 10;
        c -= a; c -= b; c ^= b >> 15;
    }
    public static string PerfectHash(string theURL)
    {
        var url = string.Format("info:{0}", theURL);

        int length = url.Length;
        
        UInt32 a, b;
        UInt32 c = myConst;

        int k = 0;
        int len = length;

        a = b = 0x9E3779B9;

        while (len >= 12)
        {
            a += (UInt32)(url[k + 0] + (url[k + 1] << 8) + 
                 (url[k + 2] << 16) + (url[k + 3] << 24));
            b += (UInt32)(url[k + 4] + (url[k + 5] << 8) + 
                 (url[k + 6] << 16) + (url[k + 7] << 24));
            c += (UInt32)(url[k + 8] + (url[k + 9] << 8) + 
                 (url[k + 10] << 16) + (url[k + 11] << 24));
            _Hashing(ref a, ref b, ref c);
            k += 12;
            len -= 12;
        }
        c += (UInt32)length;
        switch (len) 
        {
            case 11: 
                c += (UInt32)(url[k + 10] << 24); 
                goto case 10;
            case 10: 
                c += (UInt32)(url[k + 9] << 16); 
                goto case 9;
            case 9: 
                c += (UInt32)(url[k + 8] << 8); 
                goto case 8;
            case 8: 
                b += (UInt32)(url[k + 7] << 24); 
                goto case 7;
            case 7: 
                b += (UInt32)(url[k + 6] << 16); 
                goto case 6;
            case 6: 
                b += (UInt32)(url[k + 5] << 8); 
                goto case 5;
            case 5: 
                b += (UInt32)(url[k + 4]); 
                goto case 4;
            case 4: 
                a += (UInt32)(url[k + 3] << 24); 
                goto case 3;
            case 3: 
                a += (UInt32)(url[k + 2] << 16); 
                goto case 2;
            case 2: 
                a += (UInt32)(url[k + 1] << 8); 
                goto case 1;
            case 1: 
                a += (UInt32)(url[k + 0]); 
                break;
            default: 
                break;
        }
        
        _Hashing(ref a, ref b, ref c);

        return string.Format("6{0}", c);
    }

	private static bool blocked = false;
	private static Timer mTimer = null;
	
    public static int GetPageRank(string myURL)
    {
		if(blocked)
			return -1;
		
        string strDomainHash = PerfectHash(myURL);
        string myRequestURL = string.Format("http://toolbarqueries.google.com/" + 
               "search?client=navclient-auto&hl=se&lr=lang_en&ch={0}&features=Rank&q=info:{1}", 
               strDomainHash, myURL);
        try
        {
            WebClient wc = new WebClient();
			string myResponse = wc.DownloadString(myRequestURL);
            if (myResponse.Length == 0)
                return 0;
            else{
                return int.Parse(Regex.Match(myResponse, 
                       "Rank_1:[0-9]:([0-9]+)").Groups[1].Value);
			}
        }
        catch (Exception e)
        {
			if(e.Message.Contains("Forbidden")){
				ManualResetEvent ev = new ManualResetEvent(false);
				Gtk.Application.Invoke(delegate{
					Gtk.MessageDialog dlg = new Gtk.MessageDialog(null, 
						DialogFlags.DestroyWithParent,
						MessageType.Error, 
						ButtonsType.Ok, 
					   	"Could not get pagerank:\n\n"+e.Message+"\n\nGoogle puts a limit to how many PageRank queries you can make in a short period of time. You will have to wait a while before you can use the page rank function again.");
					dlg.Run();
					dlg.Destroy();
					
					blocked = true;
					if(mTimer != null)
						mTimer.Dispose();
					mTimer = new Timer(delegate{blocked = false;}, null, 0, 1000*60);
					
					ev.Set();
				});
				ev.WaitOne();
			}
            return -1;
        }
    }
	
	public static Google.SearchResult [] GetSearchResults(string query, int resperpage=100, int pages=10, int start=0, string tld="com"){
		var wc = new HtmlWeb();
		
		List<Google.SearchResult> res = new List<SearchResult>();
		//query = System.Web.HttpUtility.UrlEncode(query);
		
		for(int page=0;page<pages;page++){
			var url = "http://www.google."+tld+"/search?sourceid=chrome&ie=UTF-8&num="+resperpage+"&start="+
				(start+page*resperpage)+"&q="+query;
			HtmlDocument doc = null;
			
			try{
				doc = wc.Load(url);
			}
			catch(Exception e){
				Console.WriteLine("Could not load page: "+e.ToString());
				continue;
			}
			HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@id=\"ires\"]/ol/li");
			if(nodes == null){
				Console.WriteLine("Could not retreive results for query: "+query);
				continue;
			}
			foreach(HtmlNode result in nodes)
			{
				try{
					Google.SearchResult r = new Google.SearchResult();
					var link = result.SelectNodes("h3/a[@href]")[0];
					var matches = Regex.Matches(link.Attributes["href"].Value as string, "q=(.+?)&amp;");
					r.url = matches[0].Groups[1].Value;
					r.title = link.InnerText;
					var s = result.SelectNodes("div[@class=\"s\"]");
					if(s != null && s.Count > 0)
						r.content = s[0].InnerText;
					res.Add(r);
				}catch(Exception e){
					Console.WriteLine(e.Message);
					continue;
				}
			}
		}
		return res.ToArray();
	}
	
}
