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

    private void CreateLocalCopies(DebtManager debtManager, PaymentManager paymentManager, bool applySnowballs)
    {
      _localDebtManager = new DebtManager();
      _localDebtManager.Debts = debtManager.CloneDebts();

      _localPaymentManager = new PaymentManager();
      if (applySnowballs)
      {
        _localPaymentManager.WindfallEntries = paymentManager.CloneWindfalls();
        _localPaymentManager.SalaryEntries = paymentManager.CloneSalaries();
        _localPaymentManager.SnowballAmount = paymentManager.SnowballAmount;
      }
    }

    public ObservableCollection<AmortizationEntry> CalculateDebtSnowball(DebtManager debtManagerXX, PaymentManager paymentManagerXX, bool applySnowballs)
    {
      CreateLocalCopies(debtManagerXX, paymentManagerXX, applySnowballs);

      DateTime simulatedDate = DateTime.Now;

      var watch = Stopwatch.StartNew();

      ObservableCollection<AmortizationEntry> col = new ObservableCollection<AmortizationEntry>();

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

    private AmortizationEntry ApplyMonthlyPayment(DateTime currentDate, DebtEntry debtEntry, 
      PaymentManager paymentManager, double additionalPrincipal = 0)
    {
      double startingBalance = debtEntry.CurrentBalance;

      double interestPortion = debtEntry.MonthlyInterest * debtEntry.CurrentBalance;
      double minimumPrincipal = debtEntry.MinimumMonthlyPayment - interestPortion;
      double principalPortion = minimumPrincipal + additionalPrincipal;

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

      AmortizationEntry output = new AmortizationEntry(
        debtEntry.Name, currentDate, startingBalance, interestPortion, 
        minimumPrincipal, additionalPrincipal, debtEntry.CurrentBalance);
      return output;
    }
  }
}

