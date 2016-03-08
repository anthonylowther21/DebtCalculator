using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DebtCalculator.Shared
{
	public partial class PaymentListPage : MyBasePage
	{
    public PaymentListPage ()
		{
			InitializeComponent ();
		}

    public void Salary_Button_Clicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new SalaryListPage());
    }

    public void Windfall_Button_Clicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new WindfallListPage());
    }

    public void Snowball_Button_Clicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new SnowballPage());
    }
	}
}

