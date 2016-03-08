using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DebtCalculator.Library;

namespace DebtCalculator.Shared
{
  public partial class SalaryPage : SalaryPageXaml
	{
    public SalaryPage (SalaryEntry salary)
		{
      this.ViewModel.AssignSalary(salary);

			InitializeComponent ();
		}

    public void Save_Button_Clicked(object sender, EventArgs e)
    {
      this.ViewModel.SaveSalary();
      this.Navigation.PopAsync(true);
    }

    public void Delete_Button_Clicked(object sender, EventArgs e)
    {
      this.ViewModel.DeleteSalary();
      this.Navigation.PopAsync(true);
    }
	}

  public partial class SalaryPageXaml : BaseContentPage<SalaryPageModel>
  {
  }
}

