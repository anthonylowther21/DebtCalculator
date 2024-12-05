using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using System.Collections.Generic;
using DebtCalculatorLibrary.Services;

namespace DebtCalculator.Shared
{
  public class ScenarioItemViewModel : BaseViewModel
  {
    public ScenarioItemViewModel ()
    {
    }

    public string Name { get ; set; }
    public string ModifiedDate { get; set; }
  }
}

