using System;
using Xamarin.Forms;
using DebtCalculator;
using Xamarin.Forms.Platform.iOS;
using System.Linq;
using UIKit;
using CoreGraphics;
using DebtCalculator.Shared;

[assembly:ExportRenderer (typeof(CustomTabbedPage), typeof(DebtCalculator.iOS.CustomTabbedPageRenderer))]
namespace DebtCalculator.iOS
{
  public class CustomTabbedPageRenderer : TabbedRenderer
  {
    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);

      var pages = this.ViewController.ChildViewControllers
        .OfType<IVisualElementRenderer>()
        .Select(e => e.Element as ITabPage)
        .ToArray();

      if (pages.Length != this.TabBar.Items.Length)
      {
        throw new Exception("Uh oh! Inconsistent number of pages and tabbar items!");
      }

      UIColor normalColor = UIColorHelper.GetUIColor (Colors.TabBarNormal);     
      UIColor selectedColor = UIColorHelper.GetUIColor (Colors.TabBarSelected);

      for (var i = 0; i < pages.Length; i++)
      {
        var tabItem = this.TabBar.Items[i];
        if (tabItem.Image == null)
        {
          tabItem.Image = ImageHelper.ImageFromFont(
            pages[i].TabIcon, normalColor, new CGSize(30, 30), FontAwesome.FontName);
          
          tabItem.SelectedImage = ImageHelper.ImageFromFont(
            pages[i].SelectedTabIcon, selectedColor, new CGSize(30, 30), FontAwesome.FontName);
        }

        tabItem.SetTitleTextAttributes (new UITextAttributes () 
          {
            TextColor = normalColor
          }, UIControlState.Normal);

        tabItem.SetTitleTextAttributes (new UITextAttributes () 
          {
            TextColor = selectedColor
          }, UIControlState.Selected);
      }
    }
  }
}

