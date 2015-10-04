using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using DebtCalculator.Library;

namespace DebtCalculator
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};

            DebtManager debtManager = DebtManager.CreateDebtManager();
            PaymentManager paymentManager = PaymentManager.CreatePaymentManager();

            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 1", 25000, 5000, 2.99, 60));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 2", 190000, 180000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 3", 190000, 180000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 4", 190000, 180000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 5", 190000, 180000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 6", 190000, 180000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 7", 190000, 180000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 8", 190000, 180000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 9", 190000, 180000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 10", 190000, 180000, 3.25, 360));

            paymentManager.AddSalaryEntry(70000, 0.01, new DateTime(2016, 9, 1));
            paymentManager.AddSalaryEntry(40000, 0.01, new DateTime(2016, 9, 1));
            paymentManager.SetSnowballAmount(860);
            paymentManager.AddWindfallEntry(500, new DateTime(2016, 1, 1), true, 6); 
            paymentManager.AddWindfallEntry(500, new DateTime(2016, 1, 1), true, 6);

            Collection<PaymentPlanOutputEntry> outputs =
            DebtSnowballCalculator.CalculateDebtSnowball(debtManager, paymentManager);	

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

