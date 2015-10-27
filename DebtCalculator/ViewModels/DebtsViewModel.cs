using System;
using GalaSoft.MvvmLight;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace DebtCalculator.ViewModels
{
  public class DebtsViewModel : ViewModelBase
  {
    DebtManager _debtManager = null;
    INavigation _navigation = null;

    public DebtsViewModel(INavigation navigation, DebtManager debtManager)
    {
      _navigation = navigation;
      _debtManager = debtManager;

      CreateDebtCommand = new RelayCommand(() => CreateDebt(), () => true);
    }

    public ObservableCollection<DebtEntry> Debts
    {
      get { return _debtManager.DebtEntries; }
    }

    public ICommand CreateDebtCommand { get; private set; }

    private void CreateDebt()
    {
      
    }
  }
}

