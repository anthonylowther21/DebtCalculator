using System;
using System.Collections.Generic;
using DebtCalculator.Library;

namespace DebtCalculator
{
  public class DatabaseService : IDatabaseService
  {
    private DebtManager _debtManager;
    private PaymentManager _paymentManager;

    public DatabaseService ()
    {
      _debtManager = new DebtManager();
      _paymentManager = new PaymentManager();
    }

    public DebtManager GetDebtManager()
    {
      return _debtManager;
    }

    public PaymentManager GetPaymentManager()
    {
      return _paymentManager;
    }
  }
}

