using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FreshMvvm;
using DebtCalculator.Navigation;

namespace DebtCalculator
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      FreshIOC.Container.Register<IDatabaseService, DatabaseService> ();

      MainPage = new NavigationPage( new CustomImplementedNav ());
      //NavigationPage np = new NavigationPage (new MainTabbedPage ());
      //np.BarBackgroundColor = Color.Gray;
      //MainPage = np;

    }

    protected override void OnStart ()
    {
      // Handle when your app starts
    }

    protected override void OnSleep ()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume ()
    {
      // Handle when your app resumes
    }

  }
}

