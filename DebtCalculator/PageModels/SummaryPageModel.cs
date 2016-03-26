using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using System.Collections.Generic;
using DebtCalculatorLibrary.Services;

namespace DebtCalculator.Shared
{
  public class SummaryPageModel : BaseViewModel
  {
    private double _originalInterest = 0;
    private double _snowballInterest = 0;
    private double _savedInterest = 0;

    private DateTime _originalPayoffDate = DateTime.Now;
    private DateTime _snowballPayoffDate = DateTime.Now;

    ObservableCollection<AmortizationEntry> amortization;

    public SummaryPageModel ()
    {
    }

    public void LoadData()
    {
      if (DebtApp.Shared.DebtManager.Debts.Count > 0)
      {
        double interest = 0;
        amortization = DebtApp.Shared.Calculate(false);
        bool invalid = false;
        foreach (var entry in amortization)
        {
          if (entry.EndBalance == -9999)
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
        SetPropertyChanged("");
        //You can do stuff here
      }
    }

    public double OriginalInterest 
    {
      get 
      { 
        return _originalInterest; 
      }
    }

    public double SnowballInterest 
    {
      get 
      { 
        return _snowballInterest; 
      }
    }

    public double SavedInterest 
    {
      get 
      { 
        return _savedInterest; 
      }
    }

    public DateTime OriginalPayoffDate
    {
      get
      {
        return _originalPayoffDate;
      }
    }

    public DateTime SnowballPayoffDate
    {
      get
      {
        return _snowballPayoffDate;
      }
    }
  }
}

