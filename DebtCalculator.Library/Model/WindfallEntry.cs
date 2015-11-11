using System;

namespace DebtCalculator.Library
{
  public class WindfallEntry
  {
    public WindfallEntry (double amount, 
                          DateTime windfallDate, 
                          bool isRecurring, 
                          int recurringFrequency)
    {
      Amount = amount;
      WindfallDate = windfallDate;
      IsReccurring = isRecurring;
      ReccurringFrequency = recurringFrequency;
    }

    public double Amount { get; private set; }
    public bool IsReccurring { get; private set; }
    public int ReccurringFrequency { get; private set; }
    public DateTime WindfallDate { get; private set; }
  }
}

