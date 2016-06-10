using System;
using System.Collections;
using PropertyChanged;

namespace DebtCalculator.Library
{
  public class DebtEntry : BaseClass
  {
    private double  _startingBalance    = -1;
    private double  _currentBalance     = -1;
    private double  _yearlyInterestRate = -1;
    private int     _loanTerm           = -1;
    private DebtType _debtType = DebtType.OtherLoan;

    private const double _yearly_to_monthly_interest_term_inverse = 1.0 / 12.0 / 100.0;

    public DebtEntry(string name, double startBalance, double currentBalance, double yearlyInterest, int loanTerm, DebtType debtType)
    {
      Name = name;
      StartingBalance = startBalance;
      CurrentBalance = currentBalance;
      YearlyInterestRate = yearlyInterest;
      LoanTerm = loanTerm;
      DebtType = debtType;

      InitializeMonthlyPayment();
    }

    public DebtEntry(DebtType debtType = DebtType.OtherLoan) : base()
    {
      _debtType = debtType;
      InitializeMonthlyPayment();
    }

    public new DebtEntry Clone()
    {
      DebtEntry debt = (DebtEntry)base.Clone();
      return debt;
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

    public DebtType DebtType
    {
      get { return _debtType; }
      set { _debtType = value; }
    }
      
    public double MinimumMonthlyPayment { get; private set; } = -1;
    public double MonthlyInterest { get; private set; }

    private void InitializeMonthlyPayment()
    {
      // If we aren't initialized, then don't proceed
      if (_currentBalance < 0 || _loanTerm < 0 ||
          _startingBalance < 0 || _yearlyInterestRate < 0) {
        return;
      }

      if (_debtType == DebtType.HouseLoan || _debtType == DebtType.CarLoan || 
          _debtType == DebtType.StudentLoan || _debtType == DebtType.OtherLoan)
      {
        MonthlyInterest = YearlyInterestRate * 100 * _yearly_to_monthly_interest_term_inverse;
        double monthlyInterest_Loan_Term = Math.Pow((1 + MonthlyInterest), LoanTerm);
        MinimumMonthlyPayment = MonthlyInterest * StartingBalance * monthlyInterest_Loan_Term / (monthlyInterest_Loan_Term - 1);
      }
      else if (_debtType == DebtType.CreditCard)
      {
        MonthlyInterest = YearlyInterestRate * 100 * _yearly_to_monthly_interest_term_inverse;
        MinimumMonthlyPayment = 40;
      }
    }
  }
}

