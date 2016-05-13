using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using System.Collections.ObjectModel;
using DebtCalculatorLibrary.Business;


namespace DebtCalculator.Shared
{
  public class PaymentListPageModel : BaseViewModel
  {
    public PaymentListPageModel ()
    {
      DebtApp.Shared.PaymentManager.SnowballChanged += (sender, e) => {
        SetPropertyChanged ("Snowball");
      };
    }

    public double Snowball 
    { 
      get { return DebtApp.Shared.PaymentManager.SnowballAmount; }
      set
      {
        DebtApp.Shared.PaymentManager.SnowballAmount = value;
        SaveSnowball ();
      }
    }

    public void SaveSnowball()
    {
      InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared, null);
    }

    public ObservableCollection<SalaryEntry> Salaries { get; set; } = DebtApp.Shared.PaymentManager.SalaryEntries;

    public ObservableCollection<WindfallEntry> Windfalls { get; set; } = DebtApp.Shared.PaymentManager.WindfallEntries;
  }
}

