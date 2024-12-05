using System;
using UIKit;

namespace DebtCalculator.iOS
{
  public class UIColorHelper
  {
    static public UIColor GetUIColor(Xamarin.Forms.Color xfColor)
    {
      UIColor uiColor = UIColor.FromRGBA (
        (int)(xfColor.R * 255), 
        (int)(xfColor.G * 255), 
        (int)(xfColor.B * 255), 
        (int)(xfColor.A * 255));
      return uiColor;
    }
  }
}

