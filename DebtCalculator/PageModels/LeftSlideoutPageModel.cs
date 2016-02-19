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

namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class LeftSlideoutPageModel : FreshBasePageModel
  {
    public LeftSlideoutPageModel ()
    {
    }

    public ObservableCollection<string> Files { get; set; }

    public override void Init (object initData)
    {
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
        Files.Add(Path.GetFileName(result.Text));
      }
    }

    public Command<string> FileSelected 
    {
      get 
      {
        return new Command<string> ( (file) => 
          {
            InputsFileManager.LoadInputsFile(Path.Combine(Paths.SavedFilesDirectory, file), DebtApp.Shared);
            CoreMethods.PopToRoot(true);

            (this.CurrentPage as NavigationPage).PushAsync(new CustomTabbedPage());

            SelectedFile = null;
          });
      }
    }
  }
}

