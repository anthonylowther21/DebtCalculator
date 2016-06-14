using System;
using PropertyChanged;

namespace DebtCalculator.Library
{
  public class SnowballEntry : BaseClass
  {
    private string _name = string.Empty;
    private double _amount = -1;

    public SnowballEntry (string name, 
                          double amount)
    {
      Name = name;
      Amount = amount;
    }

    public SnowballEntry ()
    {
    }

    public new SnowballEntry Clone()
    {
      return (SnowballEntry)base.Clone();
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
  }
}

