using System;
using Microsoft.Maui.Controls;

namespace MauiApp3.Components
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Event handler for navigating to LoginPage
        private async void NavigateToLoginPage(object sender, EventArgs e)
        {
            // Navigate to LoginPage
            await Navigation.PushAsync(new LoginPage());
        }
    }
}