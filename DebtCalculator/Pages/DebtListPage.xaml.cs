using System;
using System.Collections.Generic;
using DebtCalculator.Shared;
using Xamarin.Forms;
using DebtCalculator.Library;

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
      this.PushDebtPage();
    }

    public void Item_Selected(object sender, ItemTappedEventArgs e)
    {
      var listView = sender as ListView;
      listView.SelectedItem = null;
      this.PushDebtPage(e.Item as DebtEntry);
    }

    private void PushDebtPage(DebtEntry debtEntry = null)
    {
      Navigation.PushAsync(new DebtPage(debtEntry));
    }
	}

  public partial class DebtListPageXaml : BaseContentPage<DebtListPageModel>
  {
  }
}

