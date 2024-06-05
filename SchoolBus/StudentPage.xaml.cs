using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SchoolBusManagement.Models;

namespace SchoolBusManagement
{
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            StudentsDataGrid.ItemsSource = DataStorage.LoadStudents();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            var students = DataStorage.LoadStudents();
            var student = new Student
            {
                Id = students.Any() ? students.Max(s => s.Id) + 1 : 1,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                ParentName = ParentNameTextBox.Text,
                IdNumber = IdNumberTextBox.Text,
                SchoolNumber = SchoolNumberTextBox.Text,
                Address = AddressTextBox.Text
            };
            students.Add(student);
            DataStorage.SaveStudents(students);
            LoadStudents();
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem != null)
            {
                var selectedStudent = (Student)StudentsDataGrid.SelectedItem;
                var confirmationResult = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmationResult == MessageBoxResult.Yes)
                {
                    var students = DataStorage.LoadStudents();
                    var studentToRemove = students.FirstOrDefault(s => s.Id == selectedStudent.Id);
                    if (studentToRemove != null)
                    {
                        students.Remove(studentToRemove);
                        DataStorage.SaveStudents(students);
                        LoadStudents();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }
    }



}
