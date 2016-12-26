using Xamarin.Forms;
using System;

namespace DebtCalculator.Shared
{ 
  class DoubleToPercentConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      return ((double)value * 100);
    }

    public object ConvertBack(object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      double result;
      if (Double.TryParse(value.ToString(), out result))
      {
        result /= 100;
      }
      return result;
    }
  }

  static class DoubleToPercentHelper
  {
    static public string Convert(double value)
    {
      if (value < 0) 
      {
        return string.Empty;
      } 
      else 
      {
        return string.Format ("{0:0.000} %", value * 100);
      }
    }

    static public double ConvertBack(string value, int _previousLength)
    {
      if (value[value.Length - 1] == '.') return 0;

      int newLength = value.Length;
      if (value.Contains ("%")) 
      {       
        value = value.Replace (" %", "");
        newLength += 2;
      }

      double result = double.Parse (value);

      if (result > 100) 
      {
        result = 0.0;
      }
      else if (newLength == 1)
      {
        result /= 1000;
      }
      else if (newLength <= 5) 
      {
        result = 0.0;
      }
      else if (newLength > _previousLength) 
      {
        result *= 10.0;
      } 
      else if (newLength < _previousLength) 
      {
        result /= 10.0;
      } 

      result /= 100.0;

      return result;
    }
  }
}