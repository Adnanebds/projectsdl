using Microsoft.Maui.Controls;

namespace MauiApp3.Components
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {
            // Maak de invoervelden voor gebruikersnaam en wachtwoord
            var usernameEntry = new Entry
            {
                Placeholder = "Gebruikersnaam",
                Keyboard = Keyboard.Text,
                Margin = new Thickness(0, 20)
            };

            var passwordEntry = new Entry
            {
                Placeholder = "Wachtwoord",
                IsPassword = true,
                Keyboard = Keyboard.Text,
                Margin = new Thickness(0, 10)
            };

            // Maak een inlogknop
            var loginButton = new Button
            {
                Text = "Inloggen",
                BackgroundColor = Colors.SkyBlue,
                TextColor = Colors.White,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20)
            };

            // Voeg een eventhandler toe voor de inlogknop
            loginButton.Clicked += (sender, e) =>
            {
                // Hier zou je inloglogica kunnen toevoegen, bijvoorbeeld:
                if (usernameEntry.Text == "admin" && passwordEntry.Text == "password")
                {
                    DisplayAlert("Succes", "Inloggen geslaagd!", "OK");
                }
                else
                {
                    DisplayAlert("Fout", "Ongeldige gebruikersnaam of wachtwoord", "OK");
                }
            };

            // Maak een StackLayout om de elementen in te plaatsen
            var stackLayout = new StackLayout
            {
                Padding = new Thickness(20),
                VerticalOptions = LayoutOptions.Center,
                Children = { usernameEntry, passwordEntry, loginButton }
            };

            // Stel de inhoud van de pagina in
            Content = stackLayout;
        }
    }
}
