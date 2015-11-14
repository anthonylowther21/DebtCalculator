using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;


namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class DebtPageModel : FreshBasePageModel
  {
    IDatabaseService _dataService;

    public DebtPageModel (IDatabaseService dataService)
    {
      _dataService = dataService;
    }

    public DebtEntry Debt { get; set; }

    public override void Init (object initData)
    {
      if (initData != null) {
        Debt = (DebtEntry)initData;
      } else {
        Debt = new DebtEntry ();
      }
    }

    public Command SaveCommand {
      get { 
        return new Command (() => {
          _dataService.GetDebtManager().UpdateDebt(Debt);
          CoreMethods.PopPageModel (Debt);
        }
        );
      }
    }

    public Command TestModal {
      get {
        return new Command (async () => {
          await CoreMethods.PushPageModel<ModalPageModel> (null, true);
        });
      }
    }
  }
}

