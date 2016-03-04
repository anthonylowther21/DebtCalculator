using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using DebtCalculator.Shared;
using FreshMvvm;
using DebtCalculator.Shared;
using XLabs.Forms.Controls;

namespace DebtCalculator.Shared
{
  /// <summary>
  /// This is a sample custom implemented Navigation. It combines a MasterDetail and a TabbedPage.
  /// </summary>
  public class CustomTabbedPage : FreshTabbedNavigationContainer
  {
    //FreshTabbedNavigationContainer _tabbedNavigationPage;
    Page _debtsPage;
    Page _paymentsPage;
    Page _amortizationPage;
    Page _summaryPage;

    Page _slideoutPage;

    public CustomTabbedPage ()
    { 
      SetupTabbedPage ();
      CreateMenuPage ("Menu");
      RegisterNavigation ();
    }

    void SetupTabbedPage()
    {
      //_tabbedNavigationPage = new FreshTabbedNavigationContainer ();
      _debtsPage = new DebtListPage();
      this.Children.Add(_debtsPage);
      //_debtsPage = this.AddTab<DebtListPageModel> ("Debts", "");
      _paymentsPage = this.AddTab<PaymentListPageModel>("Payments", "");
      _amortizationPage = this.AddTab<AmortizationListPageModel>("Amortization", "");
      _summaryPage = this.AddTab<SummaryPageModel>("Summary", "");
//
//      this.Children.Add(FreshPageModelResolver.ResolvePageModel<DebtListPageModel>());
//      this.Children.Add(FreshPageModelResolver.ResolvePageModel<PaymentListPageModel>());
//      this.Children.Add(FreshPageModelResolver.ResolvePageModel<AmortizationListPageModel>());
//      this.Children.Add(FreshPageModelResolver.ResolvePageModel<SummaryPageModel>());
//
    }

    protected void RegisterNavigation()
    {
      //FreshIOC.Container.Register<IFreshNavigationService> (this);
    }

    protected void CreateMenuPage(string menuPageTitle)
    {
      _slideoutPage = FreshPageModelResolver.ResolvePageModel<HomePageModel>();

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

      //Master = new NavigationPage(_slideoutPage) { Title = "Menu" };
    }

    public virtual async Task PushPage (Xamarin.Forms.Page page, FreshBasePageModel model, bool modal = false, bool animated = true)
    {
      if (modal)
        await Navigation.PushModalAsync (new NavigationPage(page), animated);
      else
        await ((NavigationPage)this.CurrentPage).PushAsync (page, animated); 
    }

    public virtual async Task PopPage (bool modal = false, bool animate = true)
    {
      if (modal)
        await Navigation.PopModalAsync ();
      else
        await ((NavigationPage)this.CurrentPage).PopAsync (); 
    }

    public virtual async Task PopToRoot (bool animate = true)
    {
      await ((NavigationPage)this.CurrentPage).PopToRootAsync (animate);
    }

    public string NavigationServiceName { get; private set; }
  }
}

