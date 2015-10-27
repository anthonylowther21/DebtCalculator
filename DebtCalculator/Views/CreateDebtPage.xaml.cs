using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DebtCalculator.Views
{
  public partial class CreateDebtPage : ContentPage
  {
    INavigation _navigation = null;

    public CreateDebtPage(INavigation navigation)
    {
      //this.BindingContext = new DebtEntryViewModel(navigation);

      InitializeComponent();
    }
  }
}

