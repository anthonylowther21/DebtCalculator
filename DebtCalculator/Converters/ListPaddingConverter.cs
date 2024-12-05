using Xamarin.Forms;
using System;
using System.Globalization;

namespace DebtCalculator.Shared
{ 
  public class ListPaddingConverter : IValueConverter
  {
    public static ListPaddingConverter Instance = new ListPaddingConverter ();

    public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
    {
      var isLast = (bool)value;
      return isLast ? 
        new Thickness (14) : 
        new Thickness (14, 14, 14, 0);
    }

    public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
    {
      return null;
    }
  }
}