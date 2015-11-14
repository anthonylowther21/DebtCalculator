using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;

namespace DebtCalculator.PageModels
{
  public class DebtListPageModel : FreshBasePageModel
  {
    IDatabaseService _databaseService;

    public DebtListPageModel (IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public ObservableCollection<DebtEntry> Debts { get; set; }

    public override void Init (object initData)
    {
      Debts = new ObservableCollection<DebtEntry> (_databaseService.GetDebtManager().Debts);
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      //You can do stuff here
    }

    public override void ReverseInit (object value)
    {
      var newDebt = value as DebtEntry;
      if (!Debts.Contains (newDebt)) {
        Debts.Add (newDebt);
      }
    }

    DebtEntry _selectedDebt;

    public DebtEntry SelectedDebt {
      get {
        return _selectedDebt;
      }
      set {
        _selectedDebt = value;
        if (value != null)
          DebtSelected.Execute (value);
      }
    }

    public Command AddDebt {
      get {
        return new Command (async () => {
          await CoreMethods.PushPageModel<DebtPageModel> ();
        });
      }
    }

    public Command<DebtEntry> DebtSelected {
      get {
        return new Command<DebtEntry> (async (debt) => {
          await CoreMethods.PushPageModel<DebtPageModel> (debt);
        });
      }
    }
  }
}

