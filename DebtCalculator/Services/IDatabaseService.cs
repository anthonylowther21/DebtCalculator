using System;
using System.Collections.Generic;
using DebtCalculator.Library;

namespace DebtCalculator
{
  public interface IDatabaseService
  {
    DebtManager GetDebtManager();
    PaymentManager GetPaymentManager();
  }
}

