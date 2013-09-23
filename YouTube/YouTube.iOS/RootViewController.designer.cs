// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace YouTube
{
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		MonoTouch.UIKit.UISearchBar BtnSearch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TblResult { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnSearch != null) {
				BtnSearch.Dispose ();
				BtnSearch = null;
			}

			if (TblResult != null) {
				TblResult.Dispose ();
				TblResult = null;
			}
		}
	}
}
