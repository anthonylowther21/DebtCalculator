using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FreshMvvm;
using DebtCalculatorLibrary.Services;
using DebtCalculator.Shared;
using DebtCalculatorLibrary.Business;

namespace DebtCalculator
{
  public partial class App : Application
  {
    CustomTabbedPage _customTabbedPage;
    public App()
    {
      InitializeComponent();

      _customTabbedPage = new CustomTabbedPage();
      MainPage = _customTabbedPage;
    }

    public new static App Current
    {
      get
      {
        return (App)Application.Current;
      }
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
        InputsFileManager.SaveInputsFileAsync(InputsFileManager.CurrentInputsFile, DebtApp.Shared , () => {});
      }
    }

    protected override void OnResume ()
    {
      // Handle when your app resumes
    }

  }
}

