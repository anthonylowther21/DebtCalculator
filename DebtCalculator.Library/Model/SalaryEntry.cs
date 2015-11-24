using System;
using PropertyChanged;

namespace DebtCalculator.Library
{
  [ImplementPropertyChanged]
  public class SalaryEntry : BaseClass
  {
    private double _startingSalary = 40000;
    private double _yearlyIncreasePercent = 0.01;
    private DateTime _appliedDate = DateTime.Now;

    public SalaryEntry ( double startingSalary, 
                            double yearlyIncreasePercent, 
                            DateTime appliedDate)
    {
      StartingSalary = startingSalary;
      YearlySnowballIncreasePercent = yearlyIncreasePercent;
      YearlyIncreaseAppliedDate = appliedDate;
    }

    public SalaryEntry()
    {
    }

    public new SalaryEntry Clone()
    {
      return (SalaryEntry)base.Clone();
    }

    public double StartingSalary 
    { 
      get
      { 
        return _startingSalary;
      }
      set
      {
        _startingSalary = value;
      }
    }

    public double YearlySnowballIncreasePercent 
    { 
      get
      { 
        return (_yearlyIncreasePercent);
      }
      set
      {
        _yearlyIncreasePercent = value;
      }
    }

    public DateTime YearlyIncreaseAppliedDate 
    { 
      get
      { 
        return _appliedDate;
      }
      set
      {
        _appliedDate = value;
      }
    }
  }
}

