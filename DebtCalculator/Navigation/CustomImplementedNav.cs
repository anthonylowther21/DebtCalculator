using System;
using FreshMvvm;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using DebtCalculator.PageModels;

namespace DebtCalculator.Navigation
{
  /// <summary>
  /// This is a sample custom implemented Navigation. It combines a MasterDetail and a TabbedPage.
  /// </summary>
  public class CustomImplementedNav : Xamarin.Forms.MasterDetailPage, IFreshNavigationService
  {
    FreshTabbedNavigationContainer _tabbedNavigationPage;
    Page _debtsPage;

    public CustomImplementedNav ()
    { 
      SetupTabbedPage ();
      CreateMenuPage ("Menu");
      RegisterNavigation ();
    }

    void SetupTabbedPage()
    {
      _tabbedNavigationPage = new FreshTabbedNavigationContainer ();
      //_debtsPage = _tabbedNavigationPage.AddTab<ContactListPageModel> ("Debts", "contacts.png");
      this.Detail = _tabbedNavigationPage;
    }

    protected void RegisterNavigation()
    {
      FreshIOC.Container.Register<IFreshNavigationService> (this);
    }

    protected void CreateMenuPage(string menuPageTitle)
    {
      var _menuPage = new ContentPage ();
      _menuPage.Title = menuPageTitle;
      var listView = new ListView();

      listView.ItemsSource = new string[] { "Contacts", "Modal Demo" };

      listView.ItemSelected += async (sender, args) =>
        {

          switch ((string)args.SelectedItem) {
            case "Contacts":
              _tabbedNavigationPage.CurrentPage = _debtsPage;
              break;
            case "Modal Demo":
              var modalPage = FreshPageModelResolver.ResolvePageModel<ModalPageModel>();
              await PushPage(modalPage, null, true);
              break;
            default:
              break;
          }

          IsPresented = false;
        };

      _menuPage.Content = listView;

      Master = new NavigationPage(_menuPage) { Title = "Menu" };
    }

    public virtual async Task PushPage (Xamarin.Forms.Page page, FreshBasePageModel model, bool modal = false, bool animated = true)
    {
      if (modal)
        await Navigation.PushModalAsync (new NavigationPage(page), animated);
      else
        await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PushAsync (page, animated); 
    }

    public virtual async Task PopPage (bool modal = false, bool animate = true)
    {
      if (modal)
        await Navigation.PopModalAsync ();
      else
        await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PopAsync (); 
    }

    public virtual async Task PopToRoot (bool animate = true)
    {
      await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PopToRootAsync (animate);
    }
  }
}

