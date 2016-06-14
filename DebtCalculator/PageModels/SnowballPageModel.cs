using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;


namespace DebtCalculator.Shared
{
  public class SnowballPageModel : BaseViewModel
  {
    SnowballEntry _snowballEntry = new SnowballEntry ();

    public SnowballPageModel ()
    {
    }

    public void AssignSnowball (SnowballEntry snowball)
    {
      if (snowball != null) {
        _snowballEntry = snowball;
      }
    }

    public string Name 
    {
      get 
      {
        return ShortStringHelper.Convert (_snowballEntry.Name);
      }
      set 
      {
        _snowballEntry.Name = ShortStringHelper.ConvertBack (value);
        SetPropertyChanged ("Name");
      }
    }

    public string Amount 
    {
      get 
      {
        return DoubleToCurrencyHelper.Convert (_snowballEntry.Amount);
      }
      set 
      {
        _snowballEntry.Amount = DoubleToCurrencyHelper.ConvertBack (value, Amount.Length);
        SetPropertyChanged ("Amount");
      }
    }

    public bool Validate (Action<string, string> callBack)
    {
      bool result = false;
      if (_snowballEntry.Name == string.Empty) 
      {
        callBack ("Snowball", "Name cannot be empty");
      } 
      else if (_snowballEntry.Amount <= 0) 
      {
        callBack ("Snowball", "Snowball amount must be greater than $0.00");
      } 
      else 
      {
        result = true;
      }
      return result;
    }

    public void Save (Action callback)
    {
      DebtApp.Shared.PaymentManager.UpdateSnowball (_snowballEntry);
      InputsFileManager.SaveInputsFileAsync (InputsFileManager.CurrentInputsFile, DebtApp.Shared, callback);
    }

    public void Delete (Action callBack)
    {
      DebtApp.Shared.PaymentManager.DeleteSnowball (_snowballEntry);
      InputsFileManager.SaveInputsFileAsync (InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }
  }
}

