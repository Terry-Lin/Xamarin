// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace TechDays2013
{
	[Register ("WebService")]
	partial class WebService
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCalculate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblResult { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segMethod { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segService { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txttemp { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCalculate != null) {
				btnCalculate.Dispose ();
				btnCalculate = null;
			}

			if (lblResult != null) {
				lblResult.Dispose ();
				lblResult = null;
			}

			if (segMethod != null) {
				segMethod.Dispose ();
				segMethod = null;
			}

			if (segService != null) {
				segService.Dispose ();
				segService = null;
			}

			if (txttemp != null) {
				txttemp.Dispose ();
				txttemp = null;
			}
		}
	}
}
