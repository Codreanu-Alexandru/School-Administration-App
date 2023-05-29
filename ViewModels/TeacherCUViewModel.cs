using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    internal class TeacherCUViewModel : BaseViewModel
    {
        private SchoolEntities context { get; set; }
        public Teacher Teacher { get; set; }

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

        private String firstName;
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private String lastName;
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public TeacherCUViewModel()
        {
            context = new SchoolEntities();
        }

        public TeacherCUViewModel(Teacher teacher)
        {
            context = new SchoolEntities();
            var _teacher = context.Teachers.FirstOrDefault(t => t.teacher_id == teacher.teacher_id);
            Teacher = _teacher;

            var account = context.Accounts.FirstOrDefault(a => a.account_id == Teacher.account_id);
            Username = account.account_name;
            Password = account.account_password;
            FirstName = Teacher.first_name;
            LastName = Teacher.last_name;

        }

        public bool Confirm()
        {
            if (Teacher != null)
            {
                if (Username != null && Password != null && FirstName != null && LastName != null)
                {
                    var result = context.Teachers.FirstOrDefault(t => t.teacher_id == Teacher.teacher_id);
                    result.last_name = LastName;
                    result.first_name = FirstName;
                    result.Account = Teacher.Account;
                    result.Account.account_name = Username;
                    result.Account.account_password = Password;

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
                if (Username != null && Password != null && FirstName != null && LastName != null)
                {
                    context.Teachers.Add(new Teacher()
                    {
                        Account = new Account()
                        {
                            account_name = Username,
                            account_password = Password,
                            role_id = 2
                        },
                        last_name = LastName,
                        first_name = FirstName
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
