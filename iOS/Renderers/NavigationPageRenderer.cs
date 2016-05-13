using System;
using Xamarin.Forms;
using DebtCalculator.Shared;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof (CustomNavigationPage), typeof (DebtCalculator.iOS.CustomNavigationPageRenderer))]

namespace DebtCalculator.iOS
{
  public class CustomNavigationPageRenderer : NavigationRenderer
  {
    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);

      if (this.NavigationBar == null) return;

      SetNavBarStyle();
      SetNavBarTitle();
      SetNavBarItems();
    }

    private void SetNavBarStyle()
    {
      NavigationBar.ShadowImage = new UIImage();
      NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
      UINavigationBar.Appearance.ShadowImage = new UIImage();
      UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
      UINavigationBar.Appearance.BarTintColor = UIColorHelper.GetUIColor((Element as CustomNavigationPage).NavigationBarBackground);
    }

    private void SetNavBarItems()
    {
      var navPage = this.Element as CustomNavigationPage;

      if (navPage == null) return;

      var textAttributes = new UITextAttributes()
        {
          TextColor = Colors.TabBarNormal.ToUIColor(),
          Font = UIFont.FromName(navPage.BarItemFontFamily, navPage.BarItemFontSize)
        };

      var textAttributesHighlighted = new UITextAttributes()
        {
          TextColor = Colors.TabBarSelected.ToUIColor(),
          Font = UIFont.FromName(navPage.BarItemFontFamily, navPage.BarItemFontSize)
        };

      UIBarButtonItem.Appearance.SetTitleTextAttributes(textAttributes,
        UIControlState.Normal);
      UIBarButtonItem.Appearance.SetTitleTextAttributes(textAttributesHighlighted,
        UIControlState.Highlighted);
    }

    private void SetNavBarTitle()
    {
      var navPage = this.Element as CustomNavigationPage;

      if (navPage == null) return;
      UINavigationBar.Appearance.SetTitleTextAttributes( new UITextAttributes()
        {
          TextColor = Colors.TabBarNormal.ToUIColor(),
          Font = UIFont.BoldSystemFontOfSize(navPage.BarItemFontSize + 2)
        });
    }
  }
}

