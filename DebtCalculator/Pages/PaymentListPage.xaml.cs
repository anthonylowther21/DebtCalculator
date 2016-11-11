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
      this.Appearing += Handle_Appearing;
		}

    void Handle_Appearing (object sender, EventArgs e)
    {
      if (this.ViewModel.EmptyMessage == null)
        this.Content = _listView;
      else
        this.Content = _emptyMessageLayout;
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
      var result = await UserDialogs.Instance.ActionSheetAsync(null, "Cancel", null, null, "New Snowball", "New Salary", "New Windfall");
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

    public void Item_Selected (object sender, ItemTappedEventArgs e)
    {
      var listView = sender as ListView;
      listView.SelectedItem = null;

      if (e.Item is SnowballEntry)
        this.PushSnowballPage (e.Item as SnowballEntry);
      else if (e.Item is SalaryEntry)
        this.PushSalaryPage (e.Item as SalaryEntry);
      else if (e.Item is WindfallEntry)
        this.PushWindfallPage (e.Item as WindfallEntry);
    }

    private void PushSnowballPage (SnowballEntry snowballEntry = null)
    {
      Navigation.PushAsync (new SnowballPage (snowballEntry));
    }

    private void PushSalaryPage(SalaryEntry salaryEntry = null)
    {
      Navigation.PushAsync(new SalaryPage(salaryEntry));
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

