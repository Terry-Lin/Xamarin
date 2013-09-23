using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace YouTube
{
	public partial class RootViewController : UITableViewController
	{
        List<Entry> SearchResult;

		public RootViewController (IntPtr handle) : base (handle)
		{
            this.Title = "YouTube·j´M";
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            this.BtnSearch.SearchButtonClicked += (obj, e) =>
            {
                YouTubeSearcher searcher = new YouTubeSearcher();
                SearchResult = searcher.Search(this.BtnSearch.Text);
                this.TblResult.Source = new DataSource(this, SearchResult);
                this.TblResult.ReloadData();
                this.BtnSearch.ResignFirstResponder();
            };
		}



		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
            var indexPath = this.TblResult.IndexPathForSelectedRow;
            var DestViewController = (DetailViewController) segue.DestinationViewController;
            DestViewController.URL = SearchResult[indexPath.Row].Link;
		}
	}

    public class DataSource : UITableViewSource
    {
        static readonly NSString CellIdentifier = new NSString("VideoCell");
        List<Entry> Entrys;
        RootViewController controller;

        public DataSource(RootViewController controller, List<Entry> source)
        {
            this.controller = controller;
            this.Entrys = source;
        }


        public override int RowsInSection(UITableView tableview, int section)
        {
            return Entrys.Count;
        }
        

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

            cell.TextLabel.Text = Entrys[indexPath.Row].Title;
            cell.DetailTextLabel.Text = Entrys[indexPath.Row].PubDate.ToShortDateString();

            NSUrl nsUrl = new NSUrl(Entrys[indexPath.Row].Thumbnail);
            NSData data = NSData.FromUrl(nsUrl);
            cell.ImageView.Image = new UIImage(data);

            return cell;
        }

    }
}

