using System;

namespace DebtCalculator.Library
{
  public class SalaryEntry
  {
    public SalaryEntry ( double startingSalary, 
                            double yearlyIncreasePercent, 
                            DateTime appliedDate)
    {
      StartingSalary = startingSalary;
      YearlySnowballIncreasePercent = yearlyIncreasePercent;
      YearlyIncreaseAppliedDate = appliedDate;
    }

    public double StartingSalary { get; private set; }
    public double YearlySnowballIncreasePercent { get; private set; }
    public DateTime YearlyIncreaseAppliedDate { get; private set; }
  }
}

