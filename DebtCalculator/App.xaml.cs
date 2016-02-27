using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FreshMvvm;
using DebtCalculator.Navigation;
using DebtCalculatorLibrary.Services;
using DebtCalculator.PageModels;
using DebtCalculator.Theme;
using DebtCalculatorLibrary.Business;

namespace DebtCalculator
{
  public partial class App : Application
  {
    CustomImplementedNav _customImplementedNav;
    public App()
    {
      InitializeComponent();

      _customImplementedNav = new CustomImplementedNav(this);
      MainPage = _customImplementedNav;
      //Page page = FreshPageModelResolver.ResolvePageModel<HomePageModel>(this);
      //MainPage = new FreshNavigationContainer(page);
      //FreshIOC.Container.Register<IFreshNavigationService> (this);
      //NavigationPage np = new NavigationPage (new MainTabbedPage ());
      //np.BarBackgroundColor = Color.Gray;
      //MainPage = np;
    }

    public void SetSideMenuVisibility(bool shown)
    {
      _customImplementedNav.IsPresented = shown;
    }

    protected override void OnStart ()
    {
      // Handle when your app starts
    }

    protected override void OnSleep ()
    {
      // Handle when your app sleeps
      if (InputsFileManager.CurrentInputsFile != string.Empty)
      {
        InputsFileManager.SaveInputsFile(InputsFileManager.CurrentInputsFile, DebtApp.Shared);
      }
    }

    protected override void OnResume ()
    {
      // Handle when your app resumes
    }

  }
}

