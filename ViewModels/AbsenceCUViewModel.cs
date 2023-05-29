using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    class AbsenceCUViewModel : BaseViewModel
    {
        private SchoolEntities context { get; set; }

        public int StudentIndex { get; set; }
        public int SubjectIndex { get; set; }

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> _Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(_Students));
            }
        }

        private ObservableCollection<Subject> _subjects;
        public ObservableCollection<Subject> _Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;
                OnPropertyChanged(nameof(_Subjects));
            }
        }

        private ObservableCollection<String> students;
        public ObservableCollection<String> Students
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

        private ObservableCollection<String> subjects;
        public ObservableCollection<String> Subjects
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

        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private bool excused;
        public bool Excused
        {
            get
            {
                return excused;
            }
            set
            {
                excused = value;
                OnPropertyChanged(nameof(Excused));
            }
        }

        public Absence Absence { get; set; }

        public AbsenceCUViewModel()
        {
            context = new SchoolEntities();
            _Students = new ObservableCollection<Student>(context.Students.ToList());
            _Subjects = new ObservableCollection<Subject>(context.Subjects.ToList());

            Students = new ObservableCollection<string>(context.Students.Select(s => s.first_name + s.last_name));
            Subjects = new ObservableCollection<string>(context.Subjects.Select(s => s.subject_name));
        }

        public AbsenceCUViewModel(Absence absence)
        {
            Absence = absence;
            context = new SchoolEntities();
            _Students = new ObservableCollection<Student>(context.Students.ToList());
            _Subjects = new ObservableCollection<Subject>(context.Subjects.ToList());

            Students = new ObservableCollection<string>(context.Students.Select(s => s.first_name + s.last_name));
            Subjects = new ObservableCollection<string>(context.Subjects.Select(s => s.subject_name));

            Date = absence.date;
            Excused = absence.excused;
        }

        public bool Confirm()
        {
            if(Absence == null)
            {
                if (Date != null) 
                {
                    context.Absences.Add(new Absence()
                    {
                        student_id = _Students[StudentIndex].student_id,
                        subject_id = _Subjects[SubjectIndex].subject_id,
                        date = Date,
                        excused = Excused,
                        Student = _Students[StudentIndex],
                        Subject = _Subjects[SubjectIndex]
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
                if (Date != null)
                {
                    var result = context.Absences.FirstOrDefault(
                        a => a.student_id == Absence.student_id &&
                        a.subject_id == Absence.subject_id &&
                        a.date == Absence.date
                        );

                    context.Absences.Remove( result );

                    context.SaveChanges();
                    context.Absences.Add(new Absence()
                    {
                        student_id = _Students[StudentIndex].student_id,
                        subject_id = _Subjects[SubjectIndex].subject_id,
                        date = Date,
                        excused = Excused
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
