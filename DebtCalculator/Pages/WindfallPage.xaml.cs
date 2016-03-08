using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DebtCalculator.Library;

namespace DebtCalculator.Shared
{
  public partial class WindfallPage : WindfallPageXaml
	{
    public WindfallPage (WindfallEntry windfall)
		{
      this.ViewModel.AssignWindfall(windfall);

			InitializeComponent ();
		}

    public void Save_Button_Clicked(object sender, EventArgs e)
    {
      this.ViewModel.SaveWindfall();
      this.Navigation.PopAsync(true);
    }

    public void Delete_Button_Clicked(object sender, EventArgs e)
    {
      this.ViewModel.DeleteWindfall();
      this.Navigation.PopAsync(true);
    }
	}

  public partial class WindfallPageXaml : BaseContentPage<WindfallPageModel>
  {
  }
}

