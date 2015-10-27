using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator.Library
{
  public class DebtManager
  {
    private ObservableCollection<DebtEntry> _debtEntries;

    static public DebtManager CreateDebtManager()
    {
      return new DebtManager();
    }

    protected DebtManager ()
    {
      _debtEntries = new ObservableCollection<DebtEntry>();
    }

    public ObservableCollection<DebtEntry> DebtEntries 
    { 
      get { return _debtEntries; } 
    }

    public bool AddDebtEntry(DebtEntry debtEntry)
    {
      _debtEntries.Add(debtEntry);
      return true;
    }
  }
}

