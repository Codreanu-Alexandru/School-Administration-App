using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    internal class RoleCUViewModel : BaseViewModel
    {
        public Role Role { get; set; }

        private String title;
        public String Title
        { 
            get 
            { 
                return title;
            } 
            set
            { 
                title = value;
                OnPropertyChanged(nameof(Title));
            } 
        }

        public RoleCUViewModel() 
        {

        }

        public RoleCUViewModel(Role role)
        {
            this.Role = role;
            Title = Role.role_title;
        }

        public bool Confirm()
        {
            var context = new SchoolEntities();
            if(Role == null) 
            {
                if(Title != null)
                {
                    context.Roles.Add(new Role()
                    {
                        role_title = Title
                    });

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
                if(Title != null)
                {
                    var result = context.Roles.FirstOrDefault(x => x.role_id == Role.role_id);

                    result.role_title = Title;
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
