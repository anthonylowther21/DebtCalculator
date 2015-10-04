using System;
using System.Globalization;

namespace DebtCalculator
{
  static public class DateTimeExtensions
  {
    public static string ToMonthName(DateTime dateTime)
    {
      return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
    }

    public static string ToShortMonthName(DateTime dateTime)
    {
      return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
    }
  }
}

