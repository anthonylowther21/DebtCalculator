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
    private string _previousInputsFile;
    private string _currentInputsFile;

    private const string FileVersionMajor = "1";
    private const string FileVersionMinor = "0";

    public event EventHandler FileListChanged;
    static public InputsFileDatabase Shared;

    static InputsFileDatabase()
    {
      Shared = new InputsFileDatabase();
    }

    public string CurrentInputsFile
    {
      get { return _currentInputsFile; }
    }

    public string UserDefaultInputsFile
    {
      get { return _previousInputsFile; }
    }
      
    public InputsFileDatabase()
    {
      _previousInputsFile = DebtCalculatorLibrary.Utility.Paths.DefaultInputsPath;
      _currentInputsFile = string.Empty;
    }

    /// <summary>
    /// default destructor
    /// </summary>
    ~InputsFileDatabase()
    {
      _previousInputsFile = null;
      _currentInputsFile = null;
    }

    public void LoadOnAppLaunch(DebtApp data)
    {
      if (File.Exists(_previousInputsFile))
      {
        LoadInputsFile(_previousInputsFile, data);
      }
    }

    /// <summary>
    /// Function to load inputs for the aircraft from a save file.
    /// </summary>
    /// <param name="bFromInit">If we are getting inputs from application open</param>
    /// <param name="bUpdateAIUserDefault"></param>
    public bool LoadInputsFile(string openFilePath, DebtApp debtApp)
    {
      debtApp.DebtManager.Debts.Clear();
      debtApp.PaymentManager.WindfallEntries.Clear();
      debtApp.PaymentManager.SalaryEntries.Clear();
      debtApp.PaymentManager.SnowballAmount = 0;

      _currentInputsFile = openFilePath;

      foreach (var item in File.ReadAllLines(openFilePath))
      {
        Console.WriteLine(item);
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
                case "FileInfo":
                DateTime temp = DateTime.Now;
                DateTime.TryParse(readInputs["Date"], out temp);
                debtApp.ModifiedDate = temp;
                  break;
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
                    debtApp.DebtManager.Debts.Add(
                      new DebtEntry(
                        (string)readInputs["Name"],
                        Double.Parse(readInputs["StartingBalance"]),
                        Double.Parse(readInputs["CurrentBalance"]),
                        Double.Parse(readInputs["YearlyInterestRate"]),
                        Int32.Parse(readInputs["LoanTerm"]),
                        (DebtType)Enum.Parse(typeof(DebtType), readInputs["DebtType"])));
                      break;
                  }
                case "SalaryEntry":
                  {
                    Console.WriteLine("Start <SalaryEntry> element.");
                    debtApp.PaymentManager.SalaryEntries.Add(
                      new SalaryEntry(
                        (string)readInputs["Name"],
                        Double.Parse(readInputs["StartingSalary"]),
                        Double.Parse(readInputs["YearlySnowballIncreasePercent"]),
                        DateTime.Parse(readInputs["YearlyIncreaseAppliedDate"])));

                    break;
                  }
                case "WindfallEntry":
                  {
                    Console.WriteLine("Start <SalaryEntry> element.");
                    debtApp.PaymentManager.WindfallEntries.Add(
                      new WindfallEntry(
                        (string)readInputs["Name"],
                        Double.Parse(readInputs["WindfallAmount"]),
                        DateTime.Parse(readInputs["WindfallDate"]),
                        Boolean.Parse(readInputs["IsRecurring"]),
                        Int32.Parse(readInputs["RecurringFrequency"])));
                    break;
                  }
                case "Snowball":
                  {
                    Console.WriteLine("Start <Snowball> element.");
                    debtApp.PaymentManager.SnowballAmount = Double.Parse(readInputs["SnowballAmount"]);
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
        return false;
      }
      return true;

    }

    public void SaveUserDefaults(DebtApp data)
    {
      SaveInputsFileWorker(_previousInputsFile, data);
    }

    public void SaveInputsFile(string filename, DebtApp data)
    {
      SaveInputsFileWorker(filename, data);
      _currentInputsFile = filename;
    }

    public void OnFileListChanged()
    {
      var handler = FileListChanged;
      if (handler != null)
      {
        handler(this, new EventArgs());
      }
    }

    private void SaveInputsFileWorker(string filename, DebtApp data)
    {
      if (!Directory.Exists(Paths.SavedFilesDirectory))
        Directory.CreateDirectory(Paths.SavedFilesDirectory);

      bool fileAdded = false;

      if (File.Exists(filename) == false)
      {
        fileAdded = true;
      }

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
        foreach (DebtEntry entry in data.DebtManager.Debts)
        {
          input.WriteStartElement("DebtEntry");
          input.WriteAttributeString("Name", entry.Name);
          input.WriteAttributeString("StartingBalance", entry.StartingBalance.ToString());
          input.WriteAttributeString("CurrentBalance", entry.CurrentBalance.ToString());
          input.WriteAttributeString("YearlyInterestRate", entry.YearlyInterestRate.ToString());
          input.WriteAttributeString("LoanTerm", entry.LoanTerm.ToString());
          input.WriteAttributeString("DebtType", entry.DebtType.ToString());
          input.WriteEndElement(); // DebtEntry
        }

        input.WriteEndElement(); // Debts

        input.WriteStartElement("Payments");

        foreach (SalaryEntry entry in data.PaymentManager.SalaryEntries)
        {
          input.WriteStartElement("SalaryEntry");
          input.WriteAttributeString("Name", entry.Name);
          input.WriteAttributeString("StartingSalary", entry.StartingSalary.ToString());
          input.WriteAttributeString("YearlyIncreaseAppliedDate", entry.YearlyIncreaseAppliedDate.ToString());
          input.WriteAttributeString("YearlySnowballIncreasePercent", entry.YearlySnowballIncreasePercent.ToString());
          input.WriteEndElement(); // SalaryEntry
        }

        foreach (WindfallEntry entry in data.PaymentManager.WindfallEntries)
        {
          input.WriteStartElement("WindfallEntry");
          input.WriteAttributeString("Name", entry.Name);
          input.WriteAttributeString("WindfallAmount", entry.Amount.ToString());
          input.WriteAttributeString("IsRecurring", entry.IsRecurring.ToString());
          input.WriteAttributeString("RecurringFrequency", entry.RecurringFrequency.ToString());
          input.WriteAttributeString("WindfallDate", entry.WindfallDate.ToString());
          input.WriteEndElement(); // WindfallEntry
        }

        input.WriteStartElement("Snowball");
        input.WriteAttributeString("SnowballAmount", data.PaymentManager.SnowballAmount.ToString());
        input.WriteEndElement(); // Snowball

        input.WriteEndElement(); // Payments
        input.WriteEndElement(); // Root
        input.WriteEndDocument();
        input.Flush();
        input.Close();
      }

      if (fileAdded)
        OnFileListChanged();
    }

    public void Delete(string filename)
    {
      if (filename == _currentInputsFile)
      {
        _currentInputsFile = string.Empty;
      }

      File.Delete(filename);
      OnFileListChanged();
    }

    public Collection<string> GetSavedFiles()
    {
      Collection<string> files = new Collection<string>();
      if (Directory.Exists(Paths.SavedFilesDirectory))
        foreach (string file in Directory.GetFiles(Paths.SavedFilesDirectory))
          files.Add(Path.GetFileName(file));
      return files;
    }
  }
}

