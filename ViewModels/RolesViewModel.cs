using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    class RolesViewModel : BaseViewModel
    {
        public Account Account { get; set; }
        public int Index { get; set; }

        private ObservableCollection<Role> roles;
        public ObservableCollection<Role> Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }

        public RolesViewModel(Account account)
        {
            var context = new SchoolEntities();
            Roles = new ObservableCollection<Role>(context.Roles);
            Account = account;
        }
    }
}
