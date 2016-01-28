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
      RaisePropertyChanged("");
    }

    public override void ReverseInit(object returndData)
    {
      _amortizationEntry = ((AmortizationEntry)returndData);
    }

    public string DebtName
    { 
      get { return _amortizationEntry.DebtName; }
    }

    public string Date 
    { 
      get { return string.Format("{0:MMMM yyyy}", _amortizationEntry.Date); }
    }

    public string StartBalance 
    { 
      get { return string.Format("{0:C}",_amortizationEntry.StartBalance); }
    }

    public string MinimumInterest 
    { 
      get { return string.Format("{0:C}",_amortizationEntry.MinimumInterest); }
    }

    public string MinimumPrincipal 
    { 
      get { return string.Format("{0:C}",_amortizationEntry.MinimumPrincipal); }
    }

    public string AdditionalPrincipal 
    { 
      get { return string.Format("{0:C}",_amortizationEntry.AdditionalPrincipal); }
    }

    public string TotalPayment 
    { 
      get { return string.Format("{0:C}",_amortizationEntry.TotalPayment); }
    }

    public string EndBalance 
    { 
      get { return string.Format("{0:C}",_amortizationEntry.EndBalance); }
    }
  }
}

