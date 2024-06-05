using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SchoolBusManagement.Models;

namespace SchoolBusManagement
{
    public partial class CarPage : Page
    {
        public CarPage()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            CarsDataGrid.ItemsSource = DataStorage.LoadCars();
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var cars = DataStorage.LoadCars();
            var car = new Car
            {
                Id = cars.Any() ? cars.Max(c => c.Id) + 1 : 1,
                Model = ModelTextBox.Text,
                Vendor = VendorTextBox.Text,
                SerialNumber = SerialNumberTextBox.Text,
                SeatCount = int.Parse(SeatCountTextBox.Text)
            };
            cars.Add(car);
            DataStorage.SaveCars(cars);
            LoadCars();
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (CarsDataGrid.SelectedItem != null)
            {
                var selectedCar = (Car)CarsDataGrid.SelectedItem;
                var confirmationResult = MessageBox.Show("Are you sure you want to delete this car?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmationResult == MessageBoxResult.Yes)
                {
                    var cars = DataStorage.LoadCars();
                    var carToRemove = cars.FirstOrDefault(c => c.Id == selectedCar.Id);
                    if (carToRemove != null)
                    {
                        cars.Remove(carToRemove);
                        DataStorage.SaveCars(cars);
                        LoadCars(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a car to delete.");
            }
        }


    }
}
