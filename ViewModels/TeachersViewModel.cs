using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    class TeachersViewModel : BaseViewModel
    {
        private SchoolEntities context { get; set; }

        public int Index { get; set; }
        public Account Account { get; set; }
        private ObservableCollection<Teacher> teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get
            {
                return teachers;
            }
            set
            {
                teachers = value;
                OnPropertyChanged(nameof(Teachers));
            }
        }

        public void DeleteTeacher(Teacher teacher)
        {
            if(Account.role_id == 4)
            {
                var _teacher = context.Teachers.Where(t => t.teacher_id == teacher.teacher_id).FirstOrDefault();

                context.Teachers.Remove(_teacher);
                context.SaveChanges();

                PopulateTeachers();
            }

        }

        public void PopulateTeachers()
        {
            Teachers = new ObservableCollection<Teacher>();

            var teacherData = context.GetAllTeachers();

            foreach (var teacher in teacherData)
            {
                Teachers.Add(new Teacher()
                {
                    teacher_id = teacher.teacher_id,
                    last_name = teacher.last_name,
                    first_name = teacher.first_name
                });
            }
        }

        public TeachersViewModel(Account account)
        {
            context = new SchoolEntities();
            PopulateTeachers();
            Account = account;
        }
    }
}
