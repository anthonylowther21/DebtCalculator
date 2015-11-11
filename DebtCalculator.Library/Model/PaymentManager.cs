﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator.Library
{
  public class PaymentManager
  {
    private ObservableCollection<SalaryEntry> _salaryEntries = null;
    private ObservableCollection<WindfallEntry> _windfallEntries = null;
    private double _snowballAmount = Double.NaN;
    private const double inv_twelve = 1 / 12.0;

    public PaymentManager ()
    {
      _snowballAmount = 0;
      _salaryEntries = new ObservableCollection<SalaryEntry> ();
      _windfallEntries = new ObservableCollection<WindfallEntry> ();
    }

    public ObservableCollection<SalaryEntry> SalaryEntries
    { 
      get { return _salaryEntries; }
    }

    public ObservableCollection<WindfallEntry> WindfallEntries
    { 
      get { return _windfallEntries; }
    }

    public double SnowballAmount 
    { 
      get { return _snowballAmount; }
      set { _snowballAmount = value; }
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
