using System;

namespace DebtCalculator
{
  public class DoubleToMonthConverter
  {
    public DoubleToMonthConverter()
    {
    }
  }

  static class DoubleToMonthHelper
  {
    static public string Convert(double value)
    {
      return value.ToString ();
    }

    static public int ConvertBack(string value)
    {
      double result;

      if (double.TryParse (value, out result) == false) 
      {
        result = 0;
      } 
      else if (result > 1000)
      {
        result = 1000;
      }
        
      return (int)result;
    }
  }
}

