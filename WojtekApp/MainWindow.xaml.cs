using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WojtekApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentDAO StudentDAO = new("Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=StudentsDatabase");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Student student= new Student();
            student.Name = nameTextbox.Text;
            student.Surname = surnameTextbox.Text;
            student.Class = classTextbox.Text;
            
            StudentDAO.create(student);
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            List<Student> students = StudentDAO.getAll();

            showDatagrid.ItemsSource= students;
        }
    }
}
