using System;
using UIKit;
using CoreGraphics;
using DebtCalculator.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace DebtCalculator.iOS
{
  public class KeyboardInputAccessoryHelper
  {
    static public UIToolbar CreateAccessoryToolbar(Action doneHandler)
    {
      nfloat width = UIScreen.MainScreen.Bounds.Width;
      UIToolbar uIToolbar = new UIToolbar (new CGRect (0, 0, width, 44)) 
      {
        BarTintColor = Colors.TabBarBackground.ToUIColor(),
        Translucent = false
      };

      UIBarButtonItem uIBarButtonSpace = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);
      UIBarButtonItem uIBarButtonDone = new UIBarButtonItem (UIBarButtonSystemItem.Done, (sender, e) => doneHandler());
      uIToolbar.SetItems (new UIBarButtonItem[] 
        {
          uIBarButtonSpace,
          uIBarButtonDone
        }, false);

      return uIToolbar;
    }
  }
}

