﻿using System;
using DebtCalculator.Library;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using DebtCalculatorLibrary.Services;


namespace DebtCalculator.Shared
{
  [ImplementPropertyChanged]
  public class PaymentListPageModel : BaseViewModel
  {
    public PaymentListPageModel ()
    {
    }

//    public override void Init (object initData)
//    {
//    }

//    public Command ShowSnowball
//    {
//      get
//      {
//        return new Command(async () =>
//          {
//            await CoreMethods.PushPageModel<SnowballPageModel>();
//          });
//      }
//    }
//
//    public Command ShowSalary
//    {
//      get
//      {
//        return new Command(async () =>
//          {
//            await CoreMethods.PushPageModel<SalaryListPageModel>();
//          });
//      }
//    }
//
//    public Command ShowWindfall
//    {
//      get
//      {
//        return new Command(async () =>
//          {
//            await CoreMethods.PushPageModel<WindfallListPageModel>();
//          });
//      }
//    }
  }
}

