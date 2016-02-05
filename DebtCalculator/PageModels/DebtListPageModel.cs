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
    IDatabaseService _databaseService;

    public DebtListPageModel (IDatabaseService databaseService)
    {
      _databaseService = databaseService;
      _databaseService.NeedsRefreshChanged += (sender, e) => Init(null);
    }

    public ObservableCollection<DebtEntry> Debts { get; set; }

    public override void Init (object initData)
    {
      // Binding
      Debts = new ObservableCollection<DebtEntry> (_databaseService.GetDebtManager().Debts);
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      //You can do stuff here
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      SelectedDebt = null;
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
      Debts = new ObservableCollection<DebtEntry>(_databaseService.GetDebtManager().Debts);
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

