using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator
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
	}
}

