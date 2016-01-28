using System;
using DebtCalculator.Utility;
using PropertyChanged;

namespace DebtCalculator.Library
{
  public class AmortizationEntry
  {
    public AmortizationEntry ( string debtName,      
                                    DateTime date, 
                                    double startBalance,  
                                    double interest, 
                                    double minPrincipal,  
                                    double addPrincipal, 
                                    double endBalance)
    {
      DebtName = debtName;
      Date = date;
      StartBalance = startBalance;
      MinimumInterest = interest;
      MinimumPrincipal = minPrincipal;
      AdditionalPrincipal = addPrincipal;
      TotalPayment = interest + minPrincipal + addPrincipal;
      EndBalance = endBalance;
    }

    public AmortizationEntry()
    {
    }

    public string DebtName { get; private set; }
    public DateTime Date { get; private set; }
    public double StartBalance { get; private set; }
    public double MinimumInterest { get; private set; }
    public double MinimumPrincipal { get; private set; }
    public double AdditionalPrincipal { get; private set; }
    public double TotalPayment { get; private set; }
    public double EndBalance { get; private set; }

    public void WriteToConsole(AmortizationEntry output)
    {
      string message = output.DebtName +
        ": " + DateTimeExtensions.ToShortMonthName(output.Date) + " " + output.Date.Year +
        " Starting Balance: " + output.StartBalance.ToString("C") +
        " Min Interest: " + output.MinimumInterest.ToString("C") +
        " Min Principal: " + output.MinimumPrincipal.ToString("C") +
        " Add Principal: " + output.AdditionalPrincipal.ToString("C") +
        " Total Payment: " + output.TotalPayment.ToString("C") +
        " Ending Balance: " + output.EndBalance.ToString("C");

      output.Print(message);
    }

    public string Summary
    {
      get { return (DebtName + " - " + string.Format("{0:C}", TotalPayment)); }
    }

    public string DetailSummary
    {
      get { return (string.Format("{0:C}", EndBalance) + " - " + string.Format("{0:MMMM yyyy}", Date)); }
    }

    public void Print(string message)
    {
      System.Diagnostics.Debug.WriteLine(message);
    }


  }
}

