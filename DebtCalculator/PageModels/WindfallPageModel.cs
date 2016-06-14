using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;


namespace DebtCalculator.Shared
{
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

    public string Name 
    { 
      get 
      { 
        return ShortStringHelper.Convert(_windfall.Name);
      }
      set 
      { 
        _windfall.Name = ShortStringHelper.ConvertBack (value);
        SetPropertyChanged("Name");
      }
    }

    public string Amount
    {
      get
      {
        return DoubleToCurrencyHelper.Convert (_windfall.Amount);
      }
      set
      {
        _windfall.Amount = DoubleToCurrencyHelper.ConvertBack (value, Amount.Length);
        SetPropertyChanged("Amount");
      }
    }

    public string WindfallDate
    {
      get
      {
        return  DateToStringHelper.Convert(_windfall.WindfallDate);
      }
      set
      {
        _windfall.WindfallDate = DateToStringHelper.ConvertBack (value);
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

    public string RecurringFrequency
    {
      get
      {
        return DoubleToMonthHelper.Convert(_windfall.RecurringFrequency);
      }
      set
      {
        _windfall.RecurringFrequency = DoubleToMonthHelper.ConvertBack (value);
        SetPropertyChanged("RecurringFrequency");
      }
    }

    public bool Validate(Action<string, string> callBack)
    {
      bool result = false;
      if (_windfall.Name == string.Empty) 
      {
        callBack ("Windfall", "Name cannot be empty");
      }
      else if (_windfall.Amount <= 0) 
      {
        callBack ("Windfall", "Windfall amount must be greater than $0.00");
      }
      else if (_windfall.IsRecurring && _windfall.RecurringFrequency <= 0) 
      {
        callBack ("Windfall", "Windfall recurring frequency must be greater than 0");
      }
      else if (_windfall.WindfallDate == DateTime.MinValue) 
      {
        callBack ("Windfall", "Windfall date has not been entered");
      }
      else 
      {
        result = true;
      }
      return result;
    }

    public void Save (Action callBack)
    {
      DebtApp.Shared.PaymentManager.UpdateWindfall (_windfall);
      InputsFileManager.SaveInputsFileAsync (InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }

    public void DeleteWindfall(Action callBack)
    {
      DebtApp.Shared.PaymentManager.DeleteWindfall(_windfall);
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }
  }
}

