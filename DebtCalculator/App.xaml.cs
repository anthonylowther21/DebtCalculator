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
    private CustomTabbedPage _tabbedPage = new CustomTabbedPage();

    public App()
    {
      InitializeComponent();

      var page = FreshPageModelResolver.ResolvePageModel<HomePageModel>(this);
      var basicNavContainer = new FreshNavigationContainer (page);

      basicNavContainer.BarBackgroundColor = Colors.Primary;
      basicNavContainer.BarTextColor = Colors.Text_Icons;
      MainPage = basicNavContainer;

      FreshIOC.Container.Register<IFreshNavigationService>(basicNavContainer);
    }

    public void LoadScenario()
    {
      MainPage.Navigation.PushAsync(_tabbedPage);
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

