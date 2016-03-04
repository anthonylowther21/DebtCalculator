using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.Utility;
using System.IO;
using XLabs.Platform.Services.IO;
using DebtCalculatorLibrary.DataLayer;
using Acr.UserDialogs;
using DebtCalculatorLibrary.Business;

namespace DebtCalculator.Shared
{
  [ImplementPropertyChanged]
  public class HomePageModel : FreshBasePageModel
  {
    private App _mainApp;

    public HomePageModel ()
    {
    }

    public ObservableCollection<string> Files { get; set; }


    public override void Init (object initData)
    {
      _mainApp = initData as App;

      Files = new ObservableCollection<string>();
      // Binding
      foreach (string file in InputsFileManager.GetSavedFiles())
        Files.Add(Path.GetFileName(file));
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      //You can do stuff here
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      SelectedFile = null;
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
      Files = new ObservableCollection<string>();
      // Binding
      foreach (string file in InputsFileManager.GetSavedFiles())
        Files.Add(Path.GetFileName(file));
    }

    string _selectedFile;

    public string SelectedFile 
    {
      get 
      {
        return _selectedFile;
      }
      set 
      {
        _selectedFile = value;
        if (value != null)
        {
          FileSelected.Execute(value);
        }
      }
    }

    public Command SaveFile 
    {
      get 
      {
        return new Command<string> ((s) => 
          {
            this.PromptWithTextCancel();
          });
      }
    }

    public Command DeleteFile 
    {
      get 
      {
        return new Command<string> ((s) => 
          {
            File.Delete(Path.Combine(Paths.SavedFilesDirectory, s));
          });
      }
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
        Files.Add(Path.GetFileName(result.Text));
        _mainApp.SetSideMenuVisibility(false);
      }
    }

    public Command<string> FileSelected 
    {
      get 
      {
        return new Command<string> ( (file) => 
          {
            InputsFileManager.LoadInputsFile(Path.Combine(Paths.SavedFilesDirectory, file), DebtApp.Shared);
            //CoreMethods.PopToRoot(true);

            _mainApp.SetSideMenuVisibility(false);
            //_mainApp.MainPage.Navigation.PushAsync(new CustomTabbedPage());
            //NavigationPage np = this.CurrentPage as NavigationPage;
            //(this.CurrentPage as NavigationPage).PushAsync(new CustomTabbedPage());
            //CoreMethods.PushNewNavigationServiceModal(new CustomTabbedPage());

            SelectedFile = null;
          });
      }
    }
  }
}

