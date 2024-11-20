using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Maps;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace MauiApp3.Components
{
    public partial class Map : ContentPage
    {
        public Map()
        {
            InitializeComponent();

            // Add sample pins to the map
            AddSamplePins();
        }

        private void AddSamplePins()
        {
            // Define pins and add them to the map
            var pins = new List<Pin>
            {
                new Pin
                {
                    Label = "Sofa",
                    Address = "Almere Muziekwijk",
                    Location = new Location(52.3676, 4.9041) // Coordinates for Amsterdam
                },
                new Pin
                {
                    Label = "Table",
                    Address = "Almere Muziekwijk",
                    Location = new Location(52.3702, 4.8952) // Another example
                },
                new Pin
                {
                    Label = "Chair",
                    Address = "Almere Muziekwijk",
                    Location = new Location(52.3667, 4.8961) // Another example
                }
            };

            foreach (var pin in pins)
            {
                // Attach a click handler to each pin
                pin.MarkerClicked += OnPinClicked;

                // Add pin to the map
                MyMap.Pins.Add(pin);
            }
        }

        private async void OnPinClicked(object sender, PinClickedEventArgs e)
        {
            var pin = sender as Pin;

            if (pin != null)
            {
                // Display a message or navigate to another page
                await DisplayAlert("Pin Clicked", $"{pin.Label} at {pin.Address}", "OK");
            }
        }

        public void AddPin(string label, string address, Location location)
        {
            var pin = new Pin
            {
                Label = label,
                Address = address,
                Location = location
            };

            pin.MarkerClicked += OnPinClicked;
            MyMap.Pins.Add(pin);
        }

        public void ClearPins()
        {
            MyMap.Pins.Clear();
        }
    }
}
