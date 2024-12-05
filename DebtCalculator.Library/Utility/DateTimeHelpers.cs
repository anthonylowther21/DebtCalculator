using System;
using System.Globalization;

namespace DebtCalculator.Library
{
  static public class DateTimeHelpers
  {
    public static string ToMonthName(DateTime dateTime)
    {
      return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
    }

    public static string ToShortMonthName(DateTime dateTime)
    {
      return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
    }

    public static int GetMonthDifference(DateTime lValue, DateTime rValue)
    {
      return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
    }
  }
}

