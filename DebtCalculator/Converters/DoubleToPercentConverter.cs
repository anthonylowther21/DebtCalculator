using Xamarin.Forms;
using System;
using System.Globalization;

namespace DebtCalculator.Shared
{
  class DoubleToPercentConverter : IValueConverter
  {
    public object Convert (object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      return ((double)value * 100);
    }

    public object ConvertBack (object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      double result;
      if (Double.TryParse (value.ToString (), out result)) {
        result /= 100;
      }
      return result; //double test
    }
  }

  static class DoubleToPercentHelper
  {
    const double MAX_PERCENT = 100.0;

    static public string Convert (double value)
    {
      if (value < 0) {
        return string.Empty;
      } else {
        return string.Format ("{0:0.000}", value * 100);
      }
    }

    static public double ConvertBack (string value, int _previousLength)
    {
      double result = 0;
      try {
        result = double.Parse (value.ToString (), NumberStyles.Any);

        int newLength = value.ToString ().Length;
        if (result != 0.00) {
          if (result > MAX_PERCENT) {
            result = MAX_PERCENT;
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
      } catch {
        result = 0;
      }

      return result / 100;
    }
  }
}