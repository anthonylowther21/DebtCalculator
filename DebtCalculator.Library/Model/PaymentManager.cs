using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator.Library
{
  public class PaymentManager
  {
    private Collection<SalaryEntry> _salaryEntries = null;
    private Collection<WindfallEntry> _windfallEntries = null;
    private double _snowballAmount = Double.NaN;
    private const double inv_twelve = 1 / 12.0;

    static public PaymentManager CreatePaymentManager()
    {
      return new PaymentManager();
    }

    protected PaymentManager ()
    {
      _snowballAmount = 0;
      _salaryEntries = new Collection<SalaryEntry> ();
      _windfallEntries = new Collection<WindfallEntry> ();
    }

    public IEnumerable<SalaryEntry> SalaryEntries
    { 
      get { return _salaryEntries.ToArray(); }
    }

    public IEnumerable<WindfallEntry> WindfallEntries
    { 
      get { return _windfallEntries.ToArray(); }
    }

    public double SnowballAmount 
    { 
      get { return _snowballAmount; }
      set { _snowballAmount = value; }
    }

    public void AddSalaryEntry(double startingSalary, double yearlyIncreasePercent, DateTime appliedDate)
    {
      _salaryEntries.Add(
        SalaryEntry.CreateSalaryEntry(startingSalary, yearlyIncreasePercent, appliedDate));
    }

    public void AddWindfallEntry(double amount, 
      DateTime windfallDate, 
      bool isRecurring = false, 
      int recurringFrequency = int.MinValue)
    {
      _windfallEntries.Add(
        WindfallEntry.CreateWindfallEntry(amount, windfallDate, isRecurring, recurringFrequency));
    }

    public double GetTotalMonthlySnowball (DateTime simulatedDate)
    {
      double amount = SnowballAmount;

      foreach (WindfallEntry windfallEntry in this.WindfallEntries)
      {
        int monthDifference = GetMonthDifference(simulatedDate, windfallEntry.WindfallDate);

        if (monthDifference % windfallEntry.ReccurringFrequency == 0)
        {
          amount += windfallEntry.Amount;
        }
      }

      foreach (SalaryEntry salaryEntry in this.SalaryEntries)
      {
        double finalSalary = salaryEntry.StartingSalary;

        int monthDifference = GetMonthDifference(simulatedDate, salaryEntry.YearlyIncreaseAppliedDate);

        if (monthDifference >= 0)
        {
          int yearDiff = (int)(monthDifference * inv_twelve);
          finalSalary *= 
            Math.Pow((1.0 + salaryEntry.YearlySnowballIncreasePercent), yearDiff + 1);
        }

        amount += ((finalSalary - salaryEntry.StartingSalary) * inv_twelve);
      }

      return amount;

    }

    private int GetMonthDifference(DateTime lValue, DateTime rValue)
    {
      return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
    }
  }
}

