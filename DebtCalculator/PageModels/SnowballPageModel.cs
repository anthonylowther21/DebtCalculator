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
  public class SnowballPageModel : FreshBasePageModel
  {
    public SnowballPageModel ()
    {
    }

    public double Snowball { get; set; }

    public override void Init (object initData)
    {
      if (initData != null) 
      {
        Snowball = (double)initData;
      } 
      else 
      {
        Snowball = DebtApp.Shared.PaymentManager.SnowballAmount;
      }
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            DebtApp.Shared.PaymentManager.SnowballAmount = Snowball;
            InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
            CoreMethods.PopPageModel (Snowball);
          }
        );
      }
    }
  }
}

