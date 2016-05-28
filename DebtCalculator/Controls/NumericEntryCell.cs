using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace DebtCalculator.Shared
{
  public class NumericEntryCell : EntryCell
  {
    public event EventHandler Completed;

    public NumericEntryCell()
    {
    }

    public void OnCompleted()
    {
      var handler = Completed as EventHandler;
      if (handler != null) 
      {
        Completed (this, new EventArgs ());
      }
    }
  }
}

