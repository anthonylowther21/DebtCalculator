using System;
using System.Globalization;
using Xamarin.Forms;

namespace DebtCalculator.Shared
{
  public class IsNotNullToBoolConverter : IValueConverter
  {
    public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value != null;
    }

    public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value != null;
    }
  }

  public class IsNullToBoolConverter : IValueConverter
  {
    public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value == null;
    }

    public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value == null;
    }
  }
}

