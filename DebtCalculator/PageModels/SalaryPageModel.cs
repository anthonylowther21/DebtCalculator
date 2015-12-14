using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class SalaryPageModel : FreshBasePageModel
  {
    IDatabaseService _dataService;
    SalaryEntry _salary;

    public SalaryPageModel (IDatabaseService dataService)
    {
      _dataService = dataService;
      _salary = new SalaryEntry();
    }

    public override void Init (object initData)
    {
      if (initData != null) 
      {
        _salary = ((SalaryEntry)initData).Clone();
        // This raises property changed for all items in this viewmodel
        RaisePropertyChanged("");
      } 
    }

    public double StartingSalary 
    { 
      get
      { 
        return _salary.StartingSalary;
      }
      set
      {
        _salary.StartingSalary = value;
      }
    }

    public double YearlySnowballIncreasePercent 
    { 
      get
      { 
        return (_salary.YearlySnowballIncreasePercent * 100);
      }
      set
      {
        _salary.YearlySnowballIncreasePercent = value * 0.01;
      }
    }

    public DateTime YearlyIncreaseAppliedDate 
    { 
      get
      { 
        return _salary.YearlyIncreaseAppliedDate;
      }
      set
      {
        _salary.YearlyIncreaseAppliedDate = value;
      }
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            _dataService.GetPaymentManager().UpdateSalary(_salary);
            CoreMethods.PopPageModel (_salary);
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
            _dataService.GetPaymentManager().DeleteSalary(_salary);
            CoreMethods.PopPageModel (_salary);
          }
        );
      }
    }
  }
}

