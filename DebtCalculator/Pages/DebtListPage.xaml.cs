using System;
using System.Collections.Generic;
using DebtCalculator.Shared;
using Xamarin.Forms;
using DebtCalculator.Library;
using Acr.UserDialogs;

namespace DebtCalculator.Shared
{
  public partial class DebtListPage : DebtListPageXaml
	{
    public DebtListPage ()
		{
			InitializeComponent ();
		}
      
    public void Add_Button_Clicked(object sender, EventArgs e)
    {
      this.ActionSheetAsync();
    }

    public async void ActionSheetAsync()
    {
      var result = await UserDialogs.Instance.ActionSheetAsync("New Payment", "Cancel", null, "Loan Debt", "Credit Card");
      switch (result)
      {
        case "Loan Debt":
          this.Navigation.PushAsync(new DebtLoanPage(new DebtEntry(DebtType.Loan)));
          break;
        case "Credit Card":
          this.Navigation.PushAsync(new DebtCreditCardPage(new DebtEntry(DebtType.CreditCard)));
          break;
        default:
          break;
      }
    }

    public void Item_Selected(object sender, ItemTappedEventArgs e)
    {
      var listView = sender as ListView;
      listView.SelectedItem = null;
      this.PushDebtPage(e.Item as DebtEntry);
    }

    private void PushDebtPage(DebtEntry debtEntry)
    {
      if (debtEntry.DebtType == DebtType.Loan)
      {
        this.Navigation.PushAsync(new DebtLoanPage(debtEntry));
      }
      else if (debtEntry.DebtType == DebtType.CreditCard)
      {
        this.Navigation.PushAsync(new DebtCreditCardPage(debtEntry));
      }
    }
	}

  public partial class DebtListPageXaml : BaseContentPage<DebtListPageModel>
  {
  }
}

