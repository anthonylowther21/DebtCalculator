using System;
using System.Collections.Generic;
using Xamarin.Forms;
using DebtCalculator.Library;
using Acr.UserDialogs;

namespace DebtCalculator.Shared
{
  public partial class PaymentListPage : PaymentListPageXaml
	{
    public PaymentListPage ()
		{
			InitializeComponent ();
		}

    public void Add_Button_Clicked(object sender, EventArgs e)
    {
      ActionSheetAsync();
    }

    public async void ActionSheetAsync()
    {
      var result = await UserDialogs.Instance.ActionSheetAsync("New Payment", "Cancel", null, "New Salary", "New Windfall");
      switch (result)
      {
        case "New Salary":
          this.PushSalaryPage();
          break;
        case "New Windfall":
          this.PushWindfallPage();
          break;
        default:
          break;
      }
    }

    void Snowball_Unfocused (object sender, FocusEventArgs e)
    {
      ViewModel.SaveSnowball();
    }

    public void Add_Salary_Clicked(object sender, EventArgs e)
    {
      this.PushSalaryPage();
    }

    public void Salary_Selected(object sender, ItemTappedEventArgs e)
    {
      var listView = sender as ListView;
      listView.SelectedItem = null;
      this.PushSalaryPage(e.Item as SalaryEntry);
    }

    private void PushSalaryPage(SalaryEntry salaryEntry = null)
    {
      Navigation.PushAsync(new SalaryPage(salaryEntry));
    }

    public void Add_Windfall_Clicked(object sender, EventArgs e)
    {
      this.PushWindfallPage();
    }

    public void Windfall_Selected(object sender, ItemTappedEventArgs e)
    {
      var listView = sender as ListView;
      listView.SelectedItem = null;
      this.PushWindfallPage(e.Item as WindfallEntry);
    }

    private void PushWindfallPage(WindfallEntry windfallEntry = null)
    {
      Navigation.PushAsync(new WindfallPage(windfallEntry));
    }
	}

  public partial class PaymentListPageXaml : BaseContentPage<PaymentListPageModel>
  {
  }
}

