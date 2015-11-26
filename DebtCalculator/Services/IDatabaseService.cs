using System;
using System.Collections.Generic;
using DebtCalculator.Library;
using System.Collections.ObjectModel;

namespace DebtCalculator
{
  public interface IDatabaseService
  {
    DebtManager GetDebtManager();
    PaymentManager GetPaymentManager();
    DebtSnowballCalculator GetDebtSnowballCalculator();
    ObservableCollection<PaymentPlanOutputEntry> Calculate(bool applySnowballs);

  }
}

