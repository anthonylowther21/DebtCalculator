using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace DebtCalculator.Shared
{
  public class NumericEntryCell : EntryCell
  {
    public new event EventHandler Completed;



    public NumericEntryCell()
    {
      //this.Effects.Add (Effect.Resolve ("MyCompany.FocusEffect"));
    }

    public static readonly BindableProperty EditingBackgroundColorProperty=
      BindableProperty.Create<NumericEntryCell, Color>( p => p.EditingBackgroundColor, Color.Default );

    public Color EditingBackgroundColor
    {
      get 
      { 
        return (Color)GetValue(EditingBackgroundColorProperty); 
      }
      set 
      {
        SetValue(EditingBackgroundColorProperty, value); 
      }
    }

    public void OnCompleted()
    {
      var handler = Completed as EventHandler;
      if (handler != null) 
      {
        Completed (this, new EventArgs ());
      }
    }
  }
}

