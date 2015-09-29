using System;

namespace DebtCalculator
{
	public class SalaryEntry
	{
        static public SalaryEntry CreateSalaryEntry(double startingSalary, double yearlyIncreasePercent, DateTime appliedDate)
        {
            return new SalaryEntry()
            {
                StartingSalary = startingSalary,
                YearlyIncreasePercent = yearlyIncreasePercent,
                YearlyIncreaseAppliedDate = appliedDate
            };
        }

        protected SalaryEntry ()
		{
		}

		public double StartingSalary { get; private set; }
		public double YearlyIncreasePercent { get; private set; }
		public DateTime YearlyIncreaseAppliedDate { get; private set; }
	}
}

