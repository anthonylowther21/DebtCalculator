using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using DebtCalculator.Library;

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

      DebtManager debtManager = new DebtManager();
      PaymentManager paymentManager = new PaymentManager();

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
      paymentManager.SnowballAmount = 860;
      paymentManager.AddWindfallEntry(500, new DateTime(2016, 1, 1), true, 6); 
      paymentManager.AddWindfallEntry(500, new DateTime(2016, 1, 1), true, 6);

      DebtSnowballCalculator.CalculateDebtSnowball(debtManager, paymentManager);  

    }
  }
}

