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
  public class MenuPageModel : BaseViewModel
  {
    public MenuPageModel ()
    {
      InputsFileManager.FileListChanged += (object sender, EventArgs e) => LoadData();
    }

    public ObservableCollection<ScenarioItemViewModel> Files { get; set; } = new ObservableCollection<ScenarioItemViewModel>();

    public void LoadData()
    {
      // Binding
      Files.Clear();
      foreach (string file in InputsFileManager.GetSavedFiles())
        Files.Add(new ScenarioItemViewModel() { Name = file });
    }
  }
}

