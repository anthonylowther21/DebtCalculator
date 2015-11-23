using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class PaymentListPageModel : FreshBasePageModel
  {
    IDatabaseService _dataService;

    public PaymentListPageModel (IDatabaseService dataService)
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

    public Command ShowSnowball
    {
      get
      {
        return new Command(async () =>
          {
            await CoreMethods.PushPageModel<SnowballPageModel>();
          });
      }
    }

    public Command ShowSalary
    {
      get
      {
        return new Command(async () =>
          {
            await CoreMethods.PushPageModel<SalaryListPageModel>();
          });
      }
    }

    public Command ShowWindfall
    {
      get
      {
        return new Command(async () =>
          {
            await CoreMethods.PushPageModel<WindfallListPageModel>();
          });
      }
    }
  }
}

