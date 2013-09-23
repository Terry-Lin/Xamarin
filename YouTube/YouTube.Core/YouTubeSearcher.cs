using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

#if Android
using System.Drawing;
using Android.Graphics;
#endif

#if WP8
using Microsoft.Phone.Controls;
using System.Net;
#endif

namespace YouTube
{
    public class YouTubeSearcher
    {
        //引入所需的Namespace
        static XNamespace ns = "http://www.w3.org/2005/Atom";
        static XNamespace openSearch = "http://a9.com/-/spec/opensearchrss/1.0/";
        static XNamespace gd = "http://schemas.google.com/g/2005";
        static XNamespace media = "http://search.yahoo.com/mrss/";
        static XNamespace yt = "http://gdata.youtube.com/schemas/2007";
        XDocument ytDoc;
#if WP8
        public LongListSelector list { get; set; }
#endif

        //輸入關鍵字搜尋並返回查詢結果的List物件
        public List<Entry> Search(string Keyword)
        {
            //string Keyword = "進擊的巨人";
            
            //輸入關鍵字搜尋, 並限制回傳20筆資料
            string youTubeUrl = "http://gdata.youtube.com/feeds/api/videos?q=" + Keyword + "&max-results=20";

            ytDoc = XDocument.Load(youTubeUrl);

            /*
             * 透過LINQ to XML 解析返回的XML文件, 取出entry(返回的查詢結果)中的以下元素
             *Title: 影片標題
             *published : 影片上傳日期
             * player : 播放網址
             * thumbnail : 縮圖網址
             * */
            var data = from xml in ytDoc.Descendants()
                       select new SearchResult
                       {
                           entrys = (from en in xml.Elements(ns + "entry")
                                     select new Entry
                                     {
                                         Title = en.Element(ns + "title").Value,
                                         PubDate = DateTime.Parse(en.Element(ns + "published").Value),
                                         Link = en.Element(media + "group").Element(media + "player").Attribute("url").Value.Replace("&feature=youtube_gdata_player","").Replace("watch?v=","embed/"),
                                         Thumbnail = en.Element(media + "group").Element(media + "thumbnail").Attribute("url").Value 
                                     }).ToList()
                       };
            return data.ElementAt(0).entrys;
        }
#if WP8
        public void SearchForWP8(string Keyword)
        {
            string youTubeUrl = "http://gdata.youtube.com/feeds/api/videos?q=" + Keyword + "&max-results=20";
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            webClient.DownloadStringAsync(new Uri(youTubeUrl));
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ytDoc = XDocument.Parse(e.Result);
                var data = from xml in ytDoc.Descendants()
                           select new SearchResult
                           {
                               entrys = (from en in xml.Elements(ns + "entry")
                                         select new Entry
                                         {
                                             Title = en.Element(ns + "title").Value,
                                             PubDate = DateTime.Parse(en.Element(ns + "published").Value),
                                             Link = en.Element(media + "group").Element(media + "player").Attribute("url").Value.Replace("&feature=youtube_gdata_player", ""),
                                             Thumbnail = en.Element(media + "group").Element(media + "thumbnail").Attribute("url").Value
                                         }).ToList()
                           };

                list.ItemsSource = data.ElementAt(0).entrys;
            }
        }
#endif
    }
    public class Entry
    {
        public string Title { get; set; }
        public DateTime PubDate { get; set; }
        public string Thumbnail { get; set; }
        public string Link { get; set; }

#if Android
		public Bitmap pic { get; set;}
#endif

    }

    public class SearchResult
    {

        public string id { get; set; }
        public DateTime updated { get; set; }
        public string title { get; set; }
        public Uri logo;
        public List<Entry> entrys { get; set; }
    }
    
}
