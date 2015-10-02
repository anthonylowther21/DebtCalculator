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
                int month = 0;
                double snowballAmount = paymentManager.SnowballAmount;

                while (debt.CurrentBalance > 0)
                {
                    double salarySnowball = paymentManager.GetTotalMonthlySnowball(DateTime.Now, new DateTime(2020, 12, 1));

                    DebtSnowballCalculator.ApplyMonthlyPayment(debt, salarySnowball);
                    month++;
                }
            }        

			return null;
		}

//        static public void PopulateAllWindfalls(PaymentManager paymentManager)
//        {
//            foreach (WindfallEntry windfallEntry in paymentManager)
//            {
//                int year
//            }
//        }

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

