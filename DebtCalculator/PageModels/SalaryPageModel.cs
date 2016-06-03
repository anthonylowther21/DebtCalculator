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

    public string YearlyIncreaseAppliedDate 
    { 
      get
      { 
        return DateToStringHelper.Convert(_salary.YearlyIncreaseAppliedDate);
      }
      set
      {
        _salary.YearlyIncreaseAppliedDate = DateToStringHelper.ConvertBack (value);
        SetPropertyChanged("YearlyIncreaseAppliedDate");
      }
    }

    public bool Validate(Action<string, string> callBack)
    {
      bool result = false;
      if (_salary.StartingSalary <= 0) 
      {
        callBack ("Loan Debt", "Starting Salary must be greater than $0.00");
      }
      else if (_salary.YearlyIncreaseAppliedDate == DateTime.MinValue) 
      {
        callBack ("Loan Debt", "Yearly Increase Applied Date has not been entered");
      }
      else if (_salary.YearlySnowballIncreasePercent <= 0) 
      {
        callBack ("Loan Debt", "Yearly Increase Percent must be greater than 0.000 %");
      }
      else 
      {
        result = true;
      }
      return result;
    }

    public void Save(Action callBack)
    {
      DebtApp.Shared.PaymentManager.UpdateSalary (_salary);
      InputsFileManager.SaveInputsFileAsync (InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }

    public void DeleteSalary(Action callBack)
    {
      DebtApp.Shared.PaymentManager.DeleteSalary(_salary);
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, callBack);
    }
  }
}

