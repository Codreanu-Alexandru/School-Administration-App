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

namespace Tema_3_MVP.Views.CreateUpdate
{
    /// <summary>
    /// Interaction logic for TeacherCUView.xaml
    /// </summary>
    public partial class TeacherCUView : Window
    {
        private TeacherCUViewModel viewModel;

        public TeacherCUView()
        {
            InitializeComponent();
            viewModel = new TeacherCUViewModel();
            DataContext = viewModel;
        }

        public TeacherCUView(Teacher teacher)
        {
            InitializeComponent();
            viewModel = new TeacherCUViewModel(teacher);
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool reasult = viewModel.Confirm();
            if (reasult)
            {
                this.Close();
            }
        }
    }
}
