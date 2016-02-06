using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class SalaryPageModel : FreshBasePageModel
  {
    SalaryEntry _salary;

    public SalaryPageModel ()
    {
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
        return _salary.YearlySnowballIncreasePercent;
      }
      set
      {
        _salary.YearlySnowballIncreasePercent = value;
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
            DebtApp.Shared.PaymentManager.UpdateSalary(_salary);
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
            DebtApp.Shared.PaymentManager.DeleteSalary(_salary);
            CoreMethods.PopPageModel (_salary);
          }
        );
      }
    }
  }
}

