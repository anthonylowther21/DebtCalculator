using System;
using DebtCalculator.Library;
using Xamarin.Forms;

namespace DebtCalculator.Shared
{
   public class EntryTypeToStringConverter : IValueConverter
   {
    public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      Type itemType = Type.GetType (value.ToString ());

      if (itemType == typeof(SnowballEntry))
        return "Snowball";
      else if (itemType == typeof (SalaryEntry))
        return "Salary";
      else if (itemType == typeof (WindfallEntry))
        return "Windfall";
      else
        return "";

    }

    public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new InvalidOperationException ();
    }
  }
}

