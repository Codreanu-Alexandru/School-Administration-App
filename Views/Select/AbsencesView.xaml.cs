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
    /// Interaction logic for AbsencesView.xaml
    /// </summary>
    public partial class AbsencesView : UserControl
    {
        private AbsencesViewModel viewModel;

        public AbsencesView(Account account)
        {
            InitializeComponent();
            viewModel = new AbsencesViewModel(account);
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainView();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.Account.role_id == 4)
            {
                AbsenceCUView view = new AbsenceCUView();
                view.Show();
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
                var context = new SchoolEntities();
                var absence = viewModel.Absences[viewModel.Index];

                var result = context.Absences.FirstOrDefault(a => 
                a.student_id == absence.student_id &&
                a.subject_id == absence.subject_id &&
                a.date == absence.date);
                if (result != null)
                {
                    AbsenceCUView view = new AbsenceCUView(result);
                    view.Show();
                }
                else
                {
                    MessageBox.Show("Account not found.", "Error");
                }

            }
            else
            {
                MessageBox.Show("You need higher clearance level to access this.", "Permission Denied");
                (sender as Button).IsEnabled = false;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.Account.role_id == 4)
            {
                var account = sender as Account;
                var contex = new SchoolEntities();
                contex.Accounts.Remove(account);
                contex.SaveChanges();
            }
            else
            {
                MessageBox.Show("You need higher clearance level to access this.", "Permission Denied");
                (sender as Button).IsEnabled = false;
            }
        }
    }
}
