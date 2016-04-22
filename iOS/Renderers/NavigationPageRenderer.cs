using System;
using Xamarin.Forms;
using DebtCalculator.Shared;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof (NavigationPage), typeof (DebtCalculator.iOS.NavigationPageRenderer))]

namespace DebtCalculator.iOS
{
  public class NavigationPageRenderer : NavigationRenderer
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
    }

    private void SetNavBarItems()
    {
      var navPage = this.Element as CustomNavigationPage;

      if (navPage == null) return;

      var textAttributes = new UITextAttributes()
        {
          Font = UIFont.FromName(navPage.BarItemFontFamily, navPage.BarItemFontSize)
        };

      var textAttributesHighlighted = new UITextAttributes()
        {
          TextColor = Color.Black.ToUIColor(),
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

      this.NavigationBar.TitleTextAttributes = new UIStringAttributes
        {
          Font = UIFont.FromName(navPage.BarTitleFontFamily, navPage.BarTitleFontSize),
        };
    }
  }
}

