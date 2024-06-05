using System.Windows;
using System.Windows.Controls;

namespace SchoolBusManagement
{
    public partial class AdminHomePage : Page
    {
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void NavigateToCarPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CarPage());
        }

        private void NavigateToDriverPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DriverPage());
        }

        private void NavigateToRidePage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RidePage());
        }

        private void NavigateToStudentPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentPage());
        }


    }
}
