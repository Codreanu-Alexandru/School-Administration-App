using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    class GradesViewModel : BaseViewModel
    {
        public int Index { get; set; }
        public Account Account { get; set; }

        private ObservableCollection<Grade> grades;
        public ObservableCollection<Grade> Grades
        {
            get
            {
                return grades;
            }
            set 
            {
                grades = value;
                OnPropertyChanged(nameof(Grades));
            }
        }

        public void DeleteGrade(Grade grade)
        {
            if(Account.role_id != 1)
            {
                var context = new SchoolEntities();

                if (context.Grades
                    .Where(
                    g => g.subject_id == grade.subject_id &&
                    g.student_id == grade.student_id &&
                    g.score == grade.score).Count() != 0) 
                {
                    context.Grades.Remove(grade);
                    PopulateGrades();
                }
            }
        }

        public void PopulateGrades()
        {
            var context = new SchoolEntities();
            Grades = new ObservableCollection<Grade>();

            var gradesData = context.GetAllGrades();

            if(Account.role_id == 4)
            {
                foreach (var grade in gradesData)
                {
                    Grades.Add(new Grade()
                    {
                        student_id = grade.student_id,
                        subject_id = grade.subject_id,
                        score = grade.score,
                        midterm = grade.midterm
                    });
                }
            }
            else if(Account.role_id == 1)
            {
                var student = context.Students.FirstOrDefault(s => s.account_id == Account.account_id);
                foreach (var grade in gradesData)
                {
                    if(grade.student_id == student.student_id)
                    {
                        Grades.Add(new Grade()
                        {
                            student_id = grade.student_id,
                            subject_id = grade.subject_id,
                            score = grade.score,
                            midterm = grade.midterm
                        });
                    }
                }
            }
            else
            {
                var teacher = context.Teachers.FirstOrDefault(t => t.account_id == Account.account_id);
                var subjects = context.Subjects.Where(s => s.teacher_id == teacher.teacher_id).Select(s => s.subject_id);
                foreach (var grade in gradesData)
                {
                    if(subjects.Contains( grade.subject_id))
                    {
                        Grades.Add(new Grade()
                        {
                            student_id = grade.student_id,
                            subject_id = grade.subject_id,
                            score = grade.score,
                            midterm = grade.midterm
                        });
                    }
                }
            }
        }

        public GradesViewModel(Account account)
        {
            Account = account;
            PopulateGrades();
        }
    }
}
