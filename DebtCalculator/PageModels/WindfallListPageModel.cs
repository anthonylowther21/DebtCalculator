using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;

namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class WindfallListPageModel : FreshBasePageModel
  {
    IDatabaseService _databaseService;

    public WindfallListPageModel (IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public ObservableCollection<WindfallEntry> Windfalls { get; set; }

    public override void Init (object initData)
    {
      // Binding
      Windfalls = new ObservableCollection<WindfallEntry> (_databaseService.GetPaymentManager().WindfallEntries);
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      //You can do stuff here
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      SelectedWindfall = null;
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
      Windfalls = new ObservableCollection<WindfallEntry> (_databaseService.GetPaymentManager().WindfallEntries);
    }

    WindfallEntry _selectedWindfall;

    public WindfallEntry SelectedWindfall 
    {
      get 
      {
        return _selectedWindfall;
      }
      set 
      {
        _selectedWindfall = value;
        if (value != null)
        {
          WindfallSelected.Execute(value);
        }
      }
    }

    public Command AddWindfall 
    {
      get 
      {
        return new Command (async () => 
          {
            await CoreMethods.PushPageModel<WindfallPageModel> ();
          });
      }
    }

    public Command<WindfallEntry> WindfallSelected 
    {
      get 
      {
        return new Command<WindfallEntry> ( (windfall) => 
          {
            CoreMethods.PushPageModel<WindfallPageModel> (windfall);
          });
      }
    }
  }
}

