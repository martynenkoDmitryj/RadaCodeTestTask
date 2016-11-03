using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace RadaCodeTestTask.iOS
{
	public class TextFieldWithList
	{
		int selectedIndex = -1;

		UIViewController viewController;
		UITextField textField;
		UITableView tableView;
		UITableViewSource tableViewSource;

		List<string> items;
		List<string> filteredItems;

		public TextFieldWithList(UIViewController viewController, UITextField textField, List<string> items)
		{
			selectedIndex = -1;
			this.viewController = viewController;
			this.textField = textField;
			this.items = items;
			this.filteredItems = this.items.Where(x => x.ToLower().Contains(this.textField.Text.ToLower())).ToList();
			tableView = new UITableView(new CoreGraphics.CGRect(this.textField.Frame.X, this.textField.Frame.Y + this.textField.Frame.Height, this.textField.Frame.Width, this.viewController.View.Frame.Height - this.textField.Frame.Y - this.textField.Frame.Height));
			tableView.ScrollEnabled = true;
			tableView.Alpha = 0;
			tableViewSource = new TextFieldWithListTableViewSource(this.filteredItems, this.SelectedElement);
			tableView.ReloadData();


			tableView.Layer.BorderColor = new CoreGraphics.CGColor(0, 0, 0);
			tableView.Layer.BorderWidth = 0.4f;
			tableView.Layer.CornerRadius = 10;
			this.textField.EditingChanged += (sender, e) =>
			{
				selectedIndex = -1;
				UIView.Animate(0.25, () =>
				{
					tableView.Alpha = 100;
				}, () => { });
				filteredItems = this.items.Where(x => x.ToLower().Contains(this.textField.Text.ToLower())).ToList();
				tableViewSource = new TextFieldWithListTableViewSource(this.filteredItems, this.SelectedElement);
				tableView.Source = this.tableViewSource;
				tableView.ReloadData();
			};

			this.viewController.View.AddSubview(this.tableView);
			textField.Ended += (sender, e) =>
			{
				UIView.Animate(0.25, () =>
				{
					tableView.Alpha = 0;
				}, () => { });
			};
		}

		private void SelectedElement(nint index)
		{
			selectedIndex = (int)index;
			string selectedElement = filteredItems[(int)selectedIndex];
			textField.Text = selectedElement;
			textField.EndEditing(true);
		}

		#region UITableViewSource
		private class TextFieldWithListTableViewSource : UITableViewSource
		{
			private List<string> items;
			private Action<nint> selectedElementCallback;

			public TextFieldWithListTableViewSource(List<string> items, Action<nint> selectedElementCallback)
			{
				this.items = items;
				this.selectedElementCallback = selectedElementCallback;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return items.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				string elementText = this.items[indexPath.Row];

				UITableViewCell cell = new UITableViewCell();
				cell.TextLabel.Text = elementText;
				cell.TextLabel.TextColor = UIColor.DarkGray;
				cell.TextLabel.Font = UIFont.FromName(cell.TextLabel.Font.Name, 11);
				return cell;
			}

			public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				if (selectedElementCallback != null) selectedElementCallback(indexPath.Row);
			}
		}
		#endregion

	}
	public static class TextFieldWithListManager
	{
		static List<TextFieldWithList> textFields = new List<TextFieldWithList>();
		public static void AddListToTextField(TextFieldWithList textField)
		{
			textFields.Add(textField);
		}
	}
}
