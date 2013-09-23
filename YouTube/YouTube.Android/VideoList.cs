using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Graphics;
using System.Net;

namespace YouTube
{
    [Activity(Label = "YouTube", MainLauncher = true, Icon = "@drawable/icon")]
    public class VideoList : Activity
    {
		ListView listview;
		List<Entry> entrys;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var tvSearch = FindViewById<TextView> (Resource.Id.editText1);
			var btnSearch = FindViewById<Button> (Resource.Id.button1);
			listview = FindViewById<ListView>(Resource.Id.listViewMain);

			btnSearch.Click += (sender, e) => {

				var searcher = new YouTubeSearcher ();
				entrys = searcher.Search (tvSearch.Text);
				foreach (Entry en in entrys)
				{
					en.pic = GetImageBitmapFromUrl(en.Thumbnail);
				}
				listview.Adapter = new EntryAdapter(this, entrys);
				listview.ItemClick += (senderobj, e2) => {
					var intent = new Intent(Intent.ActionView,Android.Net.Uri.Parse(entrys[e2.Position].Link));
					StartActivity(intent);
			};

			


			};

           
        }
		private Bitmap GetImageBitmapFromUrl(string url)
		{
			return BitmapFactory.DecodeStream (new Java.Net.URL(url).OpenStream()); 
		}
	} 

    public class EntryAdapter : BaseAdapter<Entry>
    {
         List<Entry> items;
    
        Activity context;

        public EntryAdapter(Activity context, List<Entry> items)
            : base()
        {
            this.context = context;
            this.items = items;

        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Entry this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
 
        /// <summary>
        /// 系統會呼叫 並且render.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null)
            {
                //使用自訂的UserListItemLayout
                view = context.LayoutInflater.Inflate(Resource.Layout.VideoListItem, null);
            }
 
			view.FindViewById<TextView>(Resource.Id.tvTitle).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.tvPubDate).Text = item.PubDate.ToShortDateString();

			view.FindViewById<ImageView> (Resource.Id.thumbnail).SetImageBitmap (item.pic);
 
            return view;
        }
 
     

    
    }
}

