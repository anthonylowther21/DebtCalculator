using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;


namespace DebtCalculator.Shared
{
  [ImplementPropertyChanged]
  public class WindfallPageModel : BaseViewModel
  {
    WindfallEntry _windfall = new WindfallEntry();

    public WindfallPageModel ()
    {
    }

    public void AssignWindfall(WindfallEntry windfall)
    {
      if (windfall != null)
      {
        _windfall = windfall;
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
        SetPropertyChanged("Amount");
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
        SetPropertyChanged("WindfallDate");
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
        SetPropertyChanged("IsRecurring");
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
        SetPropertyChanged("RecurringFrequency");
      }
    }

    public void SaveWindfall()
    {
      DebtApp.Shared.PaymentManager.UpdateWindfall(_windfall);
      InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
    }

    public void DeleteWindfall()
    {
      DebtApp.Shared.PaymentManager.DeleteWindfall(_windfall);
      InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
    }
  }
}

