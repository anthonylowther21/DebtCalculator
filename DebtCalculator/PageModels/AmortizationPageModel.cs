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
    AmortizationEntry _amortizationEntry;

    public AmortizationPageModel (IDatabaseService dataService)
    {
      _dataService = dataService;
      _amortizationEntry = new AmortizationEntry();
    }

    public override void Init (object initData)
    {
      _amortizationEntry = ((AmortizationEntry)initData);
    }

    public override void ReverseInit(object returndData)
    {
      _amortizationEntry = ((AmortizationEntry)returndData);
    }

    public string DebtName
    { 
      get { return _amortizationEntry.DebtName; }
    }

    public DateTime Date 
    { 
      get { return _amortizationEntry.Date; }
    }

    public double StartBalance 
    { 
      get { return _amortizationEntry.StartBalance; }
    }

    public double MinimumInterest 
    { 
      get { return _amortizationEntry.MinimumInterest; }
    }

    public double MinimumPrincipal 
    { 
      get { return _amortizationEntry.MinimumPrincipal; }
    }

    public double AdditionalPrincipal 
    { 
      get { return _amortizationEntry.AdditionalPrincipal; }
    }

    public double TotalPayment 
    { 
      get { return _amortizationEntry.TotalPayment; }
    }

    public double EndBalance 
    { 
      get { return _amortizationEntry.EndBalance; }
    }
  }
}

