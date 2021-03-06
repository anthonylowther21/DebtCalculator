﻿using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;

namespace DebtCalculator.Shared
{
  public class AmortizationListPageModel : BaseViewModel
  {
    private ObservableCollection<Grouping<DateTime, AmortizationEntry>> _amortizations = null;
    private string _emptyMessage = null;

    public AmortizationListPageModel ()
    {
      DebtApp.Shared.CalculationDirtyChanged += (isDirty) => { if (isDirty) ClearPage (); };
    }

    public ObservableCollection<Grouping<DateTime, AmortizationEntry>> Amortizations 
    {
      get { return _amortizations; }
      set {
        _amortizations = value;
        SetPropertyChanged ("Amortizations");
      }
    }

    public void ClearPage ()
    {
      Amortizations = null;
      SetPropertyChanged ("Amortizations");
    }

    public void UpdateEmptyMessage ()
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
  }
}

