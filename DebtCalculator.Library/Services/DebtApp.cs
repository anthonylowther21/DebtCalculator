using System;
using System.Collections.Generic;
using DebtCalculator.Library;
using System.Collections.ObjectModel;

namespace DebtCalculatorLibrary.Services
{
  public class DebtApp
  {
    private DebtManager _debtManager;
    private PaymentManager _paymentManager;
    private DebtSnowballCalculator _debtSnowballCalculator;

    static DebtApp _shared = null;

    private DebtApp ()
    {
      _debtManager = new DebtManager();
      _paymentManager = new PaymentManager();
      _debtSnowballCalculator = new DebtSnowballCalculator();
    }

    static public DebtApp Shared
    {
      get
      {
        return (_shared == null) ? _shared = new DebtApp() : _shared;
      }
    }

    public DebtManager DebtManager
    {
      get { return _debtManager; }
    }

    public PaymentManager PaymentManager
    {
      get { return _paymentManager; }
    }

    public DebtSnowballCalculator DebtSnowballCalculator
    {
      get { return _debtSnowballCalculator; }
    }

    public ObservableCollection<AmortizationEntry> Calculate(bool applySnowballs = true)
    {
      return _debtSnowballCalculator.CalculateDebtSnowball(_debtManager, _paymentManager, applySnowballs);
    }

    public DateTime ModifiedDate { get; set; }
  }
}

