using System;
using System.Collections.ObjectModel;
using System.Xml;
using System.IO;
using DebtCalculatorLibrary.Services;
using System.Xml.Serialization;
using DebtCalculator.Library;
using DebtCalculatorLibrary.Utility;

namespace DebtCalculatorLibrary.DataLayer
{
  public class InputsFileDatabase
  {
    #region Members

    private string _defaultInputsFile;
    private string _currentInputsFile;

    private const string FileVersionMajor = "1";
    private const string FileVersionMinor = "0";

    #endregion

    public string CurrentInputsFile
    {
      get { return _currentInputsFile; }
    }

    public string UserDefaultInputsFile
    {
      get { return _defaultInputsFile; }
    }

    #region 'sters
    public InputsFileDatabase()
    {
      _defaultInputsFile = DebtCalculatorLibrary.Utility.Paths.DefaultInputsPath;
      _currentInputsFile = string.Empty;
    }

    /// <summary>
    /// default destructor
    /// </summary>
    ~InputsFileDatabase()
    {
      _defaultInputsFile = null;
      _currentInputsFile = null;
    }
    #endregion

    #region Methods

    public void LoadOnAppLaunch(DatabaseService ao)
    {
      if (File.Exists(_defaultInputsFile))
      {
        //LoadDefaultInputsFile(ref ao);
      }
    }

    public void LoadDefaultInputsFile(DatabaseService ao)
    {
      //LoadInputsFile(_defaultInputsFile, ref ao);
      _currentInputsFile = string.Empty;
    }

    /// <summary>
    /// Function to load inputs for the aircraft from a save file.
    /// </summary>
    /// <param name="bFromInit">If we are getting inputs from application open</param>
    /// <param name="bUpdateAIUserDefault"></param>
    public DatabaseService LoadInputsFile(string openFilePath, DatabaseService ao)
    {
      ao.GetDebtManager().Debts.Clear();
      ao.GetPaymentManager().WindfallEntries.Clear();
      ao.GetPaymentManager().SalaryEntries.Clear();
      ao.GetPaymentManager().SnowballAmount = 0;

      _currentInputsFile = openFilePath;

      foreach (var item in File.ReadAllLines(openFilePath))
      {
        Console.WriteLine(item + "\n");
      }

      try
      {
        using (XmlReader readInputs = XmlReader.Create(openFilePath)) 
        {
          while (readInputs.Read())
          {
            //only detect start elements.
            if (readInputs.IsStartElement())
            {
              //Get element name and switch on it
              switch (readInputs.Name)
              {
                case "Debts":
                  //Detect this element.
                  Console.WriteLine("Start <Debts> element.");
                  break;
                case "Payments":
                  //Detect this element.
                  Console.WriteLine("Start <Payments> element.");
                  break;
                case "DebtEntry":
                  {
                    Console.WriteLine("Start <DebtEntry> element.");
                    ao.GetDebtManager().Debts.Add(
                      new DebtEntry(
                        (string)readInputs["Name"],
                        Double.Parse(readInputs["StartingBalance"]),
                        Double.Parse(readInputs["CurrentBalance"]),
                        Double.Parse(readInputs["YearlyInterestRate"]),
                        Int32.Parse(readInputs["LoanTerm"])));
                      break;
                  }
                case "SalaryEntry":
                  {
                    Console.WriteLine("Start <SalaryEntry> element.");
                    ao.GetPaymentManager().SalaryEntries.Add(
                      new SalaryEntry(
                        Double.Parse(readInputs["StartingSalary"]),
                        Double.Parse(readInputs["YearlySnowballIncreasePercent"]),
                        DateTime.Parse(readInputs["YearlyIncreaseAppliedDate"])));

                    break;
                  }
                case "WindfallEntry":
                  {
                    Console.WriteLine("Start <SalaryEntry> element.");
                    ao.GetPaymentManager().WindfallEntries.Add(
                      new WindfallEntry(
                        Double.Parse(readInputs["WindfallAmount"]),
                        DateTime.Parse(readInputs["WindfallDate"]),
                        Boolean.Parse(readInputs["IsRecurring"]),
                        Int32.Parse(readInputs["RecurringFrequency"])));
                    break;
                  }
                case "Snowball":
                  {
                    Console.WriteLine("Start <Snowball> element.");
                    ao.GetPaymentManager().SnowballAmount = Double.Parse(readInputs["SnowballAmount"]);
                    break;
                  }
              }
            }
          }
          readInputs.Close();
        }
      }
      catch (Exception ex)
      {
        //if (false == bFromInit)
        //{
        //  // only tell the user if he did it himself
        //  //MessageBox.Show(strFileName + " did not load correctly.  Please check the file.", "File Not Loaded", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //  //Toast.MakeText(this, m_strOpenFileName + " did not load correctly.  Please check the file.", ToastLength.Long).Show();
        //}

        return ao;
      }
      return ao;

//      _currentInputsFile = openFilePath;
//
//      string fName = null, dName = null, dValue = null, name = null, value1 = null, sName = null, VersionMajor = null, VersionMinor = null, AircraftID = null;
//      string modelVersion = null, modelDate = null, dataVersion = null, dataDate = null;
//      AdditionalInputsObject ag = null;
//
//      try
//      {
//        using (XmlReader readInputs = XmlReader.Create(openFilePath)) 
//        {
//          while (readInputs.Read())
//          {
//            //only detect start elements.
//            if (readInputs.IsStartElement())
//            {
//              //Get element name and switch on it
//              switch (readInputs.Name)
//              {
//                case "InputInfo":
//                  //Detect this element.
//                  Console.WriteLine("Start <InputInfo> element.");
//                  break;
//
//                case "Inputs":
//                  //Detect this element.
//                  Console.WriteLine("Start <Inputs> element.");
//                  break;
//
//                case "FileInfo":
//                  VersionMajor = readInputs["FileVersionMajor"];
//                  VersionMinor = readInputs["FileVersionMinor"];
//                  /* Need to determine the appropriate course of action if the major file version dos not equal....Will mean that the file format is not compatible */
//                  if (VersionMajor != TOLDFileVersionMajor)
//                  {
//                    //!!! Need to let the user know and abort the file load
//                  }
//                  break;
//
//                case "AircraftInfo":
//                  AircraftID = readInputs["AircraftID"];
//                  modelVersion = readInputs["ModelVersion"];
//                  modelDate = readInputs["ModelDate"];
//                  dataVersion = readInputs["DataVersion"];
//                  dataDate = readInputs["DataDate"];
//
//                  break;
//
//                case "Input":
//                  //Detect this element.
//                  Console.WriteLine("Start <Input> element.");
//                  //Search for the name on this current node   
//                  fName = readInputs["FieldName"];
//
//                  Console.WriteLine("The string is " + fName);
//                  dName = readInputs["DisplayName"];
//
//                  dValue = readInputs["Value"];
//
//
//                  //TBD need to know if input is enumerated, integer, string,....
//                  if (ao.TheFields.ContainsKey(fName))          //doesn't like this
//                  {
//                    ao.TheFields[fName].Value = Convert.ToDouble(dValue);
//                    if (true == ao.TheFields[fName].NonFPMInput)
//                    {
//                      ao.TheFields[fName].DisplayName = dName;
//                    }
//                  }
//                  break;
//
//                case "AdditionalInputSection":
//                  //Detect this element
//                  Console.WriteLine("Start <AdditionalInputSection> element.");
//                  sName = readInputs["SectionName"];
//
//                  ag = ao.AdditionalInputs[sName];
//                  break;
//
//                case "AdditionalInputs":
//                  //Detect this element
//                  Console.WriteLine("Start <AdditionalInputs> element.");
//                  name = readInputs["Name"];
//                  value1 = readInputs["ValueSet"];
//
//                  foreach (AdditionalInputObject aio in ag.Inputs)
//                  {
//                    if (aio.Name == name)
//                    {
//                      aio.ValueSet = Convert.ToDouble(value1);
//                      //if (true == bUpdateAIUserDefault)
//                      //{
//                      //  aio.UserDefaultValue = aio.ValueSet;
//                      //}
//                      int nIndex1 = ag.Inputs.IndexOf(aio);
//                      ag.Inputs.RemoveAt(nIndex1);
//                      ag.Inputs.Insert(nIndex1, aio);
//                      break;
//                    }
//                  }
//                  break;
//              }
//            }
//          }
//          readInputs.Close();
//        }
//      }
//      catch
//      {
//        //if (false == bFromInit)
//        //{
//        //  // only tell the user if he did it himself
//        //  //MessageBox.Show(strFileName + " did not load correctly.  Please check the file.", "File Not Loaded", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
//        //  //Toast.MakeText(this, m_strOpenFileName + " did not load correctly.  Please check the file.", ToastLength.Long).Show();
//        //}
//      }


    }

    public void LoadFpmDefaults(IDatabaseService ao)
    {
//      _currentInputsFile = string.Empty;
//
//      foreach (FieldInfo fi in ao.TheFields.Values)
//      {
//        if (false == fi.AssignedFromPFPS)
//        {
//          // only reset the value if it is not locked by the mission planner
//          fi.Value = (true == fi.ForceFPMDefault) ? fi.ForceFPMDefaultValue : fi.DefaultValue;
//
//          if ((true == fi.NonFPMInput) && (-1 == fi.Precision))
//          {
//            fi.DisplayName = string.Empty;
//          }
//        }
//      }
//
//      foreach (AdditionalInputsObject aiso in ao.AdditionalInputs.Values)
//      {
//        if (null == aiso.WayPoint)
//        {
//          for (int ii = 0; ii < aiso.Inputs.Count; ii++)
//          {
//            AdditionalInputObject aio = aiso.Inputs[ii];
//            aio.ValueSet = aio.DefaultValue;
//          }
//        }
//      }
    }

    public void RestoreUserOrFpmDefaults(DatabaseService ao)
    {
      _currentInputsFile = string.Empty;

      if (File.Exists(_defaultInputsFile))
      {
        LoadDefaultInputsFile(ao);
      }
      else
      {
        LoadFpmDefaults(ao);
      }
    }

    public void SaveUserDefaults(DatabaseService ao)
    {
      SaveInputsFileWorker(_defaultInputsFile, ao);
    }

    public void SaveInputsFile(string filename, DatabaseService ao)
    {
      SaveInputsFileWorker(filename, ao);
      _currentInputsFile = filename;
    }

    private void SaveInputsFileWorker(string filename, DatabaseService data)
    {
      //var x = new XmlSerializer(typeof(DatabaseService));
      //var fs = new FileStream(filename, FileMode.OpenOrCreate);
      //x.Serialize(fs, ao);
      //fs.Close();

      if (!Directory.Exists(Paths.SavedFilesDirectory))
        Directory.CreateDirectory(Paths.SavedFilesDirectory);
//      #if __IOS__
//      if (!Directory.Exists(iosUtilities.iOSPaths.DocumentsDirectory.Path))
//        Directory.CreateDirectory(iosUtilities.iOSPaths.DocumentsDirectory.Path);
//      #endif
//
//      if (File.Exists(filename))
//      {
//        File.Delete(filename);
//      }
//
      XmlWriterSettings setting = new XmlWriterSettings();
      setting.Indent = true;

      using (XmlWriter input = XmlWriter.Create(filename, setting))
      {
        input.WriteStartDocument();
        input.WriteStartElement("Root");
        //Create a section for file info- date, time, version#
        input.WriteStartElement("FileInfo");
        input.WriteAttributeString("ProgramName", "Debt Calculator");
        input.WriteAttributeString("ProgramVersion", "0.0.0.3");
        input.WriteAttributeString("PathFileName", filename);
        input.WriteAttributeString("Date", DateTime.Now.ToString("MM.dd.yyyy"));
        input.WriteAttributeString("Time", DateTime.Now.ToString("HH:mm"));
        input.WriteAttributeString("VersionMajor", FileVersionMajor);
        input.WriteAttributeString("VersionMinor", FileVersionMinor);
        input.WriteEndElement(); // FileInfo


        input.WriteStartElement("Debts");

        //Iterate through Inputs to save their current values
        foreach (DebtEntry entry in data.GetDebtManager().Debts)
        {
          input.WriteStartElement("DebtEntry");
          input.WriteAttributeString("Name", entry.Name);
          input.WriteAttributeString("StartingBalance", entry.StartingBalance.ToString());
          input.WriteAttributeString("CurrentBalance", entry.CurrentBalance.ToString());
          input.WriteAttributeString("YearlyInterestRate", entry.YearlyInterestRate.ToString());
          input.WriteAttributeString("LoanTerm", entry.LoanTerm.ToString());
          input.WriteEndElement(); // DebtEntry
        }

        input.WriteEndElement(); // Debts

        input.WriteStartElement("Payments");

        foreach (SalaryEntry entry in data.GetPaymentManager().SalaryEntries)
        {
          input.WriteStartElement("SalaryEntry");
          input.WriteAttributeString("StartingSalary", entry.StartingSalary.ToString());
          input.WriteAttributeString("YearlyIncreaseAppliedDate", entry.YearlyIncreaseAppliedDate.ToString());
          input.WriteAttributeString("YearlySnowballIncreasePercent", entry.YearlySnowballIncreasePercent.ToString());
          input.WriteEndElement(); // SalaryEntry
        }

        foreach (WindfallEntry entry in data.GetPaymentManager().WindfallEntries)
        {
          input.WriteStartElement("WindfallEntry");
          input.WriteAttributeString("WindfallAmount", entry.Amount.ToString());
          input.WriteAttributeString("IsRecurring", entry.IsRecurring.ToString());
          input.WriteAttributeString("RecurringFrequency", entry.RecurringFrequency.ToString());
          input.WriteAttributeString("WindfallDate", entry.WindfallDate.ToString());
          input.WriteEndElement(); // WindfallEntry
        }

        input.WriteStartElement("Snowball");
        input.WriteAttributeString("SnowballAmount", data.GetPaymentManager().SnowballAmount.ToString());
        input.WriteEndElement(); // Snowball

        input.WriteEndElement(); // Payments
        input.WriteEndElement(); // Root
        input.WriteEndDocument();
        input.Flush();
        input.Close();
      }
    }


    #endregion


  }
}

