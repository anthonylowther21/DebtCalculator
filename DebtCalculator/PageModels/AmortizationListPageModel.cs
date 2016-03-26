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
  public class AmortizationListPageModel : BaseViewModel
  {
    public AmortizationListPageModel ()
    {
    }

    public ObservableCollection<AmortizationEntry> Amortizations { get; set; }
  }
}

