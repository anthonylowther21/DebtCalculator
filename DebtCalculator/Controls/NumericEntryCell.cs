using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace DebtCalculator.Shared
{
  public class NumericEntryCell : EntryCell
  {
    int _previousLength = 0;

    public NumericEntryCell()
    {
      this.PropertyChanged += (object sender, PropertyChangedEventArgs e) => 
      {
        if (e.PropertyName == TextProperty.PropertyName)
        {
//          int newLength = this.Text.Length;
//          string text = this.Text;
//          double result = double.Parse(text, System.Globalization.NumberStyles.Currency);
//          if (newLength > _previousLength)
//          {
//            result *= 10;
//          }
//          else
//          {
//            result /= 10;
//          }
//          this.Text = string.Format("{0:C}", result);
        }
      };
    }
  }
}

