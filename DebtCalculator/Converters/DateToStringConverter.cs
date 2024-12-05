using System;

namespace DebtCalculator
{
  public class DateToStringConverter
  {
    public DateToStringConverter()
    {
    }
  }

  static class DateToStringHelper
  {
    static public string Convert(DateTime value)
    {
      if (value == DateTime.MinValue) 
      {
        return string.Format("{0:MMMM yyyy}", DateTime.Now);
      } 
      else 
      {
        return string.Format("{0:MMMM yyyy}", value);
      }
    }

    static public DateTime ConvertBack(string value)
    {
      DateTime result;
      DateTime.TryParse (value, out result);
      return result;
    }
  }
}

