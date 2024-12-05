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
    UIColor _previousColor = Color.Transparent.ToUIColor();

    public NumericEntryCellRenderer()
    {
    }

    public override UITableViewCell GetCell (Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
    {

      if (reusableCell == null) 
      {
        reusableCell = base.GetCell (item as Xamarin.Forms.Cell, reusableCell, tv);

        //item.PropertyChanged

        EntryCell entryCell = item as EntryCell;

        foreach (var subview in reusableCell.Subviews[0].Subviews) 
        {
          UITextField field = subview as UITextField;
          if (field != null) 
          {
            // Get rid of the blinking cursor for these types of entries.
            field.EditingDidBegin += (object sender, EventArgs e) => 
            {
              _previousColor = reusableCell.BackgroundColor;
              reusableCell.BackgroundColor = Colors.LightLightGreen.ToUIColor();
            };

            field.EditingDidEnd += (object sender, EventArgs e) => 
            {
              reusableCell.BackgroundColor = _previousColor;
            };

            field.TintColor = Color.Transparent.ToUIColor ();
            // Create the accessory toolbar (ie done button) and hook up it's action
            field.InputAccessoryView = KeyboardInputAccessoryHelper.CreateAccessoryToolbar (() => {
              NumericEntryCell nec = item as NumericEntryCell;
              if (nec != null)
              {
                nec.OnCompleted();
              }
              field.ResignFirstResponder ();
            });
            // Remove the period if we are numeric keyboard
            if (entryCell.Keyboard == Keyboard.Numeric) 
            {
              field.KeyboardType = UIKeyboardType.NumberPad;
            }

          }
        }
      }

      return reusableCell;
    }
  }
}

