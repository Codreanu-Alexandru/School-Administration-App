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
using Tema_3_MVP.Views;

namespace Tema_3_MVP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //LoginViewModel LoginViewModel;
        public Account Account;

        public MainWindow()
        {
            InitializeComponent();
            //viewModel = new MainViewModel();
            //this.DataContext = viewModel;
            //LoginViewModel = new LoginViewModel();
            //this.DataContext = LoginViewModel;
        }

        void PermissionDenied(object sender)
        {
            MessageBox.Show("You need higher clearance level to access this.", "Permission Denied");
            (sender as MenuItem).IsEnabled = false;
        }

        private void Accounts_Click(object sender, RoutedEventArgs e)
        {
            if(Account.role_id == 4)
            {
                // _loginView = new LoginView();
                //this.Content = new AccountsView();
                //var account = new AccountsViewModel();
                Main.Content = new AccountsView(Account);
                //Main.DataContext = account;
            }
            else
            {
                PermissionDenied(sender);
            }
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(Account != null)
            {
                LoginMenuItem.Header = "Confirm";
                LoginMenuItem.Background = new SolidColorBrush(Colors.White);
            }

            if(Main.Content as LoginView != null)
            {
                Account = (Main.Content as LoginView).viewModel.Account;
                if(Account == null)
                {
                    LoginMenuItem.Header = "Account not registed";
                    LoginMenuItem.Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    LoginMenuItem.Header = "Logged In";
                    LoginMenuItem.Background = new SolidColorBrush(Colors.Green);
                }
            }
            else
            {
                var loginView = new LoginView();
                Main.Content = loginView;
                LoginMenuItem.Header = "Confirm";
            }

            EnabledDockMenu();
        }

       public void EnabledDockMenu()
        {
            if(Account != null) 
            {
                foreach(var item in DockMenu.Items)
                {
                    (item as MenuItem).IsEnabled = true;
                }
            }
            else
            {
                for(var i = 1; i < DockMenu.Items.Count; i++)
                {
                    (DockMenu.Items[i] as MenuItem).IsEnabled = false;
                }
            }
        }

        private void Students_Click(object sender, RoutedEventArgs e)
        {
            switch (Account.role_id)
            {
                case 1:
                    PermissionDenied(sender);
                    break;

                case 2:
                    Main.Content = new StudentsView(Account);
                    break;

                case 3:
                    Main.Content = new StudentsView(Account);
                    break;

                case 4:
                    Main.Content = new StudentsView(Account);
                    break;

                default:
                    MessageBox.Show("Unknown clearance level.", "Something went wrong");
                    break;
            }
        }

        private void Teachers_Click(object sender, RoutedEventArgs e)
        {
            switch (Account.role_id)
            {
                case 1:
                    PermissionDenied(sender);
                    break;

                case 2:
                    PermissionDenied(sender);
                    break;

                case 3:
                    PermissionDenied(sender);
                    break;

                case 4:
                    Main.Content = new TeachersView(Account);
                    break;

                default:
                    MessageBox.Show("Unknown clearance level.", "Something went wrong");
                    break;
            }
        }

        private void Classes_Click(object sender, RoutedEventArgs e)
        {
            switch (Account.role_id)
            {
                case 1:
                    Main.Content = new ClassesView(Account);
                    break;

                case 2:
                    Main.Content = new ClassesView(Account);
                    break;

                case 3:
                    Main.Content = new ClassesView(Account);
                    break;

                case 4:
                    Main.Content = new ClassesView(Account);
                    break;

                default:
                    MessageBox.Show("Unknown clearance level.", "Something went wrong");
                    break;
            }
        }

        private void Subjects_Click(object sender, RoutedEventArgs e)
        {
            switch (Account.role_id)
            {
                case 1:
                    Main.Content = new SubjectsView(Account);
                    break;

                case 2:
                    MessageBox.Show("What's even the point ?", "Please help me");
                    break;

                case 3:
                    MessageBox.Show("What's even the point ?", "Please help me");
                    break;

                case 4:
                    Main.Content = new SubjectsView(Account);
                    break;

                default:
                    MessageBox.Show("Unknown clearance level.", "Something went wrong");
                    break;
            }
        }

        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            switch (Account.role_id)
            {
                case 1:
                    Main.Content = new GradesView(Account);
                    break;

                case 2:
                    Main.Content = new GradesView(Account);
                    break;

                case 3:
                    Main.Content = new GradesView(Account);
                    break;

                case 4:
                    Main.Content = new GradesView(Account);
                    break;

                default:
                    MessageBox.Show("Unknown clearance level.", "Something went wrong");
                    break;
            }
        }

        private void Absesces_Click(object sender, RoutedEventArgs e)
        {
            switch (Account.role_id)
            {
                case 1:
                    Main.Content = new AbsencesView(Account);
                    break;

                case 2:
                    Main.Content = new AbsencesView(Account);
                    break;

                case 3:
                    Main.Content = new AbsencesView(Account);
                    break;

                case 4:
                    Main.Content = new AbsencesView(Account);
                    break;

                default:
                    MessageBox.Show("Unknown clearance level.", "Something went wrong");
                    break;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(Account.role_id==4)
            {
                Main.Content = new RolesView(Account);
            }
            else
            {
                MessageBox.Show("What's even the point ?", "Please help me");
            }
        }
    }
}
