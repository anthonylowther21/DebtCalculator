using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using DebtCalculator.Library;
using System.Collections;

namespace DebtCalculator.Shared
{
  public class AmortizationGroupSumConverter : IValueConverter
  {
    public object Convert (object value, System.Type targetType,
                          object parameter,
                          System.Globalization.CultureInfo culture)
    {
      if (null == value)
        return "null";

      IList myList = value as IList;
      double sum = 0;

      foreach (AmortizationEntry item in myList)
        sum += item.TotalPayment;

      return string.Format ("Total Payment: {0:C}", sum);
    }

    public object ConvertBack (object value, System.Type targetType,
                              object parameter,
                              System.Globalization.CultureInfo culture)
    {
      throw new System.NotImplementedException ();
    }
  }
}

