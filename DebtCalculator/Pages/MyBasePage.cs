using System;
using Xamarin.Forms;
using DebtCalculator.Navigation;

namespace DebtCalculator.Pages
{
    public class MyBasePage : ContentPage
    {
        public MyBasePage ()
        {
            ToolbarItems.Add (new ToolbarItem ("Main Menu", null, () => {
                Application.Current.MainPage = new NavigationPage (new CustomImplementedNav ());
            }));
        }
    }
}

