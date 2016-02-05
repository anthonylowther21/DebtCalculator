﻿using System;
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

namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class LeftSlideoutPageModel : FreshBasePageModel
  {
    IDatabaseService _databaseService;

    public LeftSlideoutPageModel (IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public ObservableCollection<string> Files { get; set; }

    public override void Init (object initData)
    {
      Files = new ObservableCollection<string>();
      // Binding

      if (Directory.Exists(Paths.SavedFilesDirectory))
      foreach (string file in Directory.GetFiles(Paths.SavedFilesDirectory))
          File.Delete(Path.GetFileName(file));
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
      if (Directory.Exists(Paths.SavedFilesDirectory))
      foreach (string file in Directory.GetFiles(Paths.SavedFilesDirectory))
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
            InputsFileDatabase data = new InputsFileDatabase();
            data.SaveInputsFile(Path.Combine(Paths.SavedFilesDirectory, Guid.NewGuid().ToString()), (DatabaseService)_databaseService);
            CoreMethods.PopToRoot(true);
            Files.Add(Path.GetFileName(data.CurrentInputsFile));
          });
      }
    }

    public Command<string> FileSelected 
    {
      get 
      {
        return new Command<string> ( (file) => 
          {
            InputsFileDatabase data = new InputsFileDatabase();
            DatabaseService db = _databaseService as DatabaseService;
            _databaseService = data.LoadInputsFile(Path.Combine(Paths.SavedFilesDirectory, file), db);
            CoreMethods.PopToRoot(true);

            SelectedFile = null;
            _databaseService.SetNeedsRefresh();
            //CoreMethods.PushPageModel<DebtListPageModel> (debt);
          });
      }
    }
  }
}

