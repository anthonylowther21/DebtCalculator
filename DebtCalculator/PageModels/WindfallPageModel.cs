using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class WindfallPageModel : FreshBasePageModel
  {
    IDatabaseService _dataService;
    WindfallEntry _windfall;

    public WindfallPageModel (IDatabaseService dataService)
    {
      _dataService = dataService;
      _windfall = new WindfallEntry();
    }

    public override void Init (object initData)
    {
      if (initData != null) 
      {
        _windfall = ((WindfallEntry)initData).Clone();
        RaisePropertyChanged("");
      } 
    }

    public double Amount
    {
      get
      {
        return _windfall.Amount;
      }
      set
      {
        _windfall.Amount = value;
      }
    }

    public DateTime WindfallDate
    {
      get
      {
        return _windfall.WindfallDate;
      }
      set
      {
        _windfall.WindfallDate = value;
      }
    }

    public bool IsRecurring
    {
      get
      {
        return _windfall.IsRecurring;
      }
      set
      {
        _windfall.IsRecurring = value;
        //InvalidateRecurringFrequency();
      }
    }

    public int RecurringFrequency
    {
      get
      {
        return _windfall.RecurringFrequency;
      }
      set
      {
        _windfall.RecurringFrequency = value;
      }
    }

    private void InvalidateRecurringFrequency()
    {
      RaisePropertyChanged("RecurringFrequency");
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            _dataService.GetPaymentManager().UpdateWindfall(_windfall);
            CoreMethods.PopPageModel (_windfall);
          }
        );
      }
    }

    public Command DeleteCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            _dataService.GetPaymentManager().DeleteWindfall(_windfall);
            CoreMethods.PopPageModel (_windfall);
          }
        );
      }
    }
  }
}

