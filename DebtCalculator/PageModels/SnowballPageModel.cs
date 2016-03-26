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

    public double Snowball 
    { 
      get { return _snowball; }
      set
      {
        _snowball = value;
        SetPropertyChanged("Snowball");
      }
    }

    public void SaveSnowball(Action callBack)
    {
      DebtApp.Shared.PaymentManager.SnowballAmount = Snowball;
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }
  }
}

