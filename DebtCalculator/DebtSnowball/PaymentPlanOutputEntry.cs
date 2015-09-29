using System;

namespace DebtCalculator
{
	public class PaymentPlanOutputEntry
	{
		public PaymentPlanOutputEntry ()
		{
		}

		public DateTime CurrentMonth { get; set; }
		public double StartBalance { get; set; }
		public double MinimumInterest { get; set; }
		public double MinimumPrincipal { get; set; }
		public double AdditionalPrincipal { get; set; }
		public double TotalPayment { get; set; }
		public double EndBalance { get; set; }
	}
}

