using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using Xamarin.Forms;

namespace MyExam.iOS.Helpers
{
    public class TableSource : UITableViewSource
    {
        List<ToolbarItem> tableItems;
        string[] tableItemTexts;
        string CellIdentifier = "TableCell";

        public TableSource(List<ToolbarItem> items)
        {
            tableItems = items;
            tableItemTexts = items.Select(a => a.Text).ToArray();
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItemTexts.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = tableItemTexts[indexPath.Row];
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }
            cell.TextLabel.Text = item;
            return cell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 56;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var command = tableItems[0].Command;
            command.Execute(tableItems[0].CommandParameter);
            tableView.DeselectRow(indexPath, true);
            tableView.RemoveFromSuperview();
        }
    }
}
