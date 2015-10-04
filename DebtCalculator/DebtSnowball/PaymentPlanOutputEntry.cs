using System;

namespace DebtCalculator
{
	public class PaymentPlanOutputEntry
	{
        static public PaymentPlanOutputEntry Create(string debtName, DateTime date, double startBalance, 
          double interest, double minPrincipal, double addPrinciple, double endBalance)
        {
            return new PaymentPlanOutputEntry()
            {
                DebtName = debtName,
                Date = date,
                StartBalance = startBalance,
                MinimumInterest = interest,
                MinimumPrincipal = minPrincipal,
                AdditionalPrincipal = addPrinciple,
                TotalPayment = interest + minPrincipal + addPrinciple,
                EndBalance = endBalance
            };
                
        }

        protected PaymentPlanOutputEntry ()
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

        static public void WriteToConsole(PaymentPlanOutputEntry output)
        {
            Console.Write (output.DebtName);
            Console.Write (": " + DateTimeExtensions.ToShortMonthName(output.Date) + " " + output.Date.Year);
            Console.Write (" Starting Balance: " + output.StartBalance.ToString("C"));
            Console.Write (" Min Interest: " + output.MinimumInterest.ToString("C"));
            Console.Write (" Min Principal: " + output.MinimumPrincipal.ToString("C"));
            Console.Write (" Add Principal: " + output.AdditionalPrincipal.ToString("C"));
            Console.Write (" Total Payment: " + output.TotalPayment.ToString("C"));
            Console.Write (" Ending Balance: " + output.EndBalance.ToString("C"));

            Console.WriteLine();
        }
    }
}

