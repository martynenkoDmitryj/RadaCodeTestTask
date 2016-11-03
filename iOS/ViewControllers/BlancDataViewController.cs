using System;

using UIKit;

namespace RadaCodeTestTask.iOS
{
	public partial class BlancDataViewController : UIViewController
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CountryName { get; set; }
		public string CityName { get; set; }
		public string UniversityName { get; set; }

		public BlancDataViewController(IntPtr handle) : base(handle)
		{

		}

		public BlancDataViewController()
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			NameLabel.Text += FirstName;
			LastNameLabel.Text += LastName;
			CountryLabel.Text += CountryName;
			CityLabel.Text += CityName;
			UniversityLabel.Text += UniversityName;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

