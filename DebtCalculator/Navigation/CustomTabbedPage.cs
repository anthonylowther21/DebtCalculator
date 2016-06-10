using System;
using Xamarin.Forms;
using DebtCalculator.Shared;
using System.Collections.Generic;

namespace DebtCalculator
{
  public class CustomTabbedPage : TabbedPage
  {
    CustomNavigationPage _debtsPage;
    CustomNavigationPage _paymentsPage;
    CustomNavigationPage _amortizationPage;
    CustomNavigationPage _summaryPage;

    public Color BarBackgroundColor { get; private set; }

    public CustomTabbedPage()
    {
      BarBackgroundColor = Colors.TabBarBackground;

      _summaryPage = new CustomNavigationPage(new SummaryPage());
      _summaryPage.Title = "Summary";
      _summaryPage.TabIcon = FontAwesome.FALineChart;
      _summaryPage.SelectedTabIcon = FontAwesome.FALineChart;
      this.Children.Add(_summaryPage);

      _debtsPage = new CustomNavigationPage(new DebtListPage());
      _debtsPage.Title = "Debts";
      _debtsPage.TabIcon = FontAwesome.FABank;
      _debtsPage.SelectedTabIcon = FontAwesome.FABank;
      this.Children.Add(_debtsPage);

      _paymentsPage = new CustomNavigationPage(new PaymentListPage()); 
      _paymentsPage.Title = "Strategy";
      _paymentsPage.TabIcon = FontAwesome.FAMoney;
      _paymentsPage.SelectedTabIcon = FontAwesome.FAMoney;
      this.Children.Add(_paymentsPage);

      _amortizationPage = new CustomNavigationPage(new AmortizationListPage());
      _amortizationPage.Title = "Amortization";
      _amortizationPage.TabIcon = FontAwesome.FACalendar;
      _amortizationPage.SelectedTabIcon = FontAwesome.FACalendar;
      this.Children.Add(_amortizationPage);
    }


  }
}

