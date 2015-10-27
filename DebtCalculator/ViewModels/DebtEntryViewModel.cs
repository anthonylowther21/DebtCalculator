using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using GalaSoft.MvvmLight;

namespace DebtCalculator.ViewModels
{
  public class DebtEntryViewModel : ViewModelBase
  {
    INavigation _navigation = null;
    DebtEntry _debtEntry = null;

    public DebtEntryViewModel(INavigation navigation, DebtEntry debtEntry)
    {
      _navigation = navigation;
      _debtEntry = debtEntry;
    }

    public string Name
    {
      get { return _debtEntry.Name; }
      set
      {
        _debtEntry.Name = value;
        RaisePropertyChanged("Name");
      }
    }

    public double StartingBalance
    {
      get { return _debtEntry.StartingBalance; }
      set 
      { 
        _debtEntry.StartingBalance = value; 
        RaisePropertyChanged("StartingBalance");
      }
    }

    public double CurrentBalance
    {
      get { return _debtEntry.CurrentBalance; }
      set 
      { 
        _debtEntry.CurrentBalance = value; 
        RaisePropertyChanged("CurrentBalance");
      }
    }

    public double YearlyInterestRate
    {
      get { return _debtEntry.YearlyInterestRate; }
      set 
      { 
        _debtEntry.YearlyInterestRate = value; 
        RaisePropertyChanged("YearlyInterestRate");
      }
    }

    public int LoanTerm
    {
      get { return _debtEntry.LoanTerm; }
      set 
      { 
        _debtEntry.LoanTerm = value; 
        RaisePropertyChanged("LoanTerm");
      }
    }


  }
}

