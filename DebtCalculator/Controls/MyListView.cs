using System;
using Xamarin.Forms;
namespace DebtCalculator.Shared
{
  public class MyListView : ListView
  {
    public MyListView ()
    {
      this.PropertyChanged += Handle_PropertyChanged;
    }

    void Handle_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "IsVisible") 
      {
        if (this.IsVisible == true) 
        {
          this.FadeTo (1f, 50);
        } 
        else 
        {
          this.FadeTo (0f, 50);
        }
      }
    }
  }
}

