using System;
using Microsoft.Maui.Controls;

namespace MauiApp3.Components
{
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void OnFilterButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Filter", "Filter button clicked!", "OK");
        }

        private void OnSortPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is Picker picker)
            {
                string selectedOption = picker.SelectedItem?.ToString() ?? "None";
                DisplayAlert("Sort", $"Sorted by: {selectedOption}", "OK");
            }
        }

        private async void OnExploreButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Explore", "Explore button clicked!", "OK");
        }

        private async void OnSpotsButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Spots", "Spots button clicked!", "OK");
        }

        private async void OnProfileButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Profile", "Profile button clicked!", "OK");
        }
    }
}
