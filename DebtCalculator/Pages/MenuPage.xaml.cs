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
    public MenuPage ()
		{
      this.ViewModel.LoadData();
			InitializeComponent ();
		}

    public void OnDelete (object sender, EventArgs e) 
    {
      var mi = ((MenuItem)sender);
      string filename = Path.Combine(Paths.SavedFilesDirectory, mi.CommandParameter.ToString());
      InputsFileManager.Delete(filename);
    }

    public void File_Selected (object sender, ItemTappedEventArgs e)
    {
      InputsFileManager.LoadInputsFile(Path.Combine(Paths.SavedFilesDirectory, (e.Item as ScenarioItemViewModel).Name), DebtApp.Shared, 
        () =>  
        {
          this.Navigation.PopModalAsync();
        });
    }

    public void Save_Button_Clicked(object sender, EventArgs e)
    {
      InputsFileManager.SaveNewInputsFile(DebtApp.Shared, 
        () => 
        {
          this.Navigation.PopModalAsync();
        });
        
    }

    public void Close_Button_Clicked(object sender, EventArgs e)
    {
      this.Navigation.PopModalAsync ();
    }
	}

  public partial class MenuPageXaml : BaseContentPage<MenuPageModel>
  {
  }
}

