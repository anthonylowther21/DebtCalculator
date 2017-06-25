using System;
using DebtCalculator.Shared;

namespace DebtCalculator.Library
{
	public class ScenarioOptions
	{
		private string _debtName = "Sample Name";
		private DateTime _startDate = DateTime.Now;

    public ScenarioOptions()
		{
		}

		public string DebtName
		{
			get
			{
				return _debtName;
			}
			set
			{
				_debtName = value;
			}
		}

		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				_startDate = value;
			}
		}
	}
}
