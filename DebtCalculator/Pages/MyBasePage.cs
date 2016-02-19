using System;
using Xamarin.Forms;
using DebtCalculator.Navigation;
using FreshMvvm;
using DebtCalculator.PageModels;

namespace DebtCalculator.Pages
{
  public class MyBasePage : ContentPage
  {
    public MyBasePage ()
    {
      ToolbarItems.Add (new ToolbarItem ("Files", null, () => 
        {
          Navigation.PushAsync(FreshPageModelResolver.ResolvePageModel<LeftSlideoutPageModel>());
        }));
    }
  }
}

