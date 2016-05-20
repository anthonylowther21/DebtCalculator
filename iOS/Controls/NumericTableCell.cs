using System;
using UIKit;
using Foundation;
using Xamarin.Forms;

namespace DebtCalculator.iOS
{
  public class NumericTableCell : UITableViewCell
  {
    private UILabel headingLabel;
    private UITextField _textField;
    private EntryCell _xfCell;

    public NumericTableCell (NSString cellId, EntryCell xfCell) : base (UITableViewCellStyle.Default, cellId)
    {
      _xfCell = xfCell;
      SelectionStyle = UITableViewCellSelectionStyle.Gray;

      //ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 224);

//      headingLabel = new UILabel () 
//      {
//        BackgroundColor = UIColor.Clear,
//        Text = xfCell.Label
//      };

      _textField = new UITextField () 
      {
        KeyboardType = UIKeyboardType.NumberPad,
        Text = xfCell.Text,
        Placeholder = xfCell.Label
      };

      SetTextAlignment (xfCell, _textField);

      _textField.InputView = null;
      _textField.InputAccessoryView = 
        KeyboardInputAccessoryHelper.CreateAccessoryToolbar (() => _textField.ResignFirstResponder ());

      //ContentView.Add (headingLabel);
      ContentView.Add (_textField);
    }

    /// <summary>
    /// Sets the text alignment.
    /// </summary>
    /// <param name="view">The view.</param>
    private void SetTextAlignment(EntryCell view, UITextField textField)
    {
      switch (view.HorizontalTextAlignment)
      {
      case TextAlignment.Center:
        textField.TextAlignment = UITextAlignment.Center;
        break;
      case TextAlignment.End:
        textField.TextAlignment = UITextAlignment.Right;
        break;
      case TextAlignment.Start:
        textField.TextAlignment = UITextAlignment.Left;
        break;
      }
    }

    public void UpdateCell (string text)
    {
      _textField.Text = text;
    }

    public override void LayoutSubviews ()
    {
      base.LayoutSubviews ();



      //headingLabel.Frame = new CoreGraphics.CGRect (10, 10, ContentView.Bounds.Width / 2, 20);
      _textField.Frame = new CoreGraphics.CGRect (0, 20, 320, 40);
    }
  }
}

