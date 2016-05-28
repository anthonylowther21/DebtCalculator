using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;


namespace DebtCalculator.Shared
{
  public class SalaryPageModel : BaseViewModel
  {
    SalaryEntry _salary = new SalaryEntry();

    public SalaryPageModel ()
    {
    }

    public void AssignSalary(SalaryEntry salary)
    {
      if (salary != null)
      {
        _salary = salary;
      }
    }

    public string StartingSalary 
    { 
      get
      { 
        return DoubleToCurrencyHelper.Convert(_salary.StartingSalary);
      }
      set
      {
        _salary.StartingSalary = DoubleToCurrencyHelper.ConvertBack (value, StartingSalary.Length);
        SetPropertyChanged("StartingSalary");
      }
    }

    public string YearlySnowballIncreasePercent 
    { 
      get
      { 
        return DoubleToPercentHelper.Convert (_salary.YearlySnowballIncreasePercent);
      }
      set
      {
        _salary.YearlySnowballIncreasePercent = DoubleToPercentHelper.ConvertBack (value, YearlySnowballIncreasePercent.Length);
        SetPropertyChanged("YearlySnowballIncreasePercent");
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
        SetPropertyChanged("YearlyIncreaseAppliedDate");
      }
    }

    public void SaveSalary(Action callBack)
    {
      DebtApp.Shared.PaymentManager.UpdateSalary(_salary);
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }

    public void DeleteSalary(Action callBack)
    {
      DebtApp.Shared.PaymentManager.DeleteSalary(_salary);
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }
  }
}

