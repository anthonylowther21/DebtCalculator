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
  public class WindfallPageModel : FreshBasePageModel
  {
    WindfallEntry _windfall;

    public WindfallPageModel ()
    {
      _windfall = new WindfallEntry();
    }

    public override void Init (object initData)
    {
      if (initData != null) 
      {
        _windfall = ((WindfallEntry)initData).Clone();
        RaisePropertyChanged("");
      } 
    }

    public double Amount
    {
      get
      {
        return _windfall.Amount;
      }
      set
      {
        _windfall.Amount = value;
      }
    }

    public DateTime WindfallDate
    {
      get
      {
        return _windfall.WindfallDate;
      }
      set
      {
        _windfall.WindfallDate = value;
      }
    }

    public bool IsRecurring
    {
      get
      {
        return _windfall.IsRecurring;
      }
      set
      {
        _windfall.IsRecurring = value;
      }
    }

    public int RecurringFrequency
    {
      get
      {
        return _windfall.RecurringFrequency;
      }
      set
      {
        _windfall.RecurringFrequency = value;
      }
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            DebtApp.Shared.PaymentManager.UpdateWindfall(_windfall);
            InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
            CoreMethods.PopPageModel (_windfall);
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
            DebtApp.Shared.PaymentManager.DeleteWindfall(_windfall);
            InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
            CoreMethods.PopPageModel (_windfall);
          }
        );
      }
    }
  }
}

