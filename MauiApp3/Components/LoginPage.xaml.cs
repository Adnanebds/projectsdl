using Microsoft.Maui.Controls;

namespace MauiApp3.Components
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (UsernameEntry.Text == "admin" && PasswordEntry.Text == "password")
            {
                await DisplayAlert("Succes", "Inloggen geslaagd!", "OK");
            }
            else
            {
                await DisplayAlert("Fout", "Ongeldige gebruikersnaam of wachtwoord", "OK");
            }
        }
    }
}