using System;

namespace DebtCalculator.Library
{
  public class WindfallEntry
  {
    static public WindfallEntry CreateWindfallEntry(double amount, 
      DateTime windfallDate, 
      bool isRecurring = false, 
      int recurringFrequency = -1)
    {
      return new WindfallEntry()
      {
        Amount = amount,
        WindfallDate = windfallDate,
        IsReccurring = isRecurring,
        ReccurringFrequency = recurringFrequency
      };
    }

    protected WindfallEntry ()
    {
    }

    public double Amount { get; private set; }
    public bool IsReccurring { get; private set; }
    public int ReccurringFrequency { get; private set; }
    public DateTime WindfallDate { get; private set; }
  }
}

