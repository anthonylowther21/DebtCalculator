using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator.Library
{
  public class PaymentManager
  {
    private ObservableCollection<SalaryEntry> _salaryEntries = new ObservableCollection<SalaryEntry>();
    private ObservableCollection<WindfallEntry> _windfallEntries = new ObservableCollection<WindfallEntry>();
    private double _snowballAmount = 0;
    private const double inv_twelve = 1 / 12.0;

    public PaymentManager ()
    {
    }

    public ObservableCollection<SalaryEntry> SalaryEntries
    { 
      get { return _salaryEntries; }
      set { _salaryEntries = value; }
    }

    public ObservableCollection<WindfallEntry> WindfallEntries
    { 
      get { return _windfallEntries; }
      set { _windfallEntries = value; }
    }

    public double SnowballAmount 
    { 
      get { return _snowballAmount; }
      set { _snowballAmount = value; }
    }

    public double GetTotalMonthlySnowball (DateTime simulatedDate)
    {
      double amount = SnowballAmount;

      foreach (WindfallEntry windfallEntry in this.WindfallEntries)
      {
        int monthDifference = GetMonthDifference(simulatedDate, windfallEntry.WindfallDate);

        if (monthDifference == 0)
        {
          amount += windfallEntry.Amount;
        }
        else if (windfallEntry.IsRecurring && monthDifference > 0 &&
          monthDifference % windfallEntry.RecurringFrequency == 0)
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

    public void UpdateSalary (SalaryEntry item)
    {
      SalaryEntry oldItem = null;

      foreach (var entry in _salaryEntries)
      {
        if (entry.Id == item.Id)
        {
          oldItem = entry;
          break;
        }
      }

      if (oldItem != null)
      {
        _salaryEntries.Remove(oldItem);
      }

      _salaryEntries.Add(item);
    }

    public void DeleteSalary (SalaryEntry item)
    {
      SalaryEntry oldItem = null;

      foreach (var entry in _salaryEntries)
      {
        if (entry.Id == item.Id)
        {
          oldItem = entry;
        }
      }

      if (oldItem != null)
      {
        _salaryEntries.Remove(oldItem);
      }
    }

    public void UpdateWindfall (WindfallEntry item)
    {
      WindfallEntry oldItem = null;

      foreach (var entry in _windfallEntries)
      {
        if (entry.Id == item.Id)
        {
          oldItem = entry;
        }
      }

      if (oldItem != null)
      {
        _windfallEntries.Remove(oldItem);
      }

      _windfallEntries.Add(item);
    }

    public void DeleteWindfall (WindfallEntry item)
    {
      WindfallEntry oldItem = null;

      foreach (var entry in _windfallEntries)
      {
        if (entry.Id == item.Id)
        {
          oldItem = entry;
        }
      }

      if (oldItem != null)
      {
        _windfallEntries.Remove(oldItem);
      }
    }

    private int GetMonthDifference(DateTime lValue, DateTime rValue)
    {
      return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
    }

    public ObservableCollection<SalaryEntry> CloneSalaries()
    {
      ObservableCollection<SalaryEntry> clones = new ObservableCollection<SalaryEntry>();
      foreach (var item in _salaryEntries)
      {
        clones.Add(item.Clone());
      }
      return clones;
    }

    public ObservableCollection<WindfallEntry> CloneWindfalls()
    {
      ObservableCollection<WindfallEntry> clones = new ObservableCollection<WindfallEntry>();
      foreach (var item in _windfallEntries)
      {
        clones.Add(item.Clone());
      }
      return clones;
    }
  }
}

