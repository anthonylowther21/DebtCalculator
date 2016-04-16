using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DebtCalculator.Library;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;

namespace DebtCalculator.Shared
{
  public partial class DebtCreditCardPage : DebtCreditCardPageXaml
	{
    public DebtCreditCardPage (DebtEntry debtEntry)
		{
      this.ViewModel.AssignDebt(debtEntry);

			InitializeComponent ();
		}

    public void Save_Button_Clicked(object sender, EventArgs e)
    {
      this.ViewModel.SaveDebt(() => Navigation.PopAsync(true));
    }

    public void Delete_Button_Clicked(object sender, EventArgs e)
    {
      this.ViewModel.DeleteDebt(() => Navigation.PopAsync(true));
    }
	}

  public partial class DebtCreditCardPageXaml : BaseContentPage<DebtPageCreditCardModel>
  {
  }
}

