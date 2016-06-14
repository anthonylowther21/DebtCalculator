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

    public void Menu_Button_Clicked(object sender, EventArgs e)
    {
      this.Navigation.PushModalAsync (new CustomNavigationPage(new MenuPage (() => ViewModel.SetPropertyChanged(""))));
    }

    public async void ActionSheetAsync()
    {
      var result = await UserDialogs.Instance.ActionSheetAsync("Strategy", "Cancel", null, "New Snowball", "New Salary", "New Windfall");
      switch (result)
      {
        case "New Snowball":
          this.PushSnowballPage ();
          break;
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

    public void Snowball_Selected (object sender, ItemTappedEventArgs e)
    {
      var listView = sender as ListView;
      listView.SelectedItem = null;
      this.PushSnowballPage (e.Item as SnowballEntry);
    }

    private void PushSnowballPage (SnowballEntry snowballEntry = null)
    {
      Navigation.PushAsync (new SnowballPage (snowballEntry));
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

