// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace TechDays2013
{
	[Register ("Database")]
	partial class Database
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCipher { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnRead { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSQLite { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblmsg { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCipher != null) {
				btnCipher.Dispose ();
				btnCipher = null;
			}

			if (btnRead != null) {
				btnRead.Dispose ();
				btnRead = null;
			}

			if (btnSQLite != null) {
				btnSQLite.Dispose ();
				btnSQLite = null;
			}

			if (lblmsg != null) {
				lblmsg.Dispose ();
				lblmsg = null;
			}
		}
	}
}
