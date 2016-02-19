using System;
using System.Collections.Generic;
using DebtCalculator.PageModels;
using Xamarin.Forms;
using System.IO;
using DebtCalculatorLibrary.Utility;

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
      File.Delete(Path.Combine(Paths.SavedFilesDirectory, mi.CommandParameter.ToString()));
      (this.BindingContext as HomePageModel).Files.Remove(mi.CommandParameter.ToString());
    }
	}
}

