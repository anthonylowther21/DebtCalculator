using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;


namespace DebtCalculator.Shared
{
  public class DebtPageCreditCardModel : BaseViewModel
  {
    private DebtEntry _debtEntry = new DebtEntry();

    public DebtPageCreditCardModel ()
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

    public void SaveDebt(Action callBack)
    {
      DebtApp.Shared.DebtManager.UpdateDebt(_debtEntry);
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }

    public void DeleteDebt(Action callBack)
    {
      DebtApp.Shared.DebtManager.DeleteDebt(_debtEntry);
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }
  }
}

