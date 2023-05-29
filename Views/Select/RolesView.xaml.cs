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
    /// Interaction logic for RolesView.xaml
    /// </summary>
    public partial class RolesView : UserControl
    {
        private RolesViewModel viewModel;

        public RolesView(Account account)
        {
            InitializeComponent();
            viewModel = new RolesViewModel(account);
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
                RoleCUView view = new RoleCUView();
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
                var role = viewModel.Roles[viewModel.Index];

                var result = context.Roles.FirstOrDefault(r => r.role_id == role.role_id);
                if (result != null)
                {
                    RoleCUView view = new RoleCUView(result);
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
            MessageBox.Show("You need higher clearance level to access this.", "Permission Denied");
            (sender as Button).IsEnabled = false;
        }
    }
}
