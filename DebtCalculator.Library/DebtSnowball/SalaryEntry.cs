using System;

namespace DebtCalculator.Library
{
	public class SalaryEntry
	{
        static public SalaryEntry CreateSalaryEntry(double startingSalary, double yearlyIncreasePercent, DateTime appliedDate)
        {
            return new SalaryEntry()
            {
                StartingSalary = startingSalary,
                YearlySnowballIncreasePercent = yearlyIncreasePercent,
                YearlyIncreaseAppliedDate = appliedDate
            };
        }

        protected SalaryEntry ()
		{
		}

		public double StartingSalary { get; private set; }
		public double YearlySnowballIncreasePercent { get; private set; }
		public DateTime YearlyIncreaseAppliedDate { get; private set; }
	}
}

