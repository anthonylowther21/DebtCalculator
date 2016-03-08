using System;
using System.Collections.Generic;
using DebtCalculator.Shared;
using DebtCalculator.Library;
using Xamarin.Forms;

namespace DebtCalculator.Shared
{
  public partial class SalaryListPage : SalaryListPageXaml
	{
    public SalaryListPage ()
		{
			InitializeComponent ();
		}

    public void Add_Button_Clicked(object sender, EventArgs e)
    {
      this.PushSalaryPage();
    }

    public void Item_Selected(object sender, ItemTappedEventArgs e)
    {
      var listView = sender as ListView;
      listView.SelectedItem = null;
      this.PushSalaryPage(e.Item as SalaryEntry);
    }

    private void PushSalaryPage(SalaryEntry salaryEntry = null)
    {
      Navigation.PushAsync(new SalaryPage(salaryEntry));
    }
	}

  public partial class SalaryListPageXaml : BaseContentPage<SalaryListPageModel>
  {
  }
}

