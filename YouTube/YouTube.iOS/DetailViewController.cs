using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace YouTube
{
	public partial class DetailViewController : UIViewController
	{
        public string URL;

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}


		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            this.webview.LoadHtmlString ("<iframe  id=\"yt\" class=\"youtube-player\" width=\"300\" height=\"186\"  src=\""+URL+"\" frameborder=\"0\">", null);
		}
	}

  
}

