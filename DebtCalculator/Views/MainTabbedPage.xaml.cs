using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DebtCalculator.Views
{
  public partial class MainTabbedPage : TabbedPage
  {
    public MainTabbedPage()
    {
      InitializeComponent();

      //this.Title = "Debt Calculator";
      this.Children.Add(new OverallSummaryPage());
      this.Children.Add(new DebtsPage());
      this.Children.Add(new PaymentsPage());
      this.Children.Add(new AmortizationPage());

    }
  }
}

