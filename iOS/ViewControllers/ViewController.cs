using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIKit;

namespace RadaCodeTestTask.iOS
{
	public partial class ViewController : UIViewController
	{

		public ViewController(IntPtr handle) : base(handle)
		{

		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

			VKClient vk = new VKClient();
			await vk.LoadCountries();
			var Countries = new List<string>();
			var Cities = new List<string>();
			var Universities = new List<string>();

			foreach (var item in vk.Countries)
			{
				Countries.Add(item.Value);
			}

			TextFieldWithListManager.AddListToTextField(new TextFieldWithList(this, CountryTextField, Countries));
			CountryTextField.Ended += async (s, e) =>
			{
				if (Countries.Contains(CountryTextField.Text))
				{
					await vk.LoadCities(CountryTextField.Text);
					foreach (var item in vk.Cities)
					{
						Cities.Add(item.Value);
					}
					CityTextField.Enabled = true;
					TextFieldWithListManager.AddListToTextField(new TextFieldWithList(this, CityTextField, Cities));

				}
				else
				{
					CityTextField.Enabled = false;
					CountryTextField.Text = "";
				}
			};
			CityTextField.EditingChanged += async (s, e) =>
			{
				await vk.LoadCities(CountryTextField.Text, CityTextField.Text);
				Cities.Clear();
				foreach (var item in vk.Cities)
				{
					Cities.Add(item.Value);
				}

			};
			CityTextField.Ended += async (s, e) =>
			{
				if (Cities.Contains(CityTextField.Text))
				{
					UniversityTextField.Enabled = true;
					await vk.LoadUniversities(CountryTextField.Text, CityTextField.Text);
					foreach (var item in vk.Universities)
					{
						Universities.Add(item.Value);
					}
					TextFieldWithListManager.AddListToTextField(new TextFieldWithList(this, UniversityTextField, Universities));

				}
				else
				{
					CityTextField.Text = "";
					UniversityTextField.Enabled = false;
				}
			};
			UniversityTextField.EditingChanged += async (s, e) =>
			{
				await vk.LoadUniversities(CountryTextField.Text, CityTextField.Text, UniversityTextField.Text);
				Universities.Clear();
				foreach (var item in vk.Universities)
				{
					Universities.Add(item.Value);
				}
			};

			FirstNameTextField.EditingChanged += (sender, e) =>
			{
				if (FirstNameTextField.Text != "")
					LastNameTextField.Enabled = true;
				else LastNameTextField.Enabled = false;
			};
			LastNameTextField.EditingChanged += (sender, e) =>
			{
				if (LastNameTextField.Text != "")
					CountryTextField.Enabled = true;
				else CountryTextField.Enabled = false;
			};

			FirstNameTextField.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return false;
			};
			LastNameTextField.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return false;
			};
			CountryTextField.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return false;
			};
			CityTextField.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return false;
			};
			UniversityTextField.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return false;
			};
			FillButton.TouchUpInside += (sender, e) =>
			{

				BlancDataViewController vc = this.Storyboard.InstantiateViewController("iBDVC") as BlancDataViewController;
				vc.FirstName = FirstNameTextField.Text;
				vc.LastName = LastNameTextField.Text;
				vc.CountryName = CountryTextField.Text;
				vc.CityName = CityTextField.Text;
				vc.UniversityName = UniversityTextField.Text;
				NavigationController.PushViewController(vc, true);
			};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}


}
