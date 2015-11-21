using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using PropertyChanged;

namespace DebtCalculator.Library
{
  public class DebtManager
  {
    private List<DebtEntry> _debtEntries;

    public DebtManager ()
    {
      _debtEntries = new List<DebtEntry>();
    }

    public List<DebtEntry> Debts 
    { 
      get { return _debtEntries; } 
    }

    public void UpdateDebt (DebtEntry newItem)
    {
      var oldItem = _debtEntries.Find(c => c.Id == newItem.Id);

      if (oldItem != null)
      {
        _debtEntries.Remove(oldItem);
      }

      _debtEntries.Add(newItem);
    }

    public void DeleteDebt (DebtEntry item)
    {
      var oldItem = _debtEntries.Find(c => c.Id == item.Id);

      if (oldItem != null)
      {
        _debtEntries.Remove(oldItem);
      }
    }
  }
}

