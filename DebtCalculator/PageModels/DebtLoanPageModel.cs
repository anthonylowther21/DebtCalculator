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
        return _debtEntry.Name; 
      }
      set 
      { 
        _debtEntry.Name = value; 
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

    public double CurrentBalance
    {
      get 
      { 
        return _debtEntry.CurrentBalance; 
      }
      set 
      { 
        _debtEntry.CurrentBalance = value; 
        SetPropertyChanged("CurrentBalance");
      }
    }

    public double YearlyInterestRate
    {
      get 
      { 
        return _debtEntry.YearlyInterestRate; 
      }
      set 
      { 
        _debtEntry.YearlyInterestRate = value; 
        SetPropertyChanged("YearlyInterestRate");
        InvalidateMinimumMonthlyPayment();
      }
    }

    public int LoanTerm
    {
      get 
      { 
        return _debtEntry.LoanTerm; 
      }
      set 
      { 
        _debtEntry.LoanTerm = value; 
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

//    public Command TestModal 
//    {
//      get 
//      {
//        return new Command (async () => 
//          {
//            await CoreMethods.PushPageModel<ModalPageModel> (null, true);
//          });
//      }
//    }
  }
}

