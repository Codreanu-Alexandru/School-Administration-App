using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    internal class StudentCUViewModel : BaseViewModel
    {
        SchoolEntities context { get; set; }

        public int Index { get; set; }
        public Student Student { get; set; }

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

        private Class _class;
        public Class Class
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
                OnPropertyChanged(nameof(Class));
            }
        }

        private ObservableCollection<Class> _classes;
        public ObservableCollection<Class> _Classes
        {
            get
            {
                return _classes;
            }
            set
            {
                _classes = value;
                OnPropertyChanged(nameof(_Classes));
            }
        }

        private ObservableCollection<String> classes;
        public ObservableCollection<String> Classes
        {
            get
            {
                return classes;
            }
            set
            {
                classes = value;
                OnPropertyChanged(nameof(Classes));
            }
        }

        public StudentCUViewModel()
        {
            context = new SchoolEntities();
            _Classes = new ObservableCollection<Class>(context.Classes);
            Classes = new ObservableCollection<string>(context.Classes.Select(c => c.year + " " + c.division + " " + c.specialization));
        }

        public StudentCUViewModel(Student student)
        {
            context = new SchoolEntities();
            _Classes = new ObservableCollection<Class>(context.Classes);
            Classes = new ObservableCollection<string>(context.Classes.Select(c => c.year + " " + c.division + " " + c.specialization));

            var _student = context.Students.FirstOrDefault(s => s.student_id == student.student_id);
            Student = _student;
            var account = context.Accounts.FirstOrDefault(a => a.account_id == _student.account_id);
            Class = Student.Class;
            Username = account.account_name;
            Password = account.account_password;
            FirstName = Student.first_name;
            LastName = Student.last_name;
            
        }

        public bool Confirm()
        {
            if (Student != null)
            {
                if (Username != null && Password != null && FirstName != null && LastName != null)
                {
                    var result = context.Students.FirstOrDefault(s => s.student_id == Student.student_id);
                    result.last_name = LastName;
                    result.first_name = FirstName;
                    result.Account = Student.Account;
                    result.Account.account_name = Username;
                    result.Account.account_password = Password;
                    result.Class = _Classes[Index];

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
                    context.Students.Add(new Student()
                    {
                        Account = new Account()
                        {
                            account_name = Username,
                            account_password = Password,
                            role_id = 1
                        },
                        last_name = LastName,
                        first_name = FirstName,
                        Class = _Classes[Index]
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
