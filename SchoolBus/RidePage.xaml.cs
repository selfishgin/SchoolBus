using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SchoolBusManagement.Models;

namespace SchoolBusManagement
{
    public partial class RidePage : Page
    {
        public RidePage()
        {
            InitializeComponent();
            LoadRides();
        }

        private void LoadRides()
        {
            RidesDataGrid.ItemsSource = DataStorage.LoadRides();
        }

        private void AddRide_Click(object sender, RoutedEventArgs e)
        {
            var rides = DataStorage.LoadRides();
            var ride = new Ride
            {
                Id = rides.Any() ? rides.Max(r => r.Id) + 1 : 1,
                DriverId = int.Parse(DriverIdTextBox.Text),
                BusId = int.Parse(BusIdTextBox.Text),
                DepartureTime = DepartureDatePicker.SelectedDate ?? DateTime.Now,
                Destination = DestinationTextBox.Text
            };
            rides.Add(ride);
            DataStorage.SaveRides(rides);
            LoadRides();
        }

        private void DeleteRide_Click(object sender, RoutedEventArgs e)
        {
            if (RidesDataGrid.SelectedItem != null)
            {
                var selectedRide = (Ride)RidesDataGrid.SelectedItem;
                var confirmationResult = MessageBox.Show("Are you sure you want to delete this ride?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmationResult == MessageBoxResult.Yes)
                {
                    var rides = DataStorage.LoadRides();
                    var rideToRemove = rides.FirstOrDefault(r => r.Id == selectedRide.Id);
                    if (rideToRemove != null)
                    {
                        rides.Remove(rideToRemove);
                        DataStorage.SaveRides(rides);
                        LoadRides(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a ride to delete.");
            }
        }
    }
}
