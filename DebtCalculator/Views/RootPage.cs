using System;

using Xamarin.Forms;

namespace DebtCalculator
{
    public class RootPage : ContentPage
    {
        public RootPage()
        {
            Content = new StackLayout
            { 
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label 
                    { 
                        XAlign = TextAlignment.Center,
                        Text = "Hello ContentPage"
                    }
                }
            };
        }
    }
}


