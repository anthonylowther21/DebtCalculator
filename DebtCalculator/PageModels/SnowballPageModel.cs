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
    public SnowballPageModel ()
    {
    }

    public double Snowball 
    { 
      get { return DebtApp.Shared.PaymentManager.SnowballAmount; }
      set
      {
        DebtApp.Shared.PaymentManager.SnowballAmount = value;
        SetPropertyChanged("Snowball");
      }
    }

    public void SaveSnowball()
    {
      DebtApp.Shared.PaymentManager.SnowballAmount = Snowball;
      InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
    }
  }
}

