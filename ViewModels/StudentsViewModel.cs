using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    class StudentsViewModel :BaseViewModel
    {
        private SchoolEntities context { get; set; }
        public int Index { get; set; }
        public Account Account { get; set; }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public void DeleteStudent(Student student)
        {
            if(Account.role_id == 4)
            {
                var _student = context.Students.Where(s => s.student_id == student.student_id).FirstOrDefault();
                context.Students.Remove(_student);
                context.SaveChanges();
                PopulateStudents();
            }
        }

        void PopulateStudents()
        {
            Students = new ObservableCollection<Student>();
            var studentData = context.GetAllStudents();

            if (Account.role_id == 4)
            {
                foreach (var student in studentData)
                {
                    Students.Add(new Student()
                    {
                        student_id = student.student_id,
                        class_id = student.class_id,
                        first_name = student.first_name,
                        last_name = student.last_name
                    });
                }
            }
            else
            {
                var teacher = context.Teachers.FirstOrDefault(t => t.account_id == Account.account_id);
                var subjectIds = context.Subjects
                    .Where(s => s.teacher_id == teacher.teacher_id)
                    .Select(s => s.subject_id)
                    .ToList();

                var classIds = context.Classes
                    .Where(c => subjectIds.Contains(c.class_id))
                    .Select(c => c.class_id)
                    .ToList();

                var students = context.Students
                    .Where(s => classIds.Contains(s.class_id))
                    .ToList();

                foreach (var student in students)
                {
                    Students.Add(new Student()
                    {
                        student_id = student.student_id,
                        class_id = student.class_id,
                        first_name = student.first_name,
                        last_name = student.last_name
                    });
                }
            }
        }

        public StudentsViewModel(Account account)
        {
            Account = account;
            context = new SchoolEntities();
            PopulateStudents();
        }
    }
}
