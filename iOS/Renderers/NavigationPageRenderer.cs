using System;
using Xamarin.Forms;
using DebtCalculator.Shared;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using System.Collections.Generic;

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
      // If we can't get the xamarin forms implementation, then we don't know which
      // toolbar items we are adding.
      var navPage = this.Element as CustomNavigationPage;
      if (navPage == null)
        return;

      UINavigationItem navigationItem = null;

      foreach (UIView view in this.NativeView.Subviews) 
      {
        UINavigationBar bar = view as UINavigationBar;
        if (bar != null) {
          navigationItem = bar.Items [0];
        }
      }

      // If we don't have a context, we can't proceed
      if (navigationItem == null)
        return;

      // This means we have already added the items
      if (navigationItem.LeftBarButtonItems != null && navigationItem.LeftBarButtonItems.Length > 0)
        return;

      var leftNavList = new List<UIBarButtonItem> ();
      var rightNavList = new List<UIBarButtonItem> ();
      Page currentPage = navPage.CurrentPage;

      for (var i = 0; i < currentPage.ToolbarItems.Count; i++) 
      {

        var reorder = (currentPage.ToolbarItems.Count - 1);
        var ItemPriority = currentPage.ToolbarItems [reorder - i].Priority;

        if (ItemPriority == 1) 
        {
          UIBarButtonItem LeftNavItems = navigationItem.RightBarButtonItems [i];
          leftNavList.Add (LeftNavItems);
        } 
        else if (ItemPriority == 0) 
        {
          UIBarButtonItem RightNavItems = navigationItem.RightBarButtonItems [i];
          rightNavList.Add (RightNavItems);
        }
      }


      navigationItem.SetLeftBarButtonItems (leftNavList.ToArray (), false);
      navigationItem.SetRightBarButtonItems (rightNavList.ToArray (), false);

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

