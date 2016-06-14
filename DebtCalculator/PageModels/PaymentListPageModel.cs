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
      this.Snowballs.CollectionChanged += (sender, e) => UpdateStrategyEntries();
      this.Salaries.CollectionChanged += (sender, e) => UpdateStrategyEntries();
      this.Windfalls.CollectionChanged += (sender, e) => UpdateStrategyEntries();
    }

    public ObservableCollection<SnowballEntry> Snowballs { get; set; } = DebtApp.Shared.PaymentManager.SnowballEntries;

    public ObservableCollection<SalaryEntry> Salaries { get; set; } = DebtApp.Shared.PaymentManager.SalaryEntries;

    public ObservableCollection<WindfallEntry> Windfalls { get; set; } = DebtApp.Shared.PaymentManager.WindfallEntries;

    public ObservableCollection<object> StrategyEntries { get; private set; }

    public void UpdateStrategyEntries ()
    {
      StrategyEntries = new ObservableCollection<object> ();
      foreach (var item in Snowballs)
        StrategyEntries.Add (item);

      foreach (var item in Salaries)
        StrategyEntries.Add (item);

      foreach (var item in Windfalls)
        StrategyEntries.Add (item);
    }
  }
}

