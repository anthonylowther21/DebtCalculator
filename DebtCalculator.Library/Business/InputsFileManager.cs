using System;
using System.Collections.ObjectModel;
using DebtCalculatorLibrary.Services;
using DebtCalculatorLibrary.DataLayer;
using Acr.UserDialogs;
using System.IO;
using DebtCalculatorLibrary.Utility;

namespace DebtCalculatorLibrary.Business
{
  public class InputsFileManager
  {
    #region Methods
    public static void LoadOnAppLaunch(DebtApp debtApp)
    {
      InputsFileDatabase.Shared.LoadOnAppLaunch(debtApp);
    }

    public static void LoadInputsFile(string filePath, DebtApp debtApp, Action callBack)
    {
      InputsFileDatabase.Shared.LoadInputsFile(filePath, debtApp);
      callBack();
    }

    public static void SaveUserDefaults(DebtApp debtApp)
    {
      InputsFileDatabase.Shared.SaveUserDefaults(debtApp);
    }

    async public static void SaveNewInputsFile(DebtApp debtApp, Action callBack)
    {
      var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
        {
          Title = "Scenario Name",
          Text = "Sample Name",
          IsCancellable = true
        });

      if (result.Ok == true)
      {
        InputsFileDatabase.Shared.SaveInputsFile(Path.Combine(Paths.SavedFilesDirectory, result.Text), debtApp);
        if (callBack != null)
          callBack();
      }
    }

    async public static void SaveInputsFileAsync(string filename, DebtApp debtApp, Action callBack = null)
    {
      if (String.IsNullOrEmpty(InputsFileDatabase.Shared.CurrentInputsFile))
      {
        SaveNewInputsFile(debtApp, callBack);
      }
      else
      {
        InputsFileDatabase.Shared.SaveInputsFile(
          InputsFileDatabase.Shared.CurrentInputsFile, debtApp);
        if (callBack != null)
          callBack();
      }
    }

    public static string CurrentInputsFile
    {
      get { return InputsFileDatabase.Shared.CurrentInputsFile; }
    }

    public static Collection<string> GetSavedFiles()
    {
      return InputsFileDatabase.Shared.GetSavedFiles();
    }

    public static void Delete(string filename)
    {
      InputsFileDatabase.Shared.Delete(filename);
    }

    public static event EventHandler FileListChanged
    {
      add { InputsFileDatabase.Shared.FileListChanged += value; }
      remove { InputsFileDatabase.Shared.FileListChanged -= value; }
    }

    #endregion



  }
}

