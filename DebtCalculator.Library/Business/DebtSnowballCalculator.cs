using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Diagnostics;
using System.Collections.Generic;

namespace DebtCalculator.Library
{
  public class DebtSnowballCalculator
  {
    private DebtManager _localDebtManager;
    private PaymentManager _localPaymentManager;

    public DebtSnowballCalculator ()
    {
    }

    private void CreateLocalCopies(DebtManager debtManager, PaymentManager paymentManager)
    {
      _localDebtManager = new DebtManager();
      _localDebtManager.Debts = debtManager.CloneDebts();

      _localPaymentManager = new PaymentManager();
      _localPaymentManager.WindfallEntries = paymentManager.CloneWindfalls();
      _localPaymentManager.SalaryEntries = paymentManager.CloneSalaries();
      _localPaymentManager.SnowballAmount = paymentManager.SnowballAmount;
    }

    public ObservableCollection<PaymentPlanOutputEntry> CalculateDebtSnowball(DebtManager debtManagerXX, PaymentManager paymentManagerXX)
    {
      CreateLocalCopies(debtManagerXX, paymentManagerXX);

      DateTime simulatedDate = DateTime.Now;

      var watch = Stopwatch.StartNew();

      ObservableCollection<PaymentPlanOutputEntry> col = new ObservableCollection<PaymentPlanOutputEntry>();

      foreach (DebtEntry debt in _localDebtManager.Debts)
      {
        while (debt.CurrentBalance > 0)
        {
          double salarySnowball = _localPaymentManager.GetTotalMonthlySnowball(simulatedDate);
          col.Add(this.ApplyMonthlyPayment(simulatedDate, debt, _localPaymentManager, salarySnowball));
          simulatedDate = simulatedDate.AddMonths(1);
        }
      }  

      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      System.Diagnostics.Debug.WriteLine("Milliseconds " + elapsedMs);

      return col;
    }

    private PaymentPlanOutputEntry ApplyMonthlyPayment(DateTime currentDate, DebtEntry debtEntry, 
      PaymentManager paymentManager, double additionalPrinciple = 0)
    {
      double startingBalance = debtEntry.CurrentBalance;

      double interestPortion = debtEntry.MonthlyInterest * debtEntry.CurrentBalance;
      double minimumPrinciple = debtEntry.MinimumMonthlyPayment - interestPortion;
      double principalPortion = minimumPrinciple + additionalPrinciple;

      double possibleBalance = debtEntry.CurrentBalance -= principalPortion;

      if (possibleBalance < 0)
      {
        debtEntry.CurrentBalance = 0;
        paymentManager.AddWindfallEntry(Math.Abs(possibleBalance), currentDate.AddMonths(1));
        paymentManager.SnowballAmount += debtEntry.MinimumMonthlyPayment;
      }
      else
      {
        debtEntry.CurrentBalance = possibleBalance;
      }

      PaymentPlanOutputEntry output = new PaymentPlanOutputEntry(
        debtEntry.Name, currentDate, startingBalance, interestPortion, 
        minimumPrinciple, additionalPrinciple, debtEntry.CurrentBalance);
      return output;
    }
  }
}

