﻿using System;
using System.Collections.Generic;
using DebtCalculator.Library;
using System.Collections.ObjectModel;

namespace DebtCalculatorLibrary.Services
{
  public class DebtApp
  {
    private DebtManager _debtManager;
    private PaymentManager _paymentManager;
    private ScenarioOptions _scenarioOptions;
    private DebtSnowballCalculator _debtSnowballCalculator;
    private bool _calculationIsDirty = true;

    public Action<bool> CalculationDirtyChanged; 

    static DebtApp _shared = null;

    private DebtApp ()
    {
      _debtManager = new DebtManager();
      _paymentManager = new PaymentManager();
      _scenarioOptions = new ScenarioOptions ();
      _debtSnowballCalculator = new DebtSnowballCalculator();
    }

    static public DebtApp Shared
    {
      get
      {
        return (_shared == null) ? _shared = new DebtApp() : _shared;
      }
    }

    public bool CalculationIsDirty {
      get {
        return _calculationIsDirty;
      }
      set {
        if (_calculationIsDirty != value) {
          _calculationIsDirty = value;
          if (CalculationDirtyChanged != null) CalculationDirtyChanged (_calculationIsDirty);
        }
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

    public ScenarioOptions ScenarioOptions
    {
      get { return _scenarioOptions; }
    }

    public ObservableCollection<AmortizationEntry> Calculate(bool applySnowballs = true)
    {
      return _debtSnowballCalculator.CalculateDebtSnowball(_debtManager, _paymentManager, applySnowballs);
    }

    public DateTime ModifiedDate { get; set; }
  }
}

