using System;
using System.Collections.ObjectModel;
using DebtCalculator.Shared;
using System.Collections.Generic;
using System.Linq;
using PropertyChanged;

namespace DebtCalculator.Library
{
  public class DebtManager
  {
    private ObservableCollectionEx<DebtEntry> _debtEntries = new ObservableCollectionEx<DebtEntry>();

    public DebtManager ()
    {
    }

    public ObservableCollectionEx<DebtEntry> Debts 
    { 
      get { return _debtEntries; } 
      set { _debtEntries = value; }
    }

    public void UpdateDebt (DebtEntry newItem)
    {
      DebtEntry oldItem = null;

      foreach (var entry in _debtEntries)
      {
        if (entry.Id == newItem.Id)
        {
          oldItem = entry;
          break;
        }
      }

      if (oldItem != null)
      {
        _debtEntries.Remove(oldItem);
      }

      _debtEntries.Add(newItem);
    }

    public void DeleteDebt (DebtEntry item)
    {
      DebtEntry oldItem = null;

      foreach (var entry in _debtEntries)
      {
        if (entry.Id == item.Id)
        {
          oldItem = entry;
          break;
        }
      }

      if (oldItem != null)
      {
        _debtEntries.Remove(oldItem);
      }
    }

    public ObservableCollectionEx<DebtEntry> CloneDebts()
    {
      ObservableCollectionEx<DebtEntry> clones = new ObservableCollectionEx<DebtEntry>();
      foreach (var item in _debtEntries)
      {
        clones.Add(item.Clone());
      }
      return clones;
    }
  }
}

