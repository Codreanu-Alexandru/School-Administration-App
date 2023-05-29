using System;
using System.Collections.Generic;
using System.Data;
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

namespace Tema_3_MVP.Views.CreateUpdate
{
    /// <summary>
    /// Interaction logic for RoleCUView.xaml
    /// </summary>
    public partial class RoleCUView : Window
    {
        private RoleCUViewModel viewModel;

        public RoleCUView(Role role)
        {
            InitializeComponent();
            viewModel = new RoleCUViewModel(role);
            DataContext = viewModel;
        }

        public RoleCUView() 
        {
            InitializeComponent();
            viewModel = new RoleCUViewModel();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = viewModel.Confirm();
            if (result)
            {
                this.Close();
            }
        }
    }
}
