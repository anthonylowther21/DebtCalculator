using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;

namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class DebtListPageModel : FreshBasePageModel
  {

    public DebtListPageModel ()
    {
    }

    public ObservableCollection<DebtEntry> Debts { get; set; }

    public override void Init (object initData)
    {
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      Debts = DebtApp.Shared.DebtManager.Debts;
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      SelectedDebt = null;
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
      Debts = DebtApp.Shared.DebtManager.Debts;
    }

    DebtEntry _selectedDebt;

    public DebtEntry SelectedDebt 
    {
      get 
      {
        return _selectedDebt;
      }
      set 
      {
        _selectedDebt = value;
        if (value != null)
        {
          DebtSelected.Execute(value);
        }
      }
    }

    public Command AddDebt 
    {
      get 
      {
        return new Command (async () => 
          {
            await CoreMethods.PushPageModel<DebtPageModel> ();
          });
      }
    }

    public Command<DebtEntry> DebtSelected 
    {
      get 
      {
        return new Command<DebtEntry> ( (debt) => 
          {
            CoreMethods.PushPageModel<DebtPageModel> (debt);
          });
      }
    }
  }
}

