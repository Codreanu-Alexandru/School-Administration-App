using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    internal class AccountCUViewModel :BaseViewModel
    {
        public SchoolEntities context { get; set; }

        public Account Account { get; set; }

        private int index;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
                OnPropertyChanged(nameof(Index));
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

        private ObservableCollection<Role> roles;
        public ObservableCollection<Role> _Roles
        {
            get
            {
                return roles;
            }
            set
            { 
                roles = value;
                OnPropertyChanged(nameof(_Roles));
            }
        }

        private ObservableCollection<String> rolesString;
        public ObservableCollection<String> Roles
        {
            get
            {
                return rolesString;
            }
            set
            {
                rolesString = value;
                OnPropertyChanged(nameof(Roles));
            }
        }

        private Role role;
        public Role Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        public AccountCUViewModel()
        {
            context = new SchoolEntities();
            _Roles = new ObservableCollection<Role>(context.Roles);
            Roles = new ObservableCollection<string>(context.Roles.Select(x => x.role_title));
        }

        public AccountCUViewModel(Account account)
        {
            Account = account;
            context = new SchoolEntities();
            _Roles = new ObservableCollection<Role>(context.Roles);
            Roles = new ObservableCollection<string>(context.Roles.Select(x => x.role_title));

            Username = account.account_name;
            Password = account.account_password;
            Role = account.Role;
        }

        public bool Confirm()
        {
            if(Account != null)
            {
                if (Password != null && Username != null)
                {
                    var result = context.Accounts.First(a => a.account_id == Account.account_id);

                    result.account_name = Username;
                    result.account_password = Password;
                    result.Role = _Roles[Index];
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (Password != null && Username != null)
                {
                    context.Accounts.Add(new Account
                    {
                        account_id = context.Accounts.Count()+1,
                        account_name = Username,
                        account_password = Password,
                        Role = _Roles[Index],
                    });

                    context.SaveChanges();
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }
    }
}
