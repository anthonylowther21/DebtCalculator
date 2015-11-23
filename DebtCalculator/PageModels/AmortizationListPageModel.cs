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
  public class AmortizationListPageModel : FreshBasePageModel
  {
    IDatabaseService _databaseService;
    DebtSnowballCalculator _calculator;

    public AmortizationListPageModel (IDatabaseService databaseService)
    {
      _databaseService = databaseService;
      _calculator = new DebtSnowballCalculator();
    }

    public ObservableCollection<PaymentPlanOutputEntry> Amortizations { get; set; }

    public override void Init (object initData)
    {
      // Binding
//      Amortizations = 
//        _calculator.CalculateDebtSnowball(_databaseService.GetDebtManager(), _databaseService.GetPaymentManager());
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      Amortizations = 
        _calculator.CalculateDebtSnowball(_databaseService.GetDebtManager(), _databaseService.GetPaymentManager());
      //You can do stuff here
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      SelectedAmortization = null;
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
//      Amortizations = 
//        _calculator.CalculateDebtSnowball(_databaseService.GetDebtManager(), _databaseService.GetPaymentManager());
    }

    PaymentPlanOutputEntry _selectedAmortization;

    public PaymentPlanOutputEntry SelectedAmortization 
    {
      get 
      {
        return _selectedAmortization;
      }
      set 
      {
        _selectedAmortization = value;
        if (value != null)
        {
          //DebtSelected.Execute(value);
        }
      }
    }

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

