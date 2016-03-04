using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;

namespace DebtCalculator.Shared
{
  [ImplementPropertyChanged]
  public class DebtListPageModel : BaseViewModel
  {
    public DebtListPageModel ()
    {
    }

    public ObservableCollection<DebtEntry> Debts { get; set; } = DebtApp.Shared.DebtManager.Debts;

//    DebtEntry _selectedDebt;

//    public DebtEntry SelectedDebt 
//    {
//      get 
//      {
//        return _selectedDebt;
//      }
//      set 
//      {
//        _selectedDebt = value;
//        if (value != null)
//        {
//          DebtSelected.Execute(value);
//        }
//      }
//    }

//    public Command AddDebt 
//    {
//      get 
//      {
//        return new Command (async () => 
//          {
//            await CoreMethods.PushPageModel<DebtPageModel> ();
//          });
//      }
//    }
//
//    public Command<DebtEntry> DebtSelected 
//    {
//      get 
//      {
//        return new Command<DebtEntry> ( (debt) => 
//          {
//            CoreMethods.PushPageModel<DebtPageModel> (debt);
//          });
//      }
//    }
  }
}

