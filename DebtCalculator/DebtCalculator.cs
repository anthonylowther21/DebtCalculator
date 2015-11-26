using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using DebtCalculator.Library;
using DebtCalculator.Utility;

namespace DebtCalculator
{
  public class App2 : Application
  {
    Label finishDate;
    Entry salary1;
    Entry salary2;
    Entry snowball;

    public App2 ()
    {
      Button button = new Button
        {
          Text = "Click Me!",
          Font = Font.SystemFontOfSize(NamedSize.Large),
          BorderWidth = 1,
          HorizontalOptions = LayoutOptions.Center,
          VerticalOptions = LayoutOptions.CenterAndExpand
        };
      button.Clicked += OnButtonClicked;

      finishDate = new Label
        {
          Text = "Finish Date",
          HorizontalOptions = LayoutOptions.Center,
          VerticalOptions = LayoutOptions.CenterAndExpand
        };

      salary1 = new Entry
        {
          Placeholder="Enter Salary 1 Here",
          HorizontalOptions = LayoutOptions.Center,
          VerticalOptions = LayoutOptions.CenterAndExpand
        };

      salary2 = new Entry
        {
          Placeholder="Enter Salary 1 Here",
          HorizontalOptions = LayoutOptions.Center,
          VerticalOptions = LayoutOptions.CenterAndExpand
        };

      snowball = new Entry
        {
          Placeholder="Enter Snowball Here",
          HorizontalOptions = LayoutOptions.Center,
          VerticalOptions = LayoutOptions.CenterAndExpand
        };

      // The root page of your application
      MainPage = new ContentPage {
        Content = new StackLayout 
          {
            VerticalOptions = LayoutOptions.Center,
            Children = {
              salary1,
              salary2,
              snowball,
              button,
              finishDate
            }
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
      debtManager.UpdateDebt(new DebtEntry("Debt 1", 23682.32, 5156.11, 2.99, 72));
      debtManager.UpdateDebt(new DebtEntry("Debt 2", 190000, 180000, 3.25, 360));
//      debtManager.UpdateDebt(new DebtEntry("Debt 3", 190000, 180000, 3.25, 360));
//      debtManager.UpdateDebt(new DebtEntry("Debt 4", 190000, 180000, 3.25, 360));
//      debtManager.UpdateDebt(new DebtEntry("Debt 5", 190000, 180000, 3.25, 360));
//      debtManager.UpdateDebt(new DebtEntry("Debt 6", 190000, 180000, 3.25, 360));
//      debtManager.UpdateDebt(new DebtEntry("Debt 7", 190000, 180000, 3.25, 360));
//      debtManager.UpdateDebt(new DebtEntry("Debt 8", 190000, 180000, 3.25, 360));
//      debtManager.UpdateDebt(new DebtEntry("Debt 9", 190000, 180000, 3.25, 360));
//      debtManager.UpdateDebt(new DebtEntry("Debt 10", 190000, 180000, 3.25, 360));
//
      paymentManager.AddSalaryEntry(70000, 0.03, new DateTime(2016, 9, 1));
      //paymentManager.AddSalaryEntry(40000, 0.03, new DateTime(2016, 9, 1));
      //paymentManager.SetSnowballAmount(1200);
      //paymentManager.AddWindfallEntry(1500, new DateTime(2015, 11, 1)); 
      //paymentManager.AddWindfallEntry(2000, new DateTime(2016, 3, 1), true, 12); 
      //paymentManager.AddWindfallEntry(500, new DateTime(2016, 1, 1), true, 6);

      DebtSnowballCalculator solver = new DebtSnowballCalculator();
      Collection<AmortizationEntry> outputs =
        solver.CalculateDebtSnowball(debtManager, paymentManager, true);
          

      finishDate.Text = outputs[outputs.Count - 1].Date.ToShortDateString();

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

    protected override void OnStart ()
    {
      // Handle when your app starts
    }

    protected override void OnSleep ()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume ()
    {
      // Handle when your app resumes
    }
  }
}

