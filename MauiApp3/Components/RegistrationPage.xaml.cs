using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiApp3.Components
{
    public partial class RegistrationPage : ContentPage
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void OnRegistrationButtonClicked(object sender, EventArgs e)
        {
            // Retrieve user input
            string name = NameEntryRegistration.Text?.Trim();
            string email = EmailEntryRegistration.Text?.Trim();
            string password = PasswordEntryRegistration.Text;

            // Validate input fields
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please enter all fields", "OK");
                return;
            }

            // Log user data for debugging
            Console.WriteLine($"Name: {name}, Email: {email}, Password: {password}");

            // Create the user data object
            var userData = new
            {
                Name = name,
                Email = email,
                Password = password,
                Role = "user",
                Bio = ""
            };

            // Send the registration request to the Node.js API
            var registrationSuccess = await RegisterUser(userData);

            // Display the result
            if (registrationSuccess)
            {
                await DisplayAlert("Success", "User registered successfully!", "OK");
                // Navigate to LoginPage after successful registration
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Error", "Registration failed. Please try again.", "OK");
            }
        }

        // Method to register the user by making an HTTP POST request to the Node.js API
        private async Task<bool> RegisterUser(object userData)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(userData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://8489-86-93-44-129.ngrok-free.app/api/users", content);

                // Log response details for debugging
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Body: {responseBody}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                await DisplayAlert("Error", $"An error occurred while registering: {ex.Message}", "OK");
                return false;
            }
        }
    }
}