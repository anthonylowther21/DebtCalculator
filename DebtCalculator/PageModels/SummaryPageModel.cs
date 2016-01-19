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
          OriginalInterest = double.MaxValue;
          OriginalPayoffDate = DateTime.MaxValue;
        }
        else
        {
          OriginalInterest = interest;
          OriginalPayoffDate = amortization[amortization.Count - 1].Date;
        }



        interest = 0;
        amortization = _databaseService.Calculate(true);
        foreach (var entry in amortization)
        {
          interest += entry.MinimumInterest;
        }
        SnowballInterest = interest;
        SnowballPayoffDate = amortization[amortization.Count - 1].Date;

        SavedInterest = _originalInterest - _snowballInterest;
        //You can do stuff here
      }
    }

    public double OriginalInterest 
    {
      get { return _originalInterest; }
      set { _originalInterest = value; }
    }

    public double SnowballInterest 
    {
      get { return _snowballInterest; }
      set { _snowballInterest = value; }
    }

    public double SavedInterest 
    {
      get { return _savedInterest; }
      set { _savedInterest = value; }
    }

    public DateTime OriginalPayoffDate
    {
      get
      {
        return _originalPayoffDate;
      }
      set
      {
        _originalPayoffDate = value;
      }
    }

    public DateTime SnowballPayoffDate
    {
      get
      {
        return _snowballPayoffDate;
      }
      set
      {
        _snowballPayoffDate = value;
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

