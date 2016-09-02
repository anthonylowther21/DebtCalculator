using System;
using System.Collections.Generic;
using DebtCalculator.Shared;
using Xamarin.Forms;
using DebtCalculator.Library;
using DebtCalculatorLibrary.Services;
using System.Linq;
using System.Collections.ObjectModel;

namespace DebtCalculator.Shared
{
  public partial class AmortizationListPage : AmortizationListPageXaml
	{
    public AmortizationListPage ()
		{
			InitializeComponent ();
		}

    public void Item_Selected(object sender, ItemTappedEventArgs e)
    {
      var listView = sender as ListView;
      listView.SelectedItem = null;
      this.PushAmortizationPage(e.Item as AmortizationEntry);
    }

    public void Menu_Button_Clicked(object sender, EventArgs e)
    {
      this.Navigation.PushModalAsync (new CustomNavigationPage(new MenuPage ()));
    }

    private void PushAmortizationPage(AmortizationEntry item = null)
    {
      Navigation.PushAsync(new AmortizationPage(item));
    }

    protected override void OnAppearing()
    {
      if (DebtApp.Shared.DebtManager.Debts.Count > 0) 
      {
        //Use linq to sorty our monkeys by name and then group them by the new name sort property
        var grouped = from item in DebtApp.Shared.Calculate (true)
                      group item by item.Date into itemGroup
                      select new Grouping<DateTime, AmortizationEntry> (itemGroup.Key, itemGroup);

        this.ViewModel.Amortizations = new ObservableCollection<Grouping<DateTime, AmortizationEntry>> (grouped);
      }

      this.ViewModel.UpdateEmptyMessage ();

      if (this.ViewModel.EmptyMessage == null)
        this.Content = _listView;
      else
        this.Content = _emptyMessageLayout;

      base.OnAppearing();
    }
	}

  public partial class AmortizationListPageXaml : BaseContentPage<AmortizationListPageModel>
  {
  }
}

