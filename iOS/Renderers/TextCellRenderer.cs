using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (TextCell), typeof (TableSectionHeaderRenderer))]
public class TableSectionHeaderRenderer : TextCellRenderer
{
  public override UITableViewCell GetCell (Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
  {

    if (reusableCell == null) 
    {
      var textCell = item as TextCell;
      if (string.IsNullOrEmpty (textCell.Text)) 
      {
        item.Height = 0;
      }

      reusableCell = base.GetCell (item as Xamarin.Forms.Cell, reusableCell, tv);
    }

    return reusableCell;
  }
}