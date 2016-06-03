using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;


namespace DebtCalculator.Shared
{
  public class DebtLoanPageModel : BaseViewModel
  {
    private DebtEntry _debtEntry = new DebtEntry();

    public DebtLoanPageModel ()
    {
    }

    public void AssignDebt(DebtEntry debt)
    {
      if (debt != null)
      {
        _debtEntry = debt;
      }
    }

    public string Name 
    { 
      get 
      { 
        return ShortStringHelper.Convert(_debtEntry.Name);
      }
      set 
      { 
        _debtEntry.Name = ShortStringHelper.ConvertBack (value);
        SetPropertyChanged("Name");
      }
    }

    public string StartingBalance
    {
      get 
      {
        return DoubleToCurrencyHelper.Convert (_debtEntry.StartingBalance);
      }
      set 
      {         
        _debtEntry.StartingBalance = DoubleToCurrencyHelper.ConvertBack (value, StartingBalance.Length);
        SetPropertyChanged("StartingBalance");
        InvalidateMinimumMonthlyPayment();
      }
    }

    public string CurrentBalance
    {
      get 
      { 
        return DoubleToCurrencyHelper.Convert (_debtEntry.CurrentBalance);
      }
      set 
      { 
        _debtEntry.CurrentBalance = DoubleToCurrencyHelper.ConvertBack (value, CurrentBalance.Length);
        SetPropertyChanged("CurrentBalance");
      }
    }

    public string YearlyInterestRate
    {
      get 
      { 
        return DoubleToPercentHelper.Convert (_debtEntry.YearlyInterestRate);
      }
      set 
      { 
        _debtEntry.YearlyInterestRate = DoubleToPercentHelper.ConvertBack (value, YearlyInterestRate.Length);
        SetPropertyChanged("YearlyInterestRate");
        InvalidateMinimumMonthlyPayment();
      }
    }

    public string LoanTerm
    {
      get 
      { 
        return DoubleToMonthHelper.Convert (_debtEntry.LoanTerm);
      }
      set 
      { 
        _debtEntry.LoanTerm = DoubleToMonthHelper.ConvertBack (value);
        SetPropertyChanged("LoanTerm");
        InvalidateMinimumMonthlyPayment();
      }
    }

    public double MinimumMonthlyPayment
    {
      get 
      { 
        return _debtEntry.MinimumMonthlyPayment;
      }
    }

    public void InvalidateMinimumMonthlyPayment()
    {
      SetPropertyChanged("MinimumMonthlyPayment");
    }

    public bool Validate(Action<string, string> callBack)
    {
      bool result = false;
      if (_debtEntry.CurrentBalance <= 0) 
      {
        callBack ("Loan Debt", "Current Balance must be greater than $0.00");
      }
      else if (_debtEntry.LoanTerm <= 0) 
      {
        callBack ("Loan Debt", "Loan Term must be greater than 0 months");
      }
      else if (_debtEntry.Name == string.Empty) 
      {
        callBack ("Loan Debt", "Debt Name cannot be empty");
      }
      else if (_debtEntry.StartingBalance <= 0) 
      {
        callBack ("Loan Debt", "Starting Balance must be greater than $0.00");
      }
      else if (_debtEntry.YearlyInterestRate <= 0) 
      {
        callBack ("Loan Debt", "Yearly Interest Rate must be greater than 0.000 %");
      }
      else 
      {
        result = true;
      }
      return result;
    }

    public void Save(Action callBack)
    {
      DebtApp.Shared.DebtManager.UpdateDebt (_debtEntry);
      InputsFileManager.SaveInputsFileAsync (InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }

    public void DeleteDebt(Action callBack)
    {
      DebtApp.Shared.DebtManager.DeleteDebt(_debtEntry);
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }
  }
}

