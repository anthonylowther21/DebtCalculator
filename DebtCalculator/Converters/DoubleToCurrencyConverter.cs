using Xamarin.Forms;
using System;
using System.Globalization;

namespace DebtCalculator.Shared
{ 
  class DoubleToCurrencyConverter : IValueConverter
  {
    int _previousLength = 0;

    public object Convert(object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      string valueString = value.ToString ();
      _previousLength = valueString.Length;
      string result = string.Format ("{0:C}", (double)value);
      _previousLength = result.Length;
      return string.Format ("{0:C}", (double)value);
    }

    public object ConvertBack(object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      double result = double.Parse (value.ToString (), NumberStyles.Currency);

      int newLength = value.ToString ().Length;
      if (newLength <= 4) 
      {
        result = 0.00;
      }
      else if (newLength > _previousLength) 
      {
        result *= 10.0;
      } 
      else if (newLength < _previousLength) 
      {
        result /= 10.0;
      } 

      return result;
    }
  }

  static class DoubleToCurrencyHelper
  {
    static int MAX_CURRENCY = 1000000000;

    static public string Convert(double value)
    {
      if (value < 0) 
      {
        return string.Empty;
      } 
      else 
      {
        return string.Format ("{0:C}", (double)value);
      }
    }

    static public double ConvertBack(string value, int _previousLength)
    {
      double result = 0;
      try 
      {
        result = double.Parse (value.ToString (), NumberStyles.Currency);

        int newLength = value.ToString ().Length;
        if (result != 0) {
          if (result > MAX_CURRENCY) {
            result = MAX_CURRENCY;
          } else if (newLength == 1) {
            result /= 100.0;
          } else if (newLength <= 1) {
            result = 0.00;
          } else if (newLength > _previousLength) {
            result *= 10.0;
          } else if (newLength < _previousLength) {
            result /= 10.0;
          }
        }
      } 
      catch 
      {
        result = 0;
      }

      return result;
    }
  }
}