using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DebtCalculator.Shared
{
  public partial class SnowballPage : SnowballPageXaml
	{
    public SnowballPage ()
		{
			InitializeComponent ();
		}

    public void Save_Button_Clicked(object sender, EventArgs e)
    {
      ViewModel.SaveSnowball(() => Navigation.PopAsync(true));
    }
	}

  public partial class SnowballPageXaml : BaseContentPage<SnowballPageModel>
  {
  }
}

