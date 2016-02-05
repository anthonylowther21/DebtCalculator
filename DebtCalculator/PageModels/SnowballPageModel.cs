using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class SnowballPageModel : FreshBasePageModel
  {
    IDatabaseService _dataService;

    public SnowballPageModel (IDatabaseService dataService)
    {
      _dataService = dataService;
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
        Snowball = _dataService.GetPaymentManager().SnowballAmount;
      }
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            _dataService.GetPaymentManager().SnowballAmount = Snowball;
            CoreMethods.PopPageModel (Snowball);
          }
        );
      }
    }
  }
}

