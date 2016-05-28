using System;
using CoreGraphics;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using System.ComponentModel;
using XLabs.Forms.Controls;
using DebtCalculator.Shared;

[assembly: ExportRenderer(typeof(NumericEntryCell), typeof(DebtCalculator.iOS.NumericEntryCellRenderer))]
namespace DebtCalculator.iOS
{
  public class NumericEntryCellRenderer : EntryCellRenderer
  {
    public NumericEntryCellRenderer()
    {
      
    }

    public override UITableViewCell GetCell (Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
    {

      if (reusableCell == null) 
      {
        reusableCell = base.GetCell (item as Xamarin.Forms.Cell, reusableCell, tv);

        foreach (var subview in reusableCell.Subviews[0].Subviews) 
        {
          UITextField field = subview as UITextField;
          if (field != null) 
          {
            field.TintColor = Color.Transparent.ToUIColor ();
            field.InputAccessoryView = KeyboardInputAccessoryHelper.CreateAccessoryToolbar (() => {
              NumericEntryCell nec = item as NumericEntryCell;
              if (nec != null)
              {
                nec.OnCompleted();
              }
              field.ResignFirstResponder ();
            });
          }
        }
      }

      return reusableCell;
    }
  }
}

