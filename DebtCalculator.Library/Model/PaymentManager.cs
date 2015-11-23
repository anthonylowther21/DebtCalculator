using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator.Library
{
  public class PaymentManager
  {
    private List<SalaryEntry> _salaryEntries = null;
    private List<WindfallEntry> _windfallEntries = null;
    private double _snowballAmount = Double.NaN;
    private const double inv_twelve = 1 / 12.0;

    public PaymentManager ()
    {
      _snowballAmount = 0;
      _salaryEntries = new List<SalaryEntry> ();
      _windfallEntries = new List<WindfallEntry> ();
    }

    public List<SalaryEntry> SalaryEntries
    { 
      get { return _salaryEntries; }
      set { _salaryEntries = value; }
    }

    public List<WindfallEntry> WindfallEntries
    { 
      get { return _windfallEntries; }
      set { _windfallEntries = value; }
    }

    public double SnowballAmount 
    { 
      get { return _snowballAmount; }
      set { _snowballAmount = value; }
    }

    public List<object> GetAllPayments()
    {
      return new List<object>() { new object[] { SalaryEntries, WindfallEntries, SnowballAmount } };
    }

    public void AddSalaryEntry(double startingSalary, double yearlyIncreasePercent, DateTime appliedDate)
    {
      _salaryEntries.Add(new SalaryEntry(startingSalary, yearlyIncreasePercent, appliedDate));
    }

    public void AddWindfallEntry(double amount, 
      DateTime windfallDate, 
      bool isRecurring = false, 
      int recurringFrequency = int.MinValue)
    {
      _windfallEntries.Add( new WindfallEntry(amount, windfallDate, isRecurring, recurringFrequency));
    }

    public double GetTotalMonthlySnowball (DateTime simulatedDate)
    {
      double amount = SnowballAmount;

      foreach (WindfallEntry windfallEntry in this.WindfallEntries)
      {
        int monthDifference = GetMonthDifference(simulatedDate, windfallEntry.WindfallDate);

        if (monthDifference % windfallEntry.RecurringFrequency == 0)
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

    public void UpdateSalary (SalaryEntry newItem)
    {
      var oldItem = _salaryEntries.Find(c => c.Id == newItem.Id);

      if (oldItem != null)
      {
        _salaryEntries.Remove(oldItem);
      }

      _salaryEntries.Add(newItem);
    }

    public void DeleteSalary (SalaryEntry item)
    {
      var oldItem = _salaryEntries.Find(c => c.Id == item.Id);

      if (oldItem != null)
      {
        _salaryEntries.Remove(oldItem);
      }
    }

    public void UpdateWindfall (WindfallEntry newItem)
    {
      var oldItem = _windfallEntries.Find(c => c.Id == newItem.Id);

      if (oldItem != null)
      {
        _windfallEntries.Remove(oldItem);
      }

      _windfallEntries.Add(newItem);
    }

    public void DeleteWindfall (WindfallEntry item)
    {
      var oldItem = _windfallEntries.Find(c => c.Id == item.Id);

      if (oldItem != null)
      {
        _windfallEntries.Remove(oldItem);
      }
    }

    private int GetMonthDifference(DateTime lValue, DateTime rValue)
    {
      return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
    }

    public List<SalaryEntry> CloneSalaries()
    {
      List<SalaryEntry> clones = new List<SalaryEntry>();
      foreach (var item in _salaryEntries)
      {
        clones.Add(item.Clone());
      }
      return clones;
    }

    public List<WindfallEntry> CloneWindfalls()
    {
      List<WindfallEntry> clones = new List<WindfallEntry>();
      foreach (var item in _windfallEntries)
      {
        clones.Add(item.Clone());
      }
      return clones;
    }
  }
}

