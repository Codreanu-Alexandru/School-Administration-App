using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    class AccountsViewModel : BaseViewModel
    {
        public int Index { get; set; }

        public Account Account { get; set; }

        private ObservableCollection<Account> accounts;
        public ObservableCollection<Account> Accounts
        {
            get
            {
                return accounts;
            }
            set
            {
                accounts = value;
                OnPropertyChanged(nameof(Accounts));
            }
        }

        public AccountsViewModel(Account account)
        {
            var context = new SchoolEntities();
            Accounts = new ObservableCollection<Account>(context.Accounts);
            Account = account;
        }
    }
}
