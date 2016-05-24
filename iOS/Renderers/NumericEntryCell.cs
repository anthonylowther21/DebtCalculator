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
            field.InputAccessoryView = KeyboardInputAccessoryHelper.CreateAccessoryToolbar (() => field.ResignFirstResponder ());
            field.ShouldChangeCharacters += (textField, range, replacementString) => 
            {
              return true;
//              if (replacementString == string.Empty)
//              {
//                double result = double.Parse(textField.Text, System.Globalization.NumberStyles.Currency);
//                result /= 10;
//                textField.Text = result.ToString();
//                return false;
//              }
//              else
//              {
//                double result = double.Parse(textField.Text, System.Globalization.NumberStyles.Currency);
//                result *= 10;
//                textField.Text = result.ToString();
//                return false;
//              }
            };
             
          }
        }
      }

      return reusableCell;
    }
  }
}

