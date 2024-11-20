using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiApp3.Components
{
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }

        // Sort Button Clicked Event
        private async void OnSortButtonClicked(object sender, EventArgs e)
        {
            // Display the dropdown with sorting options (Date, Reviews)
            var action = await DisplayActionSheet("Sort Options", "Cancel", null, "Date", "Reviews");

            if (action == "Date")
            {
                // Add logic for Date sorting
                await DisplayAlert("Sort", "Sorting by Date", "OK");
                // Call your sorting logic for Date here
            }
            else if (action == "Reviews")
            {
                // Add logic for Reviews sorting
                await DisplayAlert("Sort", "Sorting by Reviews", "OK");
                // Call your sorting logic for Reviews here
            }
            else
            {
                // Option was Cancelled
                await DisplayAlert("Sort", "Sort cancelled", "OK");
            }
        }

        // Filter Button Clicked Event
        private async void OnFilterButtonClicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Filter Options", "Cancel", null, "Filter 1", "Filter 2", "Filter 3");
            if (action == "Filter 1")
            {
                // Add logic for Filter 1
                await DisplayAlert("Filter", "Filter 1 selected", "OK");
            }
            else if (action == "Filter 2")
            {
                // Add logic for Filter 2
                await DisplayAlert("Filter", "Filter 2 selected", "OK");
            }
            else if (action == "Filter 3")
            {
                // Add logic for Filter 3
                await DisplayAlert("Filter", "Filter 3 selected", "OK");
            }
        }
    }
}