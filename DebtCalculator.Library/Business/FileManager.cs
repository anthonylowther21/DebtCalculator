/*
 * FILE : InputsFileLibrary.cs
 * 
 * AUTHOR : Anthony Lowther, Craft Designs, Inc
 * 
 * DESCRIPTION : This is the file used to access the current input file
 * 
 */

/*
* $Log:   //DCM/archives/SOA Development/SOA-MC130J-TOLD-IOS/Source/SOA-MC130J-TOLD-IOS/SOA-MC130J-TOLD-IOS/DataAccessLayer/InputsFileLibrary.cs-arc  $
// 
//    Rev 1.1   Feb 12 2015 15:10:02   anthony.lowther
// Use InputsFileManager for loading aircraft inputs
// 
//    Rev 1.0   Feb 12 2015 13:50:38   anthony.lowther
// Initial revision.
// 
//    Rev 1.0   Jan 14 2015 12:51:20   anthony.lowther
// Initial revision.
*
* $Header:   //DCM/archives/SOA Development/SOA-MC130J-TOLD-IOS/Source/SOA-MC130J-TOLD-IOS/SOA-MC130J-TOLD-IOS/DataAccessLayer/InputsFileLibrary.cs-arc   1.1   Feb 12 2015 15:10:02   anthony.lowther  $
* 
*/

using System;
using MissionPlanning.PerformanceModel;
using CDI_CARD_GENERATOR;
using System.Collections.ObjectModel;

namespace SOA_MC130J_TOLD_IOS.DataAccessLayer
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
    public static void LoadOnAppLaunch(AircraftObject ao)
    {
      me.db.LoadOnAppLaunch(ao);
    }

    public static void LoadInputsFile(string filePath, AircraftObject ao)
    {
      me.db.LoadInputsFile(filePath, ao);
    }

    public static void LoadDefaultInputsFile(AircraftObject ao)
    {
      me.db.LoadDefaultInputsFile(ao);
    }

    public static void LoadFpmDefaults(AircraftObject ao)
    {
      me.db.LoadFpmDefaults(ao);
    }

    public static void RestoreUserOrFpmDefaults(AircraftObject ao)
    {
      me.db.RestoreUserOrFpmDefaults(ao);
    }

    public static void SaveUserDefaults(AircraftObject ao)
    {
      me.db.SaveUserDefaults(ao);
    }

    public static void SaveInputsFile(string filename, AircraftObject ao)
    {
      me.db.SaveInputsFile(filename, ao);
    }

    public static string CurrentInputsFile
    {
      get { return me.db.CurrentInputsFile; }
    }

    public static string UserDefaultInputsFile
    {
      get { return me.db.UserDefaultInputsFile; }
    }

    #endregion



  }
}

