using System;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;
using DebtCalculator.Shared;

namespace DebtCalculator
{
	public class ScenarioOptionsPageModel : BaseViewModel
	{
		public ScenarioOptionsPageModel ()
		{
		}

		public string Name 
    { 
      get { return ""; }
      set 
      {
        string test = value;
      }
    }
    public string StartDate { get; private set; }
	}
}
