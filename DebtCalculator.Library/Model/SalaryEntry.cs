using System;
using PropertyChanged;

namespace DebtCalculator.Library
{
  [AddINotifyPropertyChangedInterfaceAttribute]
  public class SalaryEntry : BaseClass
  {
    private double _startingSalary = -1;
    private double _yearlyIncreasePercent = -1;
    private DateTime _appliedDate = DateTime.MinValue;

    public SalaryEntry ( string name, double startingSalary, 
                            double yearlyIncreasePercent, 
                            DateTime appliedDate)
    {
      Name = name;
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

