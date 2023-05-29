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
    class ClassesViewModel : BaseViewModel
    {
        public int Index { get; set; }
        public Account Account { get; set; }

        private ObservableCollection<Class> classes;
        public ObservableCollection<Class> Classes
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

        public void DeleteClass(Class _class)
        {
            if(Account.role_id == 4)
            {
                var context = new SchoolEntities();

                if(context.Classes.Where(c => c.class_id == _class.class_id).Any())
                {
                    context.Classes.Remove(_class);
                    PopulateClasses();
                }
            }
        }

        public void PopulateClasses()
        {
            var context = new SchoolEntities();
            Classes = new ObservableCollection<Class>();
            var classesData = context.GetAllClasses();

            switch (Account.role_id)
            {
                case 1:

                    var student = context.Students.FirstOrDefault(s => s.account_id == Account.account_id);
                    var sr_classes = context.Classes.Where(c => c.class_id == student.class_id);
                    foreach (var _class in sr_classes)
                    {
                        Classes.Add(_class);
                    }
                    break;

                case 2:
                    MessageBox.Show("What's even the point ?", "Please help me");
                    break;

                case 3:

                    var teacher = context.Teachers.FirstOrDefault(t => t.account_id == Account.account_id);
                    var htr_classes = context.Classes.Where(c => c.head_teacher_id == teacher.teacher_id);

                    foreach (var _class in htr_classes)
                    {
                        Classes.Add(_class);
                    }

                    break;

                case 4:
                    foreach (var _class in classesData)
                    {
                        Classes.Add(new Class()
                        {
                            class_id = _class.class_id,
                            head_teacher_id = _class.head_teacher_id,
                            division = _class.division,
                            specialization = _class.specialization,
                            year = _class.year,
                        });
                    }
                    break;

                default:
                    MessageBox.Show("Unknown clearance level.", "Something went wrong");
                    break;
            }
            }

        public ClassesViewModel(Account account)
        {
            Account = account;
            PopulateClasses();
        }
    }
}
