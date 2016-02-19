using System;
using System.Collections.ObjectModel;
using DebtCalculatorLibrary.DataAccessLayer;
using DebtCalculatorLibrary.Services;

namespace DebtCalculatorLibrary.Business
{
  public class InputsFileManager
  {
    #region Methods
    public static void LoadOnAppLaunch(DebtApp debtApp)
    {
      InputsFileLibrary.LoadOnAppLaunch(debtApp);
    }

    public static void LoadInputsFile(string filePath, DebtApp debtApp)
    {
      InputsFileLibrary.LoadInputsFile(filePath, debtApp);
    }

    public static void SaveUserDefaults(DebtApp debtApp)
    {
      InputsFileLibrary.SaveUserDefaults(debtApp);
    }

    public static void SaveInputsFile(string filename, DebtApp debtApp)
    {
      InputsFileLibrary.SaveInputsFile(filename, debtApp);
    }

    public static string CurrentInputsFile
    {
      get { return InputsFileLibrary.CurrentInputsFile; }
    }

    public static Collection<string> GetSavedFiles()
    {
      return InputsFileLibrary.GetSavedFiles();
    }
    #endregion



  }
}

