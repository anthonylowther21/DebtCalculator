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
}