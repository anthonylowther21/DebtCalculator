using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace DebtCalculator.Shared
{
  public class Grouping<K, T> : ObservableCollection<T>
  {
    public K Key { get; private set; }

    public IList<T> MyItems 
    {
      get 
      {
        return base.Items;
      } 
    }

    public Grouping (K key, IEnumerable<T> items)
    {
      Key = key;
      foreach (var item in items)
        this.Items.Add (item);
    }
  }
}

