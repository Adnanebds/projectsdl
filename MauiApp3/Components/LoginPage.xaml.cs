using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;  // Ensure Newtonsoft.Json is installed

namespace MauiApp3.Components
{
    public partial class LoginPage : ContentPage
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            // Navigate to the RegistrationPage
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Retrieve user input
            string username = UsernameEntry.Text?.Trim();
            string password = PasswordEntry.Text;

            // Validate input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please enter both username and password", "OK");
                return;
            }

            // Create the login data object
            var loginData = new
            {
                Email = username,
                Password = password
            };

            // Send the login request to the Node.js API
            var loginSuccess = await AuthenticateUser(loginData);

            // Display the result
            if (loginSuccess)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        // Method to authenticate the user by making an HTTP POST request to the Node.js API
        private async Task<bool> AuthenticateUser(object loginData)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Log the request details
                
                Console.WriteLine($"Request Body: {jsonContent}");


                // Replace with your actual Node.js API login endpoint
                var response = await httpClient.PostAsync("https://8489-86-93-44-129.ngrok-free.app/api/login", content);

               

                // Log the response details
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Body: {responseBody}");
                Console.WriteLine($"Request URL: {response}");

                if (response.IsSuccessStatusCode)
                {
                    // If you expect a message or token in the response, you can process it here
                    // For simplicity, we assume success if the status code is 200
                    return true;
                }
                else
                {
                    // If the response indicates failure, return false
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Handle any exceptions that occur during the HTTP request
                await DisplayAlert("Error", $"An error occurred while logging in: {ex.Message}", "OK");
                return false;
            }
        }
    }
}
