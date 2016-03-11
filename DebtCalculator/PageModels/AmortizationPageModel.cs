using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;


namespace DebtCalculator.Shared
{
  public class AmortizationPageModel : BaseViewModel
  {
    AmortizationEntry _amortizationEntry = new AmortizationEntry();

    public AmortizationPageModel ()
    {
    }

    public void AssignAmortization(AmortizationEntry item)
    {
      if (item != null)
      {
        _amortizationEntry = item;
      }
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

