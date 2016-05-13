using System;
using Xamarin.Forms;

namespace DebtCalculator.Shared
{
  public class CustomNavigationPage : NavigationPage, ITabPage
  {
    string _barItemFontFamily = FontAwesome.FontName;
    int _barItemFontSize = 18;

    public CustomNavigationPage(Page page) : base(page)
    {
      NavigationBarBackground = Colors.TabBarSelected;
      BackgroundColor = Color.Blue;
    }

    #region ITabPage implementation

    public string TabIcon { get; set; }
    public string SelectedTabIcon { get; set; }
    public Color NavigationBarBackground { get; set; }

    #endregion
      
    public string BarItemFontFamily 
    {
      get { return _barItemFontFamily; }
      set
      {
        _barItemFontFamily = value;
      }
    }

    public int BarItemFontSize 
    {
      get { return _barItemFontSize; }
      set
      {
        _barItemFontSize = value;
      }
    }

    public string BarTitleFontFamily 
    {
      get { return _barItemFontFamily; }
      set
      {
        _barItemFontFamily = value;
      }
    }

    public int BarTitleFontSize 
    {
      get { return _barItemFontSize; }
      set
      {
        _barItemFontSize = value;
      }
    }
  }
}

