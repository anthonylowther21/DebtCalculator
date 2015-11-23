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

    public SalaryPageModel (IDatabaseService dataService)
    {
      _dataService = dataService;
    }

    public SalaryEntry Salary { get; set; }

    public override void Init (object initData)
    {
      if (initData != null) 
      {
        Salary = ((SalaryEntry)initData).Clone();
      } 
      else 
      {
        Salary = new SalaryEntry ();
      }
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            _dataService.GetPaymentManager().UpdateSalary(Salary);
            CoreMethods.PopPageModel (Salary);
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
            _dataService.GetPaymentManager().DeleteSalary(Salary);
            CoreMethods.PopPageModel (Salary);
          }
        );
      }
    }
  }
}

