using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DebtCalculator.UITests
{
	[TestFixture (Platform.Android)]
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

		[Test]
		public void WelcomeTextIsDisplayed ()
		{
			AppResult[] results = app.WaitForElement (c => c.Marked ("Welcome to Xamarin Forms!"));
			app.Screenshot ("Welcome screen.");

			Assert.IsTrue (results.Any ());

            DebtManager debtManager = DebtManager.CreateDebtManager();
            PaymentManager paymentManager = PaymentManager.CreatePaymentManager();

            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 1", 25000, 25000, 3.25, 360));
            debtManager.AddDebtEntry(DebtEntry.CreateDebtEntry("Debt 2", 32000, 32000, 3.25, 360));

            paymentManager.AddSalaryEntry(70000, 3, DateTime.Now);
            paymentManager.SetSnowballAmount(500);
            paymentManager.AddWindfallEntry(1000, DateTime.Now, true, 6);



            DebtSnowballCalculator.CalculateDebtSnowball(debtManager, paymentManager);      
		}
	}
}

