using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using DebtCalculator.PageModels;
using FreshMvvm;
using DebtCalculator.Theme;
using XLabs.Forms.Controls;

namespace DebtCalculator.Navigation
{
  /// <summary>
  /// This is a sample custom implemented Navigation. It combines a MasterDetail and a TabbedPage.
  /// </summary>
  public class FreshNavigationService : Xamarin.Forms.MasterDetailPage, IFreshNavigationService
  {
    NavigationPage _navPage;

    public FreshNavigationService(NavigationPage navPage)
    {
      _navPage = navPage;
    }

    public virtual async Task PushPage (Xamarin.Forms.Page page, FreshBasePageModel model, bool modal = false, bool animated = true)
    {
      if (modal)
        await Navigation.PushModalAsync (new NavigationPage(page), animated);
      else
        await ((NavigationPage)_navPage.CurrentPage).PushAsync (page, animated); 
    }

    public virtual async Task PopPage (bool modal = false, bool animate = true)
    {
      if (modal)
        await Navigation.PopModalAsync ();
      else
        await ((NavigationPage)_navPage.CurrentPage).PopAsync (); 
    }

    public virtual async Task PopToRoot (bool animate = true)
    {
      await ((NavigationPage)_navPage.CurrentPage).PopToRootAsync (animate);
    }
  }
}

