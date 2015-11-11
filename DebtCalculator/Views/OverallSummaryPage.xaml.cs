using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using DebtCalculator.Library;
using DebtCalculator.Utility;

namespace DebtCalculator.Views
{
  public partial class OverallSummaryPage : ContentPage
  {
    public OverallSummaryPage()
    {
      InitializeComponent();

      Button button = new Button
        {
          Text = "Click Me!",
          Font = Font.SystemFontOfSize(NamedSize.Large),
          BorderWidth = 1,
          HorizontalOptions = LayoutOptions.Center,
          VerticalOptions = LayoutOptions.CenterAndExpand
        };
      button.Clicked += OnButtonClicked;

      Content = new StackLayout
        { 
          VerticalOptions = LayoutOptions.Center,
          Children =
            {
              new Label 
              { 
                XAlign = TextAlignment.Center,
                Text = "Hello ContentPage"
              },
              button
            }
          };
    }

    void OnButtonClicked(object sender, EventArgs e)
    {

      DebtManager debtManager = new DebtManager();
      PaymentManager paymentManager = new PaymentManager();

      //double snowballAmount = Double.Parse(snowball.Text);
      //double salary1Amount = Double.Parse(salary1.Text);
      //double salary2Amount = Double.Parse(salary2.Text);
      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 1", 23682.32, 5156.11, 2.99, 72));
      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 2", 190000, 180000, 3.25, 360));
      //      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 3", 190000, 180000, 3.25, 360));
      //      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 4", 190000, 180000, 3.25, 360));
      //      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 5", 190000, 180000, 3.25, 360));
      //      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 6", 190000, 180000, 3.25, 360));
      //      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 7", 190000, 180000, 3.25, 360));
      //      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 8", 190000, 180000, 3.25, 360));
      //      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 9", 190000, 180000, 3.25, 360));
      //      debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 10", 190000, 180000, 3.25, 360));

      paymentManager.AddSalaryEntry(70000, 0.01, new DateTime(2016, 9, 1));
      paymentManager.AddSalaryEntry(40000, 0.01, new DateTime(2016, 9, 1));
      paymentManager.SnowballAmount = 700;
      paymentManager.AddWindfallEntry(1000, new DateTime(2015, 11, 1), true, 6); 
      paymentManager.AddWindfallEntry(2000, new DateTime(2016, 3, 1), true, 12); 
      //paymentManager.AddWindfallEntry(500, new DateTime(2016, 1, 1), true, 6);

      DebtSnowballCalculator solver = new DebtSnowballCalculator();
      Collection<PaymentPlanOutputEntry> outputs =
        solver.CalculateDebtSnowball(debtManager, paymentManager);

      foreach (var output in outputs)
      {
        string message = output.DebtName +
          ": " + DateTimeExtensions.ToShortMonthName(output.Date) + " " + output.Date.Year +
          " Starting Balance: " + output.StartBalance.ToString("C") +
          " Min Interest: " + output.MinimumInterest.ToString("C") +
          " Min Principal: " + output.MinimumPrincipal.ToString("C") +
          " Add Principal: " + output.AdditionalPrincipal.ToString("C") +
          " Total Payment: " + output.TotalPayment.ToString("C") +
          " Ending Balance: " + output.EndBalance.ToString("C");

        Console.WriteLine(message);
      }

      paymentManager = null;
      debtManager = null;           
    }
  }
}

