using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator.Library
{
	public class PaymentManager
	{
		private Collection<SalaryEntry> _salaryEntries = null;
		private Collection<WindfallEntry> _windfallEntries = null;
		private double _snowballAmount = Double.NaN;

        static public PaymentManager CreatePaymentManager()
        {
            return new PaymentManager();
        }

        protected PaymentManager ()
		{
            _snowballAmount = 0;
			_salaryEntries = new Collection<SalaryEntry> ();
			_windfallEntries = new Collection<WindfallEntry> ();
		}

		public IEnumerable<SalaryEntry> SalaryEntries
		{ 
            get { return _salaryEntries.ToArray(); }
		}

        public IEnumerable<WindfallEntry> WindfallEntries
		{ 
			get { return _windfallEntries.ToArray(); }
		}

		public double SnowballAmount 
		{ 
			get { return _snowballAmount; }
		}

        public void SetSnowballAmount(double amount)
        {
            _snowballAmount = amount;
        }

        public void AddSalaryEntry(double startingSalary, double yearlyIncreasePercent, DateTime appliedDate)
        {
            _salaryEntries.Add(
                SalaryEntry.CreateSalaryEntry(startingSalary, yearlyIncreasePercent, appliedDate));
        }

        public void AddWindfallEntry(double amount, 
                                     DateTime windfallDate, 
                                     bool isRecurring = false, 
                                     int recurringFrequency = -1)
        {
            _windfallEntries.Add(
                WindfallEntry.CreateWindfallEntry(amount, windfallDate, isRecurring, recurringFrequency));
        }

        public double GetTotalMonthlySnowball (DateTime simulatedDate)
        {
            double amount = SnowballAmount;

            foreach (WindfallEntry windfallEntry in this.WindfallEntries)
            {
                if (simulatedDate.Year  == windfallEntry.WindfallDate.Year &&
                    simulatedDate.Month == windfallEntry.WindfallDate.Month)
                {
                    amount += windfallEntry.Amount;
                }
                else if (windfallEntry.IsReccurring)
                {
                    int monthDifference = ((simulatedDate.Year - windfallEntry.WindfallDate.Year) * 12) + 
                        simulatedDate.Month - windfallEntry.WindfallDate.Month;
                    
                    if (monthDifference % windfallEntry.ReccurringFrequency == 0)
                    {
                        amount += windfallEntry.Amount;
                    }
                }
            }

            foreach (SalaryEntry salaryEntry in this.SalaryEntries)
            {
                double finalSalary = salaryEntry.StartingSalary;

                if (simulatedDate.Year  >= salaryEntry.YearlyIncreaseAppliedDate.Year && 
                    simulatedDate.Month >= salaryEntry.YearlyIncreaseAppliedDate.Month)
                {
                    int yearDifference = simulatedDate.Year - salaryEntry.YearlyIncreaseAppliedDate.Year;
                    finalSalary *= 
                        Math.Pow((1.0 + salaryEntry.YearlySnowballIncreasePercent), yearDifference + 1);
                }

                amount += ((finalSalary - salaryEntry.StartingSalary) / 12.0);
            }

            return amount;

        }
	}
}

