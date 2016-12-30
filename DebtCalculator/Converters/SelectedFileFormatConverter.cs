using Xamarin.Forms;
using System;
using DebtCalculator.Library;
using DebtCalculatorLibrary.Business;
using System.IO;

namespace DebtCalculator.Shared
{ 
  class SelectedFileFormatConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      return (value.ToString() == Path.GetFileName(InputsFileManager.CurrentInputsFile)) ? FontAttributes.Bold : FontAttributes.None;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
      System.Globalization.CultureInfo culture)
    {
      throw new NotSupportedException ();
    }
  }
}