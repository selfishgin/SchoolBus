using SchoolBusManagement.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SchoolBusManagement
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            bool isAuthenticated = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.NavigateToPage(new AdminHomePage());
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            var users = DataStorage.LoadUsers();
            return users.Any(user => user.Username == username && user.Password == password);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToPage(new RegisterPage());
        }
    }
}
