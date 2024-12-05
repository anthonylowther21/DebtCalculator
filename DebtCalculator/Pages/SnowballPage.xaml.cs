using System;
using System.Collections.Generic;
using DebtCalculator.Library;
using Xamarin.Forms;

namespace DebtCalculator.Shared
{
  public partial class SnowballPage : SnowballPageXaml
	{
    public SnowballPage (SnowballEntry entry)
		{
      this.ViewModel.AssignSnowball (entry);

			InitializeComponent ();
		}

    public void Save_Button_Clicked(object sender, EventArgs e)
    {
      if (ViewModel.Validate ((title, text) => ShowModalMessage (title, text)) == true) 
      {
        ViewModel.Save (() => Navigation.PopAsync (true));
      }
    }

    public void Delete_Button_Clicked(object sender, EventArgs e)
    {
      ViewModel.Delete (() => Navigation.PopAsync (true));
    }
	}

  public partial class SnowballPageXaml : BaseContentPage<SnowballPageModel>
  {
  }
}

