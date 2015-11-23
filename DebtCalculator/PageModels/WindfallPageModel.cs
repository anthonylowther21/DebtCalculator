using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class WindfallPageModel : FreshBasePageModel
  {
    IDatabaseService _dataService;

    public WindfallPageModel (IDatabaseService dataService)
    {
      _dataService = dataService;
    }

    public WindfallEntry Windfall { get; set; }

    public override void Init (object initData)
    {
      if (initData != null) 
      {
        Windfall = ((WindfallEntry)initData).Clone();
      } 
      else 
      {
        Windfall = new WindfallEntry ();
      }
    }

    public Command SaveCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            _dataService.GetPaymentManager().UpdateWindfall(Windfall);
            CoreMethods.PopPageModel (Windfall);
          }
        );
      }
    }

    public Command DeleteCommand 
    {
      get 
      { 
        return new Command (() => 
          {
            _dataService.GetPaymentManager().DeleteWindfall(Windfall);
            CoreMethods.PopPageModel (Windfall);
          }
        );
      }
    }
  }
}

