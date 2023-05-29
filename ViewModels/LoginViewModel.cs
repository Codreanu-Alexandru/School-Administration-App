using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Account Account { get; set; }

        private bool? loggedIn;
        public bool? LoggedIn
        {
            get
            {
                return loggedIn;
            }
            set
            {
                loggedIn = value;
                OnPropertyChanged(nameof(LoggedIn));
            }
        }

        private String username;
        public String Username
        {
            get 
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private String password;
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {

        }

        public LoginViewModel(ref Account account)
        {
            this.Account = account;
        }

        public bool LogIn()
        {
            var context = new SchoolEntities();

            if(Username != null && Password != null)
            {
                Account = context.Accounts.Where(a => a.account_name == Username && a.account_password == Password).FirstOrDefault();

                if(Account != null)
                {
                    LoggedIn = true;
                }
                else
                {
                    LoggedIn = false;
                }
            }
            else
            {
                LoggedIn = false;
            }

            return LoggedIn.Value;
        }
    }
}
