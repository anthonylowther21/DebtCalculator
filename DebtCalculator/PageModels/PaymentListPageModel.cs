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
    private string _emptyMessage = null;

    public PaymentListPageModel ()
    {
      this.Snowballs.CollectionChanged += (sender, e) => UpdateStrategyEntries();
      this.Salaries.CollectionChanged += (sender, e) => UpdateStrategyEntries();
      this.Windfalls.CollectionChanged += (sender, e) => UpdateStrategyEntries();

      UpdateEmptyMessage ();
    }

    public ObservableCollection<SnowballEntry> Snowballs { get; set; } = DebtApp.Shared.PaymentManager.SnowballEntries;

    public ObservableCollection<SalaryEntry> Salaries { get; set; } = DebtApp.Shared.PaymentManager.SalaryEntries;

    public ObservableCollection<WindfallEntry> Windfalls { get; set; } = DebtApp.Shared.PaymentManager.WindfallEntries;

    public ObservableCollection<BaseClass> AllEntries { get; private set; }

    public ObservableCollection<Grouping<Type, BaseClass>> GroupedItems { get; set; }

    private void UpdateEmptyMessage ()
    {
      if (this.AllEntries != null && this.AllEntries.Count > 0)
        EmptyMessage = null;
      else
        EmptyMessage = "Click the add button in the top-right of the screen to get started!";
    }

    public string EmptyMessage {
      get {
        return _emptyMessage;
      }
      set {
        _emptyMessage = value;
        SetPropertyChanged ("EmptyMessage");
      }
    }

    public void UpdateStrategyEntries ()
    {
      AllEntries = new ObservableCollection<BaseClass> ();
      foreach (var item in Snowballs)
        AllEntries.Add (item);

      foreach (var item in Salaries)
        AllEntries.Add (item);

      foreach (var item in Windfalls)
        AllEntries.Add (item);

      // This must get called after all entries have been updated
      UpdateEmptyMessage ();

      var grouped = from item in AllEntries
        group item by item.GetType() into itemGroup
                          select new Grouping<Type, BaseClass> (itemGroup.Key, itemGroup);

      GroupedItems = new ObservableCollection<Grouping<Type, BaseClass>> (grouped);
    }
  }
}

