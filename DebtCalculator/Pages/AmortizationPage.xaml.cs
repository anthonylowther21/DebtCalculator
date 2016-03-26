using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DebtCalculator.Library;

namespace DebtCalculator.Shared
{
  public partial class AmortizationPage : AmortizationPageXaml
	{
    public AmortizationPage (AmortizationEntry item)
		{
      this.ViewModel.AssignAmortization(item);

			InitializeComponent ();
		}
	}

  public partial class AmortizationPageXaml : BaseContentPage<AmortizationPageModel>
  {
  }
}

