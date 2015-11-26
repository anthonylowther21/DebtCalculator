using System;

namespace DebtCalculator.Converters
{
  public class PercentToDoubleConverter
  {
    double inv_100 = 1.0 / 100.0;

    public PercentToDoubleConverter()
    {
    }

    public double ConvertTo(double percent)
    {
      return percent * inv_100;
    }

    public double ConvertFrom(double number)
    {
      return number * 100;
    }
  }
}

