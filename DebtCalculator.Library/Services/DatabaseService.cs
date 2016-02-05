using System;
using System.Collections.Generic;
using DebtCalculator.Library;
using System.Collections.ObjectModel;

namespace DebtCalculatorLibrary.Services
{
  public class DatabaseService : IDatabaseService
  {
    private DebtManager _debtManager;
    private PaymentManager _paymentManager;
    private DebtSnowballCalculator _debtSnowballCalculator;
    public event EventHandler NeedsRefreshChanged;

    public DatabaseService ()
    {
      _debtManager = new DebtManager();
      _paymentManager = new PaymentManager();
      _debtSnowballCalculator = new DebtSnowballCalculator();
    }

    public DebtManager GetDebtManager()
    {
      return _debtManager;
    }

    public PaymentManager GetPaymentManager()
    {
      return _paymentManager;
    }

    public DebtSnowballCalculator GetDebtSnowballCalculator()
    {
      return _debtSnowballCalculator;
    }

    public ObservableCollection<AmortizationEntry> Calculate(bool applySnowballs = true)
    {
      return _debtSnowballCalculator.CalculateDebtSnowball(_debtManager, _paymentManager, applySnowballs);
    }

    public void SetNeedsRefresh()
    {
      if (NeedsRefreshChanged != null)
      {
        NeedsRefreshChanged(this, new EventArgs());
      }
    }
  }
}

