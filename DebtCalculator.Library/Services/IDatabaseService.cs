using System;
using System.Collections.Generic;
using DebtCalculator.Library;
using System.Collections.ObjectModel;

namespace DebtCalculatorLibrary.Services
{
  public interface IDatabaseService
  {
    DebtManager GetDebtManager();
    PaymentManager GetPaymentManager();
    DebtSnowballCalculator GetDebtSnowballCalculator();
    ObservableCollection<AmortizationEntry> Calculate(bool applySnowballs);
    void SetNeedsRefresh();
    event EventHandler NeedsRefreshChanged;
  }
}

