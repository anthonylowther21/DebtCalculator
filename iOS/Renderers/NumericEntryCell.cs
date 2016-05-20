using System;
using CoreGraphics;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using System.ComponentModel;
using XLabs.Forms.Controls;
using DebtCalculator.Shared;

[assembly: ExportRenderer(typeof(EntryCell), typeof(DebtCalculator.iOS.NumericEntryCell))]
namespace DebtCalculator.iOS
{
  public class NumericEntryCell : EntryCellRenderer
  {
    //static NSString rid = new NSString ("EntryCell");

    public override UITableViewCell GetCell (Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
    {

      //var x = (EntryCell)item;

      reusableCell = base.GetCell (item as Xamarin.Forms.Cell, reusableCell, tv);

      foreach (var subview in reusableCell.Subviews[0].Subviews) {
        UITextField field = subview as UITextField;
        if (field != null) {
          field.InputAccessoryView = KeyboardInputAccessoryHelper.CreateAccessoryToolbar (() => field.ResignFirstResponder ());
        }
      }
//      NumericTableCell c = reusableCell as NumericTableCell;
//
//      if (c == null) {
//        c = new NumericTableCell (rid, x);
//      }

      return reusableCell;
    }
  }
}

