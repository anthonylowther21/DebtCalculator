using System;

namespace DebtCalculator
{
    public class DebtEntry
    {
        static private double _yearly_to_monthly_interest_term_inverse = 1.0 / 12.0 / 100.0;

        static public DebtEntry CreateDebtEntry(string name, double startBalance, double currentBalance, double yearlyInterest, int loanTerm)
        {
            DebtEntry debtEntry = new DebtEntry() 
            {
                Name = name,
                StartingBalance = startBalance,
                CurrentBalance = currentBalance,
                YearlyInterestRate = yearlyInterest,
                LoanTerm = loanTerm
            };

            InitializeMonthlyPayment(debtEntry);

            return debtEntry;
        }

        protected DebtEntry()
        {
        }

        public string Name { get; private set; }
        public double StartingBalance { get; private set; }
        public double CurrentBalance { get; set; }
        public double YearlyInterestRate { get; private set; }
        public int LoanTerm { get; private set; }
        public double MinimumMonthlyPayment { get; private set; }
        public double MonthlyInterest { get; private set; }

        static protected void InitializeMonthlyPayment(DebtEntry debtEntry)
        {
            debtEntry.MonthlyInterest = debtEntry.YearlyInterestRate * _yearly_to_monthly_interest_term_inverse;
            double monthlyInterest_Loan_Term = Math.Pow ((1 + debtEntry.MonthlyInterest), debtEntry.LoanTerm);
            debtEntry.MinimumMonthlyPayment = debtEntry.MonthlyInterest * debtEntry.StartingBalance * monthlyInterest_Loan_Term / (monthlyInterest_Loan_Term - 1);
        }
    }
}

