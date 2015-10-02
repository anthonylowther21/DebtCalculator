using System;

using Xamarin.Forms;

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

            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 1", 25000, 25000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 2", 32000, 32000, 3.25, 360));

            paymentManager.AddSalaryEntry(70000, 0.02, new DateTime(2015, 12, 1));
            paymentManager.SetSnowballAmount(860);
            paymentManager.AddWindfallEntry(1000, DateTime.Now, true, 6);
                


            DebtSnowballCalculator.CalculateDebtSnowball(debtManager, paymentManager);			
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

