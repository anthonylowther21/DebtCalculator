using System;
using PropertyChanged;

namespace DebtCalculator.Library
{
  [AddINotifyPropertyChangedInterfaceAttribute]
  public class WindfallEntry : BaseClass
  {
    private double _amount = -1;
    private DateTime _windfallDate = DateTime.MinValue;
    private bool _isRecurring = false;
    private int _recurringFrequency = -1;

    public WindfallEntry (string name, 
                          double amount, 
                          DateTime windfallDate, 
                          bool isRecurring = false, 
                          int recurringFrequency = 0)
    {
      Name = name;
      Amount = amount;
      WindfallDate = windfallDate;
      IsRecurring = isRecurring;
      RecurringFrequency = recurringFrequency;
    }

    public WindfallEntry()
    {
    }

    public new WindfallEntry Clone()
    {
      return (WindfallEntry)base.Clone();
    }

    public double Amount
    {
      get
      {
        return _amount;
      }
      set
      {
        _amount = value;
      }
    }
      
    public DateTime WindfallDate
    {
      get
      {
        return _windfallDate;
      }
      set
      {
        _windfallDate = value;
      }
    }

    public bool IsRecurring
    {
      get
      {
        return _isRecurring;
      }
      set
      {
        _isRecurring = value;
      }
    }

    public int RecurringFrequency
    {
      get
      {
        return _recurringFrequency;
      }
      set
      {
        _recurringFrequency = value;
      }
    }
  }
}

