using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using XLabs.Forms.Controls;

namespace DebtCalculator.Shared
{
  /// <summary>
  /// This is a sample custom implemented Navigation. It combines a MasterDetail and a TabbedPage.
  /// </summary>
  public class CustomImplementedNav : Xamarin.Forms.MasterDetailPage
  {
    CustomTabbedPage _tabbedNavigationPage;
    CustomNavigationPage _debtsPage;
    CustomNavigationPage _paymentsPage;
    CustomNavigationPage _amortizationPage;
    CustomNavigationPage _summaryPage;

    public CustomImplementedNav ()
    { 
      SetupTabbedPage ();
      CreateMenuPage (FontAwesome.FALoad);
    }

    void SetupTabbedPage()
    {
      _tabbedNavigationPage = new CustomTabbedPage ();

      _summaryPage = new CustomNavigationPage(new SummaryPage());
      _summaryPage.Title = "Summary";
      _summaryPage.TabIcon = FontAwesome.FALineChart;
      _summaryPage.SelectedTabIcon = FontAwesome.FALineChart;
      _tabbedNavigationPage.Children.Add(_summaryPage);

      _debtsPage = new CustomNavigationPage(new DebtListPage());
      _debtsPage.Title = "Debts";
      _debtsPage.TabIcon = FontAwesome.FABank;
      _debtsPage.SelectedTabIcon = FontAwesome.FABank;
      _tabbedNavigationPage.Children.Add(_debtsPage);

      _paymentsPage = new CustomNavigationPage(new PaymentListPage()); 
      _paymentsPage.Title = "Income";
      _paymentsPage.TabIcon = FontAwesome.FAMoney;
      _paymentsPage.SelectedTabIcon = FontAwesome.FAMoney;
      _tabbedNavigationPage.Children.Add(_paymentsPage);

      _amortizationPage = new CustomNavigationPage(new AmortizationListPage());
      _amortizationPage.Title = "Amortization";
      _amortizationPage.TabIcon = FontAwesome.FACalendar;
      _amortizationPage.SelectedTabIcon = FontAwesome.FACalendar;
      _tabbedNavigationPage.Children.Add(_amortizationPage);

      this.Detail = _tabbedNavigationPage;

    }

    protected void CreateMenuPage(string menuPageTitle = "Menu")
    {
      Master = new NavigationPage(new MenuPage()) { Title = menuPageTitle };
    }
  }
}

