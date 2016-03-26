using System;
using System.Collections.Generic;
using DebtCalculator.Shared;
using Xamarin.Forms;
using System.IO;
using DebtCalculatorLibrary.Utility;
using DebtCalculatorLibrary.Business;
using Acr.UserDialogs;
using DebtCalculatorLibrary.Services;

namespace DebtCalculator.Shared
{
  public partial class MenuPage : MenuPageXaml
	{
    MasterDetailPage _masterDetailPage;

    public MenuPage (MasterDetailPage masterDetailPage)
		{
      this.ViewModel.LoadData();
      _masterDetailPage = masterDetailPage;
			InitializeComponent ();
		}

    public void OnDelete (object sender, EventArgs e) 
    {
      var mi = ((MenuItem)sender);
      string filename = Path.Combine(Paths.SavedFilesDirectory, mi.CommandParameter.ToString());
//      if (InputsFileManager.CurrentInputsFile != filename)
//      {
      InputsFileManager.Delete(filename);
//      }
    }

    public void File_Selected (object sender, ItemTappedEventArgs e)
    {
      InputsFileManager.LoadInputsFile(Path.Combine(Paths.SavedFilesDirectory, e.Item.ToString()), DebtApp.Shared, 
        () =>  
        {
          _masterDetailPage.IsPresented = false;
        });
    }

    public void Save_Button_Clicked(object sender, EventArgs e)
    {
      InputsFileManager.SaveNewInputsFile(DebtApp.Shared, 
        () => 
        {
          _masterDetailPage.IsPresented = false;
        });
        
    }
	}

  public partial class MenuPageXaml : BaseContentPage<MenuPageModel>
  {
  }
}

