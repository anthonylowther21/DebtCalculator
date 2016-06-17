using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using System.Collections.ObjectModel;
using DebtCalculatorLibrary.Business;
using System.Linq;

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

    public ObservableCollection<BaseClass> AllEntries { get; private set; }

    public ObservableCollection<Grouping<Type, BaseClass>> GroupedItems { get; set; }

    public void UpdateStrategyEntries ()
    {
      AllEntries = new ObservableCollection<BaseClass> ();
      foreach (var item in Snowballs)
        AllEntries.Add (item);

      foreach (var item in Salaries)
        AllEntries.Add (item);

      foreach (var item in Windfalls)
        AllEntries.Add (item);

      var grouped = from item in AllEntries
        group item by item.GetType() into itemGroup
                          select new Grouping<Type, BaseClass> (itemGroup.Key, itemGroup);

      GroupedItems = new ObservableCollection<Grouping<Type, BaseClass>> (grouped);
    }
  }
}

