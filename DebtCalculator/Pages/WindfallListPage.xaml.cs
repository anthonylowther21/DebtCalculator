using System;
using System.Collections.Generic;
using DebtCalculator.Shared;
using DebtCalculator.Library;
using Xamarin.Forms;

namespace DebtCalculator.Shared
{
  public partial class WindfallListPage : WindfallListPageXaml
	{
    public WindfallListPage ()
		{
			InitializeComponent ();
		}

    public void Add_Button_Clicked(object sender, EventArgs e)
    {
      this.PushWindfallPage();
    }

    public void Item_Selected(object sender, ItemTappedEventArgs e)
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

  public partial class WindfallListPageXaml : BaseContentPage<WindfallListPageModel>
  {
  }
}

