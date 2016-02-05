using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class PaymentListPageModel : FreshBasePageModel
  {
    IDatabaseService _databaseService;

    public PaymentListPageModel (IDatabaseService dataService)
    {
      _databaseService = dataService;
      _databaseService.NeedsRefreshChanged += (sender, e) => Init(null);
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
        Snowball = _databaseService.GetPaymentManager().SnowballAmount;
      }
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            _databaseService.GetPaymentManager().SnowballAmount = Snowball;
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

