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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITextField CityTextField { get; set; }

		[Outlet]
		UIKit.UITextField CountryTextField { get; set; }

		[Outlet]
		UIKit.UIButton FillButton { get; set; }

		[Outlet]
		UIKit.UITextField FirstNameTextField { get; set; }

		[Outlet]
		UIKit.UITextField LastNameTextField { get; set; }

		[Outlet]
		UIKit.UITextField UniversityTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FillButton != null) {
				FillButton.Dispose ();
				FillButton = null;
			}

			if (CityTextField != null) {
				CityTextField.Dispose ();
				CityTextField = null;
			}

			if (CountryTextField != null) {
				CountryTextField.Dispose ();
				CountryTextField = null;
			}

			if (FirstNameTextField != null) {
				FirstNameTextField.Dispose ();
				FirstNameTextField = null;
			}

			if (LastNameTextField != null) {
				LastNameTextField.Dispose ();
				LastNameTextField = null;
			}

			if (UniversityTextField != null) {
				UniversityTextField.Dispose ();
				UniversityTextField = null;
			}
		}
	}
}
