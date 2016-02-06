﻿using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;

namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class AmortizationListPageModel : FreshBasePageModel
  {
    public AmortizationListPageModel ()
    {
    }

    public ObservableCollection<AmortizationEntry> Amortizations { get; set; }

    public override void Init (object initData)
    {
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      Amortizations = DebtApp.Shared.Calculate(true);
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      SelectedAmortization = null;
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
    }

    AmortizationEntry _selectedAmortization;

    public AmortizationEntry SelectedAmortization 
    {
      get 
      {
        return _selectedAmortization;
      }
      set 
      {
        _selectedAmortization = value;
        if (value != null)
        {
          AmortizationSelected.Execute(value);
        }
      }
    }

    public Command<AmortizationEntry> AmortizationSelected 
    {
      get 
      {
        return new Command<AmortizationEntry> ( (amortization) => 
          {
            CoreMethods.PushPageModel<AmortizationPageModel> (amortization);
          });
      }
    }
  }
}

