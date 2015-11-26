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

    public AmortizationListPageModel (IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public ObservableCollection<PaymentPlanOutputEntry> Amortizations { get; set; }

    public override void Init (object initData)
    {
    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      Amortizations = _databaseService.Calculate(true);
      //You can do stuff here
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      SelectedAmortization = null;
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
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
          AmortizationSelected.Execute(value);
        }
      }
    }

    public Command<PaymentPlanOutputEntry> AmortizationSelected 
    {
      get 
      {
        return new Command<PaymentPlanOutputEntry> ( (amortization) => 
          {
            CoreMethods.PushPageModel<AmortizationPageModel> (amortization);
          });
      }
    }
  }
}

