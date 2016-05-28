using Xamarin.Forms;
using System;
using System.Globalization;

namespace DebtCalculator.Shared
{ 
  static class ShortStringHelper
  {
    static int MAX_LENGTH = 16;

    static public string Convert(string value)
    {
      if (value.Length > MAX_LENGTH) 
      {
        return value.Substring (0, MAX_LENGTH);
      } 
      else 
      {
        return value;
      }
    }

    static public string ConvertBack(string value)
    {
      if (value.Length > MAX_LENGTH) 
      {
        return value.Substring (0, MAX_LENGTH);
      } 
      else 
      {
        return value;
      }
    }
  }
}