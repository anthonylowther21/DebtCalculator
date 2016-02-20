using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class DebtPageModel : FreshBasePageModel
  {
    DebtEntry _debtEntry;

    public DebtPageModel ()
    {
      _debtEntry = new DebtEntry();
    }

    public override void Init (object initData)
    {
      if (initData != null) 
      {
        _debtEntry = ((DebtEntry)initData).Clone();
        RaisePropertyChanged("");
      } 
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      _debtEntry.CancelEdit();
      base.ViewIsDisappearing(sender, e);
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
      }
    }

    public double StartingBalance
    {
      get 
      { 
        return _debtEntry.StartingBalance; 
      }
      set 
      { 
        _debtEntry.StartingBalance = value; 
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
      RaisePropertyChanged("MinimumMonthlyPayment");
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            DebtApp.Shared.DebtManager.UpdateDebt(_debtEntry);
            InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
            CoreMethods.PopPageModel (_debtEntry);
          }
        );
      }
    }

    public Command DeleteCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            DebtApp.Shared.DebtManager.DeleteDebt(_debtEntry);
            InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
            CoreMethods.PopPageModel (_debtEntry);
          }
        );
      }
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

