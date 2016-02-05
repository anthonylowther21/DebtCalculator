using System;
using System.IO;

namespace DebtCalculatorLibrary.Utility
{
  public class Paths
  {
    public Paths()
    {
    }

    public static string ApplicationDirectory
    {
      get 
      { 
        #if __IOS__
        return Foundation.NSBundle.MainBundle.ResourcePath; 
        #elif __ANDROID__

        #endif
      }
    }

    public static string DefaultsDirectory
    {
      get { return DocumentsDirectoryRoot + Path.DirectorySeparatorChar + "Defaults"; }
    }

    public static string SavedFilesDirectory
    {
      get { return DocumentsDirectoryRoot + Path.DirectorySeparatorChar + "SavedFiles"; }
    }

    public static string DocumentsDirectoryRoot 
    {
      get
      { 
        #if __IOS__
        return Foundation.NSFileManager.DefaultManager.GetUrls(
          Foundation.NSSearchPathDirectory.DocumentDirectory, Foundation.NSSearchPathDomain.User)[0].Path;
        #elif __ANDROID__
        return Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        #endif
      }
    }

    public static string DefaultInputsPath
    {
      get { return DefaultsDirectory + Path.DirectorySeparatorChar + "userDefaults.dc"; }
    }
  }
}

