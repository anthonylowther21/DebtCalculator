using System;
using System.Collections;
using PropertyChanged;

namespace DebtCalculator.Library
{
  public class DebtEntry : BaseClass
  {
    private string  _name               = "Debt Name";
    private double  _startingBalance    = 10000;
    private double  _currentBalance     = 5000;
    private double  _yearlyInterestRate = 0.0325;
    private int     _loanTerm           = 36;

    private const double _yearly_to_monthly_interest_term_inverse = 1.0 / 12.0 / 100.0;

    public DebtEntry(string name, double startBalance, double currentBalance, double yearlyInterest, int loanTerm)
    {
      Name = name;
      StartingBalance = startBalance;
      CurrentBalance = currentBalance;
      YearlyInterestRate = yearlyInterest;
      LoanTerm = loanTerm;

      InitializeMonthlyPayment();
    }

    public DebtEntry() : base()
    {
      InitializeMonthlyPayment();
    }

    public new DebtEntry Clone()
    {
      DebtEntry debt = (DebtEntry)base.Clone();
      return debt;
    }

    public string Name 
    { 
      get { return _name; }
      set { _name = value; }
    }

    public double StartingBalance
    {
      get { return _startingBalance; }
      set 
      { 
        _startingBalance = value; 
        InitializeMonthlyPayment();
      }
    }

    public double CurrentBalance
    {
      get { return _currentBalance; }
      set { _currentBalance = value; }
    }

    public double YearlyInterestRate
    {
      get { return _yearlyInterestRate; }
      set 
      { 
        _yearlyInterestRate = value; 
        InitializeMonthlyPayment();
      }
    }

    public int LoanTerm
    {
      get { return _loanTerm; }
      set 
      { 
        _loanTerm = value; 
        InitializeMonthlyPayment();
      }
    }
      
    public double MinimumMonthlyPayment { get; private set; }
    public double MonthlyInterest { get; private set; }

    private void InitializeMonthlyPayment()
    {
      if (_loanTerm > -1)
      {
        MonthlyInterest = YearlyInterestRate * 100 * _yearly_to_monthly_interest_term_inverse;
        double monthlyInterest_Loan_Term = Math.Pow((1 + MonthlyInterest), LoanTerm);
        MinimumMonthlyPayment = MonthlyInterest * StartingBalance * monthlyInterest_Loan_Term / (monthlyInterest_Loan_Term - 1);
      }
      else
      {
        MonthlyInterest = YearlyInterestRate * 100 * _yearly_to_monthly_interest_term_inverse;
        MinimumMonthlyPayment = 40;
      }
    }
  }
}

