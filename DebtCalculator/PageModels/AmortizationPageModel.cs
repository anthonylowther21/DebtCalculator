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

    public AmortizationEntry AmortizationEntry { get; set; }

    public override void Init (object initData)
    {
      AmortizationEntry = ((AmortizationEntry)initData);
    }

    public override void ReverseInit(object returndData)
    {
      AmortizationEntry = ((AmortizationEntry)returndData);
      base.ReverseInit(returndData);
    }
  }
}

