using System;
using System.Collections.Generic;
using DebtCalculator.PageModels;
using Xamarin.Forms;
using System.IO;
using DebtCalculatorLibrary.Utility;
using DebtCalculatorLibrary.Business;

namespace DebtCalculator.Pages
{
  public partial class HomePage : MyBasePage
	{
    public HomePage ()
		{
			InitializeComponent ();
		}

    public void OnDelete (object sender, EventArgs e) 
    {
      var mi = ((MenuItem)sender);
      string filename = Path.Combine(Paths.SavedFilesDirectory, mi.CommandParameter.ToString());
      if (InputsFileManager.CurrentInputsFile != filename)
      {
        File.Delete(filename);
        (this.BindingContext as HomePageModel).Files.Remove(mi.CommandParameter.ToString());
      }
    }
	}
}

