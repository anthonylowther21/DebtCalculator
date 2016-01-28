using System;
using DebtCalculator.Library;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using System.Collections.Generic;

namespace DebtCalculator.PageModels
{
  [ImplementPropertyChanged]
  public class SummaryPageModel : FreshBasePageModel
  {
    IDatabaseService _databaseService;

    private double _originalInterest = 0;
    private double _snowballInterest = 0;
    private double _savedInterest = 0;

    private DateTime _originalPayoffDate = DateTime.Now;
    private DateTime _snowballPayoffDate = DateTime.Now;

    ObservableCollection<AmortizationEntry> amortization;

    public SummaryPageModel (IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public override void Init (object initData)
    {

    }

    protected override void ViewIsAppearing (object sender, EventArgs e)
    {
      if (_databaseService.GetDebtManager().Debts.Count > 0)
      {
        double interest = 0;
        amortization = _databaseService.Calculate(false);
        bool invalid = false;
        foreach (var entry in amortization)
        {
          if (entry.EndBalance == -9999)
          {
            invalid = true;
            break;
          }
          interest += entry.MinimumInterest;
        }

        if (invalid)
        {
          _originalInterest = double.MaxValue;
          _originalPayoffDate = DateTime.MaxValue;
        }
        else
        {
          _originalInterest = interest;
          _originalPayoffDate = amortization[amortization.Count - 1].Date;
        }



        interest = 0;
        amortization = _databaseService.Calculate(true);
        foreach (var entry in amortization)
        {
          interest += entry.MinimumInterest;
        }
        _snowballInterest = interest;
        _snowballPayoffDate = amortization[amortization.Count - 1].Date;

        _savedInterest = _originalInterest - _snowballInterest;
        RaisePropertyChanged("");
        //You can do stuff here
      }
    }

    public string OriginalInterest 
    {
      get 
      { 
        return string.Format("{0:C}", _originalInterest); 
      }
    }

    public string SnowballInterest 
    {
      get 
      { 
        return string.Format("{0:C}", _snowballInterest); 
      }
    }

    public string SavedInterest 
    {
      get 
      { 
        return string.Format("{0:C}", _savedInterest); 
      }
    }

    public string OriginalPayoffDate
    {
      get
      {
        return string.Format("{0:MMMM yyyy}", _originalPayoffDate);
      }
    }

    public string SnowballPayoffDate
    {
      get
      {
        return string.Format("{0:MMMM yyyy}", _snowballPayoffDate);
      }
    }

    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
      base.ViewIsDisappearing(sender, e);
    }

    public override void ReverseInit (object value)
    {
    }
  }
}

