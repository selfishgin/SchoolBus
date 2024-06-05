using SchoolBusManagement.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SchoolBusManagement
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            var users = DataStorage.LoadUsers();
            if (users.Any(user => user.Username == username))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            users.Add(new User { Username = username, Password = password });
            DataStorage.SaveUsers(users);

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToPage(new LoginPage());
            MessageBox.Show("Registration successful. Please log in.");
        }
    }
}
