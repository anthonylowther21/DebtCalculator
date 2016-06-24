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
  public class DebtListPageModel : BaseViewModel
  {
    private string _emptyMessage = null;

    public DebtListPageModel ()
    {
      DebtApp.Shared.DebtManager.Debts.CollectionChanged += (sender, e) => UpdateEmptyMessage();
      UpdateEmptyMessage ();
    }

    private void UpdateEmptyMessage ()
    {
      if (DebtApp.Shared.DebtManager.Debts.Count > 0)
        EmptyMessage = null;
      else
        EmptyMessage = "Click the add button in the top-right of the screen to get started!";
    }

    public string EmptyMessage 
    {
      get 
      {
        return _emptyMessage;
      }
      set 
      {
        _emptyMessage = value;
        SetPropertyChanged ("EmptyMessage");
      }
    }

    public ObservableCollection<DebtEntry> Debts { get; set; } = DebtApp.Shared.DebtManager.Debts;
  }
}

