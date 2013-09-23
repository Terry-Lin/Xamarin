// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace TechDays2013
{
	[Register ("BasicControl")]
	partial class BasicControl
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView _img { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider _slider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch _switch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnHello { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblmsg { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblmsg != null) {
				lblmsg.Dispose ();
				lblmsg = null;
			}
            
			if (btnHello != null) {
				btnHello.Dispose ();
				btnHello = null;
			}

			if (_switch != null) {
				_switch.Dispose ();
				_switch = null;
			}

			if (_slider != null) {
				_slider.Dispose ();
				_slider = null;
			}

			if (_img != null) {
				_img.Dispose ();
				_img = null;
			}
		}
	}
}
