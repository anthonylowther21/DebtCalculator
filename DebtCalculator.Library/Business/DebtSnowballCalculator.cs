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
        _localPaymentManager.SnowballEntries = paymentManager.CloneSnowballs ();
      }
    }

    public ObservableCollection<AmortizationEntry> CalculateDebtSnowball(DebtManager debtManagerXX, PaymentManager paymentManagerXX, bool applySnowballs)
    {
      CreateLocalCopies(debtManagerXX, paymentManagerXX, applySnowballs);

      DateTime simulatedDate = DateTime.Now;

      var watch = Stopwatch.StartNew();

      ObservableCollection<AmortizationEntry> col = new ObservableCollection<AmortizationEntry>();

      bool allFinished = false;

      simulatedDate = DateTime.Now;
      // Simulate the months and apply the snowball to debts each month
      while (!allFinished)
      {
        double salarySnowball = _localPaymentManager.GetTotalMonthlySnowball(simulatedDate);
        allFinished = true;

        foreach (DebtEntry debt in _localDebtManager.Debts)
        {
          if (debt.CurrentBalance > 0)
          {
            col.Add(ApplyMonthlyPayment(simulatedDate, debt, _localPaymentManager, ref salarySnowball, applySnowballs));
            allFinished = false;
          }
        }
        simulatedDate = simulatedDate.AddMonths(1);
      }

      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      System.Diagnostics.Debug.WriteLine("Milliseconds " + elapsedMs);

      return col;
    }

    private AmortizationEntry ApplyMonthlyPayment(DateTime currentDate, DebtEntry debtEntry, 
      PaymentManager paymentManager, ref double additionalPrincipal, bool applySnowball)
    {
      double startingBalance = debtEntry.CurrentBalance;

      double interestPortion = debtEntry.MonthlyInterest * debtEntry.CurrentBalance;
      double minimumPrincipal = debtEntry.MinimumMonthlyPayment - interestPortion;
      double principalPortion = minimumPrincipal + additionalPrincipal;

      double possibleBalance = debtEntry.CurrentBalance - principalPortion;

      if (possibleBalance < 0)
      {
        if (minimumPrincipal >= debtEntry.CurrentBalance)
        {
          minimumPrincipal = debtEntry.CurrentBalance - interestPortion;
          additionalPrincipal = 0;
        }
        else
        {
          additionalPrincipal = debtEntry.CurrentBalance - minimumPrincipal - interestPortion;
        }
          
        debtEntry.CurrentBalance = 0;
        if (applySnowball)
        {
          paymentManager.WindfallEntries.Add(new WindfallEntry(string.Empty, Math.Abs(possibleBalance), currentDate.AddMonths(1)));
          if (paymentManager.SnowballEntries.Count > 0) 
          {
            paymentManager.SnowballEntries [0].Amount += debtEntry.MinimumMonthlyPayment;
          } 
          else 
          {
            paymentManager.SnowballEntries.Add (new SnowballEntry ("Temp", debtEntry.MinimumMonthlyPayment));
          }
        }
      }
      else if (possibleBalance > debtEntry.CurrentBalance)
      {
        debtEntry.Name += " INVALID!";
        debtEntry.CurrentBalance = -9999;
      }
      else
      {
        debtEntry.CurrentBalance = possibleBalance;
      }

      AmortizationEntry output = new AmortizationEntry(
        debtEntry.Name, debtEntry.DebtType, currentDate, startingBalance, interestPortion, 
        minimumPrincipal, additionalPrincipal, debtEntry.CurrentBalance);

      // We always use up all of the additional principle, otherwise it gets added as a windfall the 
      // following month
      additionalPrincipal = 0;
      return output;
    }
  }
}

