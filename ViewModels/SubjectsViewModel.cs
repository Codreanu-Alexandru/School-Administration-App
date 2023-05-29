using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    class SubjectsViewModel : BaseViewModel
    {
        public int Index { get; set; }
        public Account Account { get; set; }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        public void PopulateSubject()
        {
            var context = new SchoolEntities();
            Subjects = new ObservableCollection<Subject>();

            var subjectData = context.GetAllSubjects();

            if (Account.role_id == 4)
            {
                foreach (var subject in subjectData)
                {
                    Subjects.Add(new Subject()
                    {
                        subject_id = subject.subject_id,
                        subject_name = subject.subject_name,
                        class_id = subject.class_id,
                        teacher_id = subject.teacher_id,
                        has_midterm = subject.has_midterm
                    });
                }
            }
            else
            {
                var student = context.Students.FirstOrDefault(s => s.account_id == Account.account_id);

                foreach (var subject in subjectData)
                {
                    if (subject.class_id == student.class_id)
                    {
                        Subjects.Add(new Subject()
                        {
                            subject_id = subject.subject_id,
                            subject_name = subject.subject_name,
                            class_id = subject.class_id,
                            teacher_id = subject.teacher_id,
                            has_midterm = subject.has_midterm
                        });
                    }
                }
            }
        }

        public void DeleteSubject(Subject subject)
        {
            if(Account.role_id == 4)
            {
                var context = new SchoolEntities();

                var _subject = context.Subjects.Where(s => s.subject_id == subject.subject_id).FirstOrDefault();

                if(_subject != null)
                {
                    context.Subjects.Remove(_subject);
                    PopulateSubject();
                }
            }
        }

        public SubjectsViewModel(Account account)
        {
            Account = account;
            PopulateSubject();
        }
    }
}
