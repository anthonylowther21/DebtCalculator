using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DebtCalculator
{
    static public class DebtSnowballCalculator
    {
        static DebtSnowballCalculator ()
        {
        }

        static public Collection<PaymentPlanOutputEntry> CalculateDebtSnowball(DebtManager debtManager, PaymentManager paymentManager)
        {
            Collection<PaymentPlanOutputEntry> col = new Collection<PaymentPlanOutputEntry>();

            DateTime startDate = DateTime.Now;
            DateTime currentDate = DateTime.Now;

            foreach (DebtEntry debt in debtManager.DebtEntries)
            {
                while (debt.CurrentBalance > 0)
                {
                    double salarySnowball = paymentManager.GetTotalMonthlySnowball(startDate, currentDate);
                    col.Add(DebtSnowballCalculator.ApplyMonthlyPayment(currentDate, debt, paymentManager, salarySnowball));
                    currentDate = currentDate.AddMonths(1);
                }
            }        

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

