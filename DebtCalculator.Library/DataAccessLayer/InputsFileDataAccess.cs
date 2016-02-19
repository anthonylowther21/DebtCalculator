using System;
using System.Collections.ObjectModel;
using DebtCalculatorLibrary.Services;

namespace DebtCalculatorLibrary.DataAccessLayer
{
  public class InputsFileLibrary
  {
    protected DataLayer.InputsFileDatabase db = null;
    protected static InputsFileLibrary me;

    static InputsFileLibrary()
    {
      me = new InputsFileLibrary();
    }

    protected InputsFileLibrary()
    {
      // Initis
      db = new DataLayer.InputsFileDatabase();
    }

    #region Methods
    public static void LoadOnAppLaunch(DebtApp debtApp)
    {
      me.db.LoadOnAppLaunch(debtApp);
    }

    public static void LoadInputsFile(string filePath, DebtApp debtApp)
    {
      me.db.LoadInputsFile(filePath, debtApp);
    }

    public static void SaveUserDefaults(DebtApp debtApp)
    {
      me.db.SaveUserDefaults(debtApp);
    }

    public static void SaveInputsFile(string filename, DebtApp debtApp)
    {
      me.db.SaveInputsFile(filename, debtApp);
    }

    public static string CurrentInputsFile
    {
      get { return me.db.CurrentInputsFile; }
    }

    public static Collection<string> GetSavedFiles()
    {
      return me.db.GetSavedFiles();
    }

    #endregion



  }
}

