using System;
using System.Collections.ObjectModel;

namespace DebtCalculator
{
	static public class DebtSnowballCalculator
	{
		static DebtSnowballCalculator ()
		{
		}

		static public Collection<PaymentPlanOutputEntry> CalculateDebtSnowball(DebtManager debtManager, PaymentManager paymentManager)
		{
            foreach (DebtEntry debt in debtManager.DebtEntries)
            {
                while (debt.CurrentBalance > 0)
                {
                    DebtSnowballCalculator.ApplyMonthlyPayment(debt, 1000);
                }
            }        

			return null;
		}

		static public void ApplyMonthlyPayment(DebtEntry debtEntry, double additionalPrinciple = 0)
		{
            Console.Write (debtEntry.Name);
			Console.Write (" Starting Balance: " + debtEntry.CurrentBalance.ToString("C"));

			double interestPortion = debtEntry.MonthlyInterest * debtEntry.CurrentBalance;
			double principalPortion = debtEntry.MinimumMonthlyPayment + additionalPrinciple - interestPortion;
			debtEntry.CurrentBalance -= principalPortion;

			Console.Write (" Interest: " + interestPortion.ToString("C"));
			Console.Write (" Principal: " + principalPortion.ToString("C"));
			Console.Write (" Ending Balance: " + debtEntry.CurrentBalance.ToString("C"));
			Console.WriteLine();
		}
	}
}

