using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DebtCalculator.Shared
{
  public partial class SummaryPage : SummaryPageXaml
	{
    public SummaryPage ()
		{
			InitializeComponent ();
		}

    protected override void OnAppearing()
    {
      this.ViewModel.LoadData();
      base.OnAppearing();
    }
	}

  public partial class SummaryPageXaml : BaseContentPage<SummaryPageModel>
  {
  }
}

