using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator.Library
{
  public class DebtManager
  {
    private ObservableCollection<DebtEntry> _debtEntries;

    public DebtManager ()
    {
      _debtEntries = new ObservableCollection<DebtEntry>();
    }

    public ObservableCollection<DebtEntry> Debts 
    { 
      get { return _debtEntries; } 
    }

    public void UpdateDebt (DebtEntry newItem)
    {
      DebtEntry oldItem = null;

      foreach (DebtEntry item in _debtEntries)
      {
        if (item.Id == newItem.Id)
        {
          oldItem = item;
          break;
        }
      }

      if (oldItem != null)
      {
        oldItem.Name = newItem.Name;
      }
      else
      {
        _debtEntries.Add(newItem);
      }
    }
  }
}

