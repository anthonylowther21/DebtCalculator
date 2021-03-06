﻿using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using System.Collections.Generic;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;
using System.IO;

namespace DebtCalculator.Shared
{
  public class SummaryPageModel : BaseViewModel
  {
    private double _originalInterest = 0;
    private double _snowballInterest = 0;
    private double _savedInterest = 0;
    private int _monthsSaved = 0;
    private double _totalDebt = 0;
    private string _emptyMessage = null;

    private DateTime _originalPayoffDate = DateTime.Now;
    private DateTime _snowballPayoffDate = DateTime.Now;

    ObservableCollection<AmortizationEntry> amortization;

    public SummaryPageModel ()
    {
      DebtApp.Shared.CalculationDirtyChanged += (isDirty) => { if (isDirty) ClearData (); };
    }

    private void UpdateEmptyMessage ()
    {
      if (DebtApp.Shared.DebtManager.Debts.Count > 0)
        EmptyMessage = null;
      else
        EmptyMessage = "Go to the Debts page to get started!";
    }

    public string EmptyMessage {
      get {
        return _emptyMessage;
      }
      set {
        _emptyMessage = value;
        SetPropertyChanged ("EmptyMessage");
      }
    }

    public void LoadData()
    {
      UpdateEmptyMessage ();

      if (DebtApp.Shared.DebtManager.Debts.Count > 0)
      {
        _totalDebt = 0;
        foreach (var item in DebtApp.Shared.DebtManager.Debts) 
        {
          _totalDebt += item.CurrentBalance;
        }

        double interest = 0;
        amortization = DebtApp.Shared.Calculate(false);
        bool invalid = false;
        foreach (var entry in amortization)
        {
          if (entry.EndBalance == -9999.00)
          {
            invalid = true;
            break;
          }
          interest += entry.MinimumInterest;
        }

        if (invalid)
        {
          _originalInterest = double.MaxValue;
          _originalPayoffDate = DateTime.MaxValue;
        }
        else
        {
          _originalInterest = interest;
          _originalPayoffDate = amortization[amortization.Count - 1].Date;
        }

        interest = 0;
        amortization = DebtApp.Shared.Calculate(true);
        foreach (var entry in amortization)
        {
          interest += entry.MinimumInterest;
        }
        _snowballInterest = interest;
        _snowballPayoffDate = amortization[amortization.Count - 1].Date;

        _savedInterest = _originalInterest - _snowballInterest;


        _monthsSaved = DateTimeHelpers.GetMonthDifference (_originalPayoffDate, _snowballPayoffDate);

        SetPropertyChanged("");
        DebtApp.Shared.CalculationIsDirty = false;
        //You can do stuff here
      }
    }

    public void ClearData ()
    {
      _totalDebt = -1;
      _snowballInterest = -1;
      _savedInterest = -1;
      _snowballPayoffDate = DateTime.MinValue;
      _originalPayoffDate = DateTime.MinValue;
      _monthsSaved = -1;
      SetPropertyChanged ("");
    }

    public string ScenarioName 
    {
      get 
      {
        return ShortStringHelper.Convert(Path.GetFileName(InputsFileManager.CurrentInputsFile));
      }
    }

    public string TotalDebt
    {
      get 
      {
        return DoubleToCurrencyHelper.Convert(_totalDebt); 
      }
    }

    public string InterestPaid 
    {
      get 
      {
        return DoubleToCurrencyHelper.Convert (_snowballInterest);
      }
    }

    public string SavedInterest 
    {
      get 
      { 
        return DoubleToCurrencyHelper.Convert(_savedInterest); 
      }
    }

    public string SnowballPayoffDate
    {
      get
      {
        if (_snowballPayoffDate == DateTime.MinValue)
        {
          return string.Empty;
        }
        else
        {
          return string.Format ("{0:MMMM yyyy}", _snowballPayoffDate);
        }
      }
    }

    public string MonthsSaved
    {
      get 
      {
        if (_monthsSaved < 0)
        {
          return string.Empty; 
        }
        else
        {
        int years = _monthsSaved / 12;
        int months = _monthsSaved % 12;
        return string.Format ("{0} years\n {1} months", years, months);
        }
      }
    }
  }
}

