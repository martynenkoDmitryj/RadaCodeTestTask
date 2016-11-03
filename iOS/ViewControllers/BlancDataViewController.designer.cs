// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RadaCodeTestTask.iOS
{
	[Register ("BlancDataViewController")]
	partial class BlancDataViewController
	{
		[Outlet]
		UIKit.UILabel CityLabel { get; set; }

		[Outlet]
		UIKit.UILabel CountryLabel { get; set; }

		[Outlet]
		UIKit.UILabel LastNameLabel { get; set; }

		[Outlet]
		UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		UIKit.UILabel UniversityLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (LastNameLabel != null) {
				LastNameLabel.Dispose ();
				LastNameLabel = null;
			}

			if (CountryLabel != null) {
				CountryLabel.Dispose ();
				CountryLabel = null;
			}

			if (CityLabel != null) {
				CityLabel.Dispose ();
				CityLabel = null;
			}

			if (UniversityLabel != null) {
				UniversityLabel.Dispose ();
				UniversityLabel = null;
			}
		}
	}
}
