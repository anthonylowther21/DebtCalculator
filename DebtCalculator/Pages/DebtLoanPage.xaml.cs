using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DebtCalculator.Library;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Business;

namespace DebtCalculator.Shared
{
  public partial class DebtLoanPage : DebtLoanPageXaml
	{
    public DebtLoanPage (DebtEntry debtEntry)
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

    public void Loan_Completed(object sender, EventArgs e)
    {
      NumericEntryCell cell = sender as NumericEntryCell;
      if (cell != null) 
      {
        if (cell.Text == "0" || cell.Text == string.Empty) 
        {
          this.ViewModel.LoanTerm = "1";
        }
      }
    }
	}

  public partial class DebtLoanPageXaml : BaseContentPage<DebtLoanPageModel>
  {
  }
}

