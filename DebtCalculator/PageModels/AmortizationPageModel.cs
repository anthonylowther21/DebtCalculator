using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class AmortizationPageModel : FreshBasePageModel
  {
    IDatabaseService _dataService;

    public AmortizationPageModel (IDatabaseService dataService)
    {
      _dataService = dataService;
    }

    public PaymentPlanOutputEntry AmortizationEntry { get; set; }

    public override void Init (object initData)
    {
      AmortizationEntry = ((PaymentPlanOutputEntry)initData);
    }

    public override void ReverseInit(object returndData)
    {
      AmortizationEntry = ((PaymentPlanOutputEntry)returndData);
      base.ReverseInit(returndData);
    }
  }
}

