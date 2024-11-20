using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace MauiApp3.Components
{
    public partial class SpotAanmaken : ContentPage, INotifyPropertyChanged
    {
        public List<string> Categories { get; set; }
        public ObservableCollection<ImageSource> Images { get; set; }

        public SpotAanmaken()
        {
            InitializeComponent();

            Categories = new List<string>
            {
                "Plastic",
                "Metaal",
                "Hout",
                "Anders"
            };

            Images = new ObservableCollection<ImageSource>();
            BindingContext = this;
        }

        private async void OnAddImageClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Kies een afbeelding"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                    Images.Add(image);

                    // Debug output
                    Console.WriteLine($"Image added. Total images: {Images.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnAddImageClicked: {ex.Message}");
                await DisplayAlert("Fout", $"Er is een fout opgetreden: {ex.Message}", "OK");
            }
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Product Toevoegen",
                                              "Weet je zeker dat je dit product wilt toevoegen?",
                                              "Ja",
                                              "Nee");

            if (confirm)
            {
                // Logic to save the product can be added here
                await DisplayAlert("Success", "Product is succesvol toegevoegd!", "OK");
                await Navigation.PopModalAsync(); // Close the page
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}