using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    internal class GradeCUViewModel : BaseViewModel
    {
        public int SubjectIndex { get; set; }
        public int StudentIndex { get; set; }

        SchoolEntities context { get; set; }
        public Grade Grade { get; set; }

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

        private short score;
        public short Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        private bool midterm;
        public bool Midterm
        {
            get
            {
                return midterm;
            }
            set
            {
                midterm = value;
                OnPropertyChanged(nameof(Midterm));
            }
        }

        public GradeCUViewModel()
        {
            context = new SchoolEntities();
            _Students = new ObservableCollection<Student>(context.Students);
            _Subjects = new ObservableCollection<Subject>(context.Subjects);
            Students = new ObservableCollection<string>(context.Students.Select(s => s.first_name + " " + s.last_name));
            Subjects = new ObservableCollection<string>(context.Subjects.Select(s => s.subject_name));
        }

        public GradeCUViewModel(Grade _grade)
        {
            Grade = _grade;
            context = new SchoolEntities();
            _Students = new ObservableCollection<Student>(context.Students);
            _Subjects = new ObservableCollection<Subject>(context.Subjects);
            Students = new ObservableCollection<string>(context.Students.Select(s => s.first_name + " " + s.last_name));
            Subjects = new ObservableCollection<string>(context.Subjects.Select(s => s.subject_name));

            Midterm = Grade.midterm;
            Score = Grade.score;
        }

        public bool Confirm()
        {
            if(Grade != null)
            {
                if (Score >= 0 && Score <= 10) 
                {
                    var result = context.Grades.FirstOrDefault(
                        x => x.subject_id == Grade.subject_id &&
                        x.student_id == Grade.student_id &&
                        x.score == Grade.score &&
                        x.midterm == Grade.midterm);

                    result.Subject = _Subjects[SubjectIndex];
                    result.Student = _Students[StudentIndex];
                    result.midterm = Midterm;
                    result.score = Score;

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
                if (Score >= 0 && Score <= 10)
                {
                    context.Grades.Add(new Grade()
                    {
                        subject_id = _Subjects[SubjectIndex].subject_id,
                        student_id = _Students[StudentIndex].student_id,
                        score = Score,
                        midterm = Midterm,
                        Student = _Students[StudentIndex],
                        Subject = _Subjects[SubjectIndex],
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
