using System;
using System.Collections;

namespace DebtCalculator.Library
{
  public class DebtEntry
  {
    private string  _name               = "Debt Name";
    private double  _startingBalance    = 10000;
    private double  _currentBalance     = 5000;
    private double  _yearlyInterestRate = 0.0325;
    private int     _loanTerm           = 36;

    private const double _yearly_to_monthly_interest_term_inverse = 1.0 / 12.0 / 100.0;

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

    public DebtEntry()
    {
    }

    public string Name 
    { 
      get { return _name; }
      set { _name = value; }
    }

    public double StartingBalance
    {
      get { return _startingBalance; }
      set { _startingBalance = value; }
    }

    public double CurrentBalance
    {
      get { return _currentBalance; }
      set { _currentBalance = value; }
    }

    public double YearlyInterestRate
    {
      get { return _yearlyInterestRate; }
      set { _yearlyInterestRate = value; }
    }

    public int LoanTerm
    {
      get { return _loanTerm; }
      set { _loanTerm = value; }
    }
      
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

