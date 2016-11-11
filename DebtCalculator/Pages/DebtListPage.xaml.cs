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
      this.ActionSheetAsync();
    }

    public void Menu_Button_Clicked (object sender, EventArgs e)
    {
      this.Navigation.PushModalAsync (new CustomNavigationPage (new MenuPage ()));
    }

    public async void ActionSheetAsync()
    {
      var result = await UserDialogs.Instance.ActionSheetAsync(null, "Cancel", null, null, "House Loan", 
                                                               "Car Loan", "Student Loan", "Other Loan", "Credit Card");
      switch (result)
      {
        case "House Loan":
          await this.Navigation.PushAsync(new DebtLoanPage(new DebtEntry(DebtType.HouseLoan)));
          break;
        case "Car Loan":
          await this.Navigation.PushAsync (new DebtLoanPage (new DebtEntry (DebtType.CarLoan)));
          break;
        case "Student Loan":
          await this.Navigation.PushAsync (new DebtLoanPage (new DebtEntry (DebtType.StudentLoan)));
          break;
        case "Other Loan":
          await this.Navigation.PushAsync (new DebtLoanPage (new DebtEntry (DebtType.OtherLoan)));
          break;
        case "Credit Card":
          await this.Navigation.PushAsync(new DebtCreditCardPage(new DebtEntry(DebtType.CreditCard)));
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
      if (debtEntry.DebtType == DebtType.HouseLoan || debtEntry.DebtType == DebtType.CarLoan || 
          debtEntry.DebtType == DebtType.StudentLoan || debtEntry.DebtType == DebtType.OtherLoan)
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

