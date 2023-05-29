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
using Tema_3_MVP.Models;
using Tema_3_MVP.ViewModels;
using Tema_3_MVP.Views.CreateUpdate;

namespace Tema_3_MVP.Views
{
    /// <summary>
    /// Interaction logic for StudentsView.xaml
    /// </summary>
    public partial class StudentsView : UserControl
    {
        private StudentsViewModel viewModel;

        public StudentsView(Account account)
        {
            InitializeComponent();
            viewModel = new StudentsViewModel(account);
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainView();
        }

        private void FinalGrade_Click(object sender, RoutedEventArgs e)
        {
            //var student = sender as Student;
            MessageBox.Show("Sorry, had no time for this :(");

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(viewModel.Account.role_id == 4)
            {
                viewModel.DeleteStudent(viewModel.Students[viewModel.Index]);
            }
            else
            {
                MessageBox.Show("You need higher clearance level to access this.", "Permission Denied");
                (sender as Button).IsEnabled = false;
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.Account.role_id == 4)
            {
                StudentCUView view = new StudentCUView(viewModel.Students[viewModel.Index]);
                view.Show();
            }
            else
            {
                MessageBox.Show("You need higher clearance level to access this.", "Permission Denied");
                (sender as Button).IsEnabled = false;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.Account.role_id == 4)
            {
                StudentCUView view = new StudentCUView();
                view.Show();
            }
            else
            {
                MessageBox.Show("You need higher clearance level to access this.", "Permission Denied");
                (sender as Button).IsEnabled = false;
            }
        }
    }
}
