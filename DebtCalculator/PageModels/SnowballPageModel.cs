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
    private double _snowball = DebtApp.Shared.PaymentManager.SnowballAmount;

    public SnowballPageModel ()
    {
    }

    public string Snowball 
    { 
      get 
      { 
        return DoubleToCurrencyHelper.Convert (_snowball); 
      }
      set
      {
        _snowball = DoubleToCurrencyHelper.ConvertBack (value, Snowball.Length);
        SetPropertyChanged("Snowball");
      }
    }

    public void ClearSnowball()
    {
      _snowball = 0;
    }

    public void SaveSnowball(Action callBack)
    {
      DebtApp.Shared.PaymentManager.SnowballAmount = _snowball;
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }
  }
}

