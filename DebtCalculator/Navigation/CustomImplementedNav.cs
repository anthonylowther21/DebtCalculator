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
  public class CustomImplementedNav : Xamarin.Forms.MasterDetailPage
  {
    FreshTabbedNavigationContainer _tabbedNavigationPage;
    Page _debtsPage;
    Page _paymentsPage;
    Page _amortizationPage;
    Page _summaryPage;

    Page _slideoutPage;
    App _app;

    public CustomImplementedNav (App app)
    { 
      _app = app;
      SetupTabbedPage ();
      CreateMenuPage ("Menu");
      RegisterNavigation ();
    }

    void SetupTabbedPage()
    {
      _tabbedNavigationPage = new FreshTabbedNavigationContainer ();
      _debtsPage = _tabbedNavigationPage.AddTab<DebtListPageModel> ("Debts", "");
      _paymentsPage = _tabbedNavigationPage.AddTab<PaymentListPageModel>("Payments", "");
      _amortizationPage = _tabbedNavigationPage.AddTab<AmortizationListPageModel>("Amortization", "");
      _summaryPage = _tabbedNavigationPage.AddTab<SummaryPageModel>("Summary", "");
      this.Detail = _tabbedNavigationPage;

    }

    protected void RegisterNavigation()
    {
      //FreshIOC.Container.Register<IFreshNavigationService> (this);
    }

    protected void CreateMenuPage(string menuPageTitle)
    {
      _slideoutPage = FreshPageModelResolver.ResolvePageModel<HomePageModel>(_app);

//      var _menuPage = new ContentPage ();
//      _menuPage.Title = menuPageTitle;
//      var listView = new ListView();
//
//      listView.ItemsSource = new string[] { "Debts", "Payments", "Amortizations", "Summary", "Modal Demo" };
//
//      listView.ItemSelected += async (sender, args) =>
//        {
//
//          switch ((string)args.SelectedItem) {
//            case "Debts":
//              _tabbedNavigationPage.CurrentPage = _debtsPage;
//              break;
//            case "Payments":
//              _tabbedNavigationPage.CurrentPage = _paymentsPage;
//              break;
//            case "Amortizations":
//              _tabbedNavigationPage.CurrentPage = _amortizationPage;
//              break;
//            case "Summary":
//              _tabbedNavigationPage.CurrentPage = _summaryPage;
//              break;
//            case "Modal Demo":
//              var modalPage = FreshPageModelResolver.ResolvePageModel<ModalPageModel>();
//              await PushPage(modalPage, null, true);
//              break;
//            default:
//              break;
//          }
//
//          IsPresented = false;
//        };
//
//      _menuPage.Content = listView;

      Master = new NavigationPage(_slideoutPage) { Title = "Menu" };
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

    public string NavigationServiceName { get; private set; }
  }
}

