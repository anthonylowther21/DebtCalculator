using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Diagnostics;

namespace DebtCalculator.Library
{
    static public class DebtSnowballCalculator
    {
        static DebtSnowballCalculator ()
        {
        }

        static public Collection<PaymentPlanOutputEntry> CalculateDebtSnowball(DebtManager debtManager, PaymentManager paymentManager)
        {
            DateTime simulatedDate = DateTime.Now;

            var watch = Stopwatch.StartNew();

            Collection<PaymentPlanOutputEntry> col = new Collection<PaymentPlanOutputEntry>();

            foreach (DebtEntry debt in debtManager.DebtEntries)
            {
                while (debt.CurrentBalance > 0)
                {
                    double salarySnowball = paymentManager.GetTotalMonthlySnowball(simulatedDate);
                    col.Add(DebtSnowballCalculator.ApplyMonthlyPayment(simulatedDate, debt, paymentManager, salarySnowball));
                    simulatedDate = simulatedDate.AddMonths(1);
                }
            }  

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("Milliseconds " + elapsedMs);

            return col;
        }

        static public PaymentPlanOutputEntry ApplyMonthlyPayment(DateTime currentDate, DebtEntry debtEntry, 
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
            }
            else
            {
                debtEntry.CurrentBalance = possibleBalance;
            }

            PaymentPlanOutputEntry output = PaymentPlanOutputEntry.Create(
                debtEntry.Name, currentDate, startingBalance, interestPortion, 
                minimumPrinciple, additionalPrinciple, debtEntry.CurrentBalance);
            //PaymentPlanOutputEntry.WriteToConsole(output);
            return output;
        }
    }
}

