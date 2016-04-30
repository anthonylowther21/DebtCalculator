﻿using Xamarin.Forms;
using System;
using DebtCalculator.Library;

namespace DebtCalculator.Shared
{ 
  class DebtTypeToIconConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      string result = String.Empty;
      DebtType debtType;
      if (Enum.TryParse<DebtType> (value.ToString (), out debtType)) 
      {
        if (debtType == DebtType.CreditCard) 
        {
          return FontAwesome.FACard;
        } 
        else if (debtType == DebtType.HouseLoan) 
        {
          return FontAwesome.FAHouse;
        } 
        else if (debtType == DebtType.CarLoan) 
        {
          return FontAwesome.FACar;
        } 
        else if (debtType == DebtType.StudentLoan) 
        {
          return FontAwesome.FACap;
        }
        else if (debtType == DebtType.OtherLoan) 
        {
          return FontAwesome.FABank;
        } 
      }

      return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      throw new NotSupportedException ();
    }
  }
}