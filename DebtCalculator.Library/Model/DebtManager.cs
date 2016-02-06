using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using PropertyChanged;

namespace DebtCalculator.Library
{
  public class DebtManager
  {
    private ObservableCollection<DebtEntry> _debtEntries = new ObservableCollection<DebtEntry>();

    public DebtManager ()
    {
    }

    public ObservableCollection<DebtEntry> Debts 
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

    public ObservableCollection<DebtEntry> CloneDebts()
    {
      ObservableCollection<DebtEntry> clones = new ObservableCollection<DebtEntry>();
      foreach (var item in _debtEntries)
      {
        clones.Add(item.Clone());
      }
      return clones;
    }
  }
}

