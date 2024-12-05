using System;

namespace DebtCalculator
{
  static class StringToDoubleConverter
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
        
      return (int)result;
    }
  }
}

