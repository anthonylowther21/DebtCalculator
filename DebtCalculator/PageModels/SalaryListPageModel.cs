using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;

namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class SalaryListPageModel : FreshBasePageModel
  {
    public SalaryListPageModel ()
    {
    }

    public ObservableCollection<SalaryEntry> Salaries { get; set; }

    public override void Init (object initData)
    {
      // Binding
      Salaries = DebtApp.Shared.PaymentManager.SalaryEntries;
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      //You can do stuff here
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      SelectedSalary = null;
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
      Salaries = DebtApp.Shared.PaymentManager.SalaryEntries;
    }

    SalaryEntry _selectedSalary;

    public SalaryEntry SelectedSalary 
    {
      get 
      {
        return _selectedSalary;
      }
      set 
      {
        _selectedSalary = value;
        if (value != null)
        {
          SalarySelected.Execute(value);
        }
      }
    }

    public Command AddSalary 
    {
      get 
      {
        return new Command (async () => 
          {
            await CoreMethods.PushPageModel<SalaryPageModel> ();
          });
      }
    }

    public Command<SalaryEntry> SalarySelected 
    {
      get 
      {
        return new Command<SalaryEntry> ( (salary) => 
          {
            CoreMethods.PushPageModel<SalaryPageModel> (salary);
          });
      }
    }
  }
}

