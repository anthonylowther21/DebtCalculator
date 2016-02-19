using Xamarin.Forms;
using FreshMvvm;
using XLabs.Forms.Controls;
using DebtCalculator.Theme;
using System.Threading.Tasks;
using DebtCalculator.PageModels;

public class CustomTabbedPage : ExtendedTabbedPage, IFreshNavigationService
{
  public CustomTabbedPage ()
  {       
    RegisterNavigation ();

    SetupTabBarStyle();

    this.AddTab<DebtListPageModel> ("Debts", "");
    this.AddTab<PaymentListPageModel>("Payments", "");
    this.AddTab<AmortizationListPageModel>("Amortization", "");
    this.AddTab<SummaryPageModel>("Summary", "");
  }

  public string NavigationServiceName { get; private set; }

  private void SetupTabBarStyle()
  {
    this.BarTintColor = Colors.LightPrimary;
    this.TintColor = Colors.LightPrimary;
  }

  private void SetupPageStyle(NavigationPage np)
  {
    np.BarBackgroundColor = Colors.Primary;
    np.BarTextColor = Colors.Text_Icons;
  }

  protected void RegisterNavigation ()
  {
    FreshIOC.Container.Register<IFreshNavigationService> (this);
  }

  public virtual Page AddTab<T> (string title, string icon, object data = null) where T : FreshBasePageModel
  {
    var page = FreshPageModelResolver.ResolvePageModel<T> (data);
    var navigationContainer = CreateContainerPage (page);
    navigationContainer.Title = title;
    if (!string.IsNullOrWhiteSpace(icon))
      navigationContainer.Icon = icon;
    Children.Add (navigationContainer);
    return page;
  }

  protected virtual Page CreateContainerPage (Page page)
  {
    NavigationPage np = new NavigationPage(page);
    SetupPageStyle(np);
    return page;
  }

  public async System.Threading.Tasks.Task PushPage (Xamarin.Forms.Page page, FreshBasePageModel model, bool modal = false, bool animate = true)
  {
    if (modal)
      await this.CurrentPage.Navigation.PushModalAsync (CreateContainerPage (page));
    else
      await this.CurrentPage.Navigation.PushAsync (page);
  }

  public async System.Threading.Tasks.Task PopPage (bool modal = false, bool animate = true)
  {
    if (modal)
      await this.CurrentPage.Navigation.PopModalAsync (animate);
    else
      await this.CurrentPage.Navigation.PopAsync (animate);
  }

  public async Task PopToRoot (bool animate = true)
  {
    await this.CurrentPage.Navigation.PopToRootAsync (animate);
  }
}