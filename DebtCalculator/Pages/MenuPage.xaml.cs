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
      if (InputsFileManager.CurrentInputsFile != filename)
      {
        File.Delete(filename);
        this.ViewModel.Files.Remove(mi.CommandParameter.ToString());
      }
    }

    public void File_Selected (object sender, ItemTappedEventArgs e)
    {
      ListView list = sender as ListView;
      list.SelectedItem = null;
      InputsFileManager.LoadInputsFile(Path.Combine(Paths.SavedFilesDirectory, e.Item.ToString()), DebtApp.Shared);
      _masterDetailPage.IsPresented = false;
    }

    public void Save_Button_Clicked(object sender, EventArgs e)
    {
      PromptWithTextCancel();
    }

    async void PromptWithTextCancel() 
    {
      var result = await UserDialogs.Instance.PromptAsync(new PromptConfig 
        {
          Title = "Scenario Name",
          Text = "Existing Text",
          IsCancellable = true
        });

      if (result.Ok == true)
      {
        InputsFileManager.SaveInputsFile(Path.Combine(Paths.SavedFilesDirectory, result.Text), DebtApp.Shared);
        InputsFileManager.LoadInputsFile(Path.Combine(Paths.SavedFilesDirectory, result.Text), DebtApp.Shared);
        this.ViewModel.Files.Add(Path.GetFileName(result.Text));
        _masterDetailPage.IsPresented = false;
      }
    }
	}

  public partial class MenuPageXaml : BaseContentPage<MenuPageModel>
  {
  }
}

