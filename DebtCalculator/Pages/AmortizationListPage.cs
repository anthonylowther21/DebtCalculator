using System;
using System.Collections.Generic;
using DebtCalculator.Shared;
using Xamarin.Forms;
using DebtCalculator.Library;
using DebtCalculatorLibrary.Services;

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

    private void PushAmortizationPage(AmortizationEntry item = null)
    {
      Navigation.PushAsync(new AmortizationPage(item));
    }

    protected override void OnAppearing()
    {
      this.ViewModel.Amortizations = DebtApp.Shared.Calculate(true);

      base.OnAppearing();
    }
	}

  public partial class AmortizationListPageXaml : BaseContentPage<AmortizationListPageModel>
  {
  }
}

