using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SchoolBusManagement.Models;

namespace SchoolBusManagement
{
    public partial class DriverPage : Page
    {
        public DriverPage()
        {
            InitializeComponent();
            LoadDrivers();
        }

        private void LoadDrivers()
        {
            DriversDataGrid.ItemsSource = DataStorage.LoadDrivers();
        }

        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            var drivers = DataStorage.LoadDrivers();
            var driver = new Driver
            {
                Id = drivers.Any() ? drivers.Max(d => d.Id) + 1 : 1,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                License = LicenseTextBox.Text,
                Address = AddressTextBox.Text,
                BusId = int.Parse(BusIdTextBox.Text)
            };
            drivers.Add(driver);
            DataStorage.SaveDrivers(drivers);
            LoadDrivers();
        }


        private void DeleteDriver_Click(object sender, RoutedEventArgs e)
        {
            if (DriversDataGrid.SelectedItem != null)
            {
                var selectedDriver = (Driver)DriversDataGrid.SelectedItem;
                var confirmationResult = MessageBox.Show("Are you sure you want to delete this driver?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmationResult == MessageBoxResult.Yes)
                {
                    var drivers = DataStorage.LoadDrivers();
                    var driverToRemove = drivers.FirstOrDefault(d => d.Id == selectedDriver.Id);
                    if (driverToRemove != null)
                    {
                        drivers.Remove(driverToRemove);
                        DataStorage.SaveDrivers(drivers);
                        LoadDrivers(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a driver to delete.");
            }
        }
    }
}
