using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    internal class SubjectCUViewModel :BaseViewModel
    {
        SchoolEntities context { get; set; }

        public int IndexClass { get; set; }
        public int IndexTeacher { get; set; }

        public Subject Subject { get; set; }

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

        private ObservableCollection<Teacher> _teachers;
        public ObservableCollection<Teacher> _Teachers
        {
            get
            {
                return _teachers;
            }
            set
            {
                _teachers = value;
                OnPropertyChanged(nameof(_Teachers));
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

        private ObservableCollection<String> teachers;
        public ObservableCollection<String> Teachers
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

        private String name;
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
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

        public SubjectCUViewModel()
        {
            context = new SchoolEntities();
            _Classes = new ObservableCollection<Class>(context.Classes);
            _Teachers = new ObservableCollection<Teacher>(context.Teachers);

            Classes = new ObservableCollection<string>(context.Classes.Select(c => c.year + " " + c.division + " " + c.specialization));
            Teachers = new ObservableCollection<string>(context.Teachers.Select(t => t.first_name + " " + t.last_name));
        }

        public SubjectCUViewModel(Subject subject)
        {
            context = new SchoolEntities();
            var _subject = context.Subjects.FirstOrDefault(x => x.subject_id == subject.subject_id);
            Subject = _subject;
            _Classes = new ObservableCollection<Class>(context.Classes);
            _Teachers = new ObservableCollection<Teacher>(context.Teachers);

            Classes = new ObservableCollection<string>(context.Classes.Select(c => c.year + " " + c.division + " " + c.specialization));
            Teachers = new ObservableCollection<string>(context.Teachers.Select(t => t.first_name + " " + t.last_name));

            Name = Subject.subject_name;
            Midterm = Subject.has_midterm;
        }

        public bool Confirm()
        {
            if (Subject != null)
            {
                if (Name != null) 
                {
                    var result = context.Subjects.FirstOrDefault(s => s.subject_id == Subject.subject_id);
                    result.has_midterm = Midterm;
                    result.Teacher = _Teachers[IndexTeacher];
                    result.teacher_id = _Teachers[IndexTeacher].teacher_id;
                    result.Class = _Classes[IndexClass];
                    result.class_id = _Classes[IndexClass].class_id;
                    result.subject_name = Name;

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
                if (Name != null)
                {
                    context.Subjects.Add(new Subject()
                    {
                        subject_name = Name,
                        Class = _Classes[IndexClass],
                        class_id = _Classes[IndexClass].class_id,
                        Teacher = _Teachers[IndexTeacher],
                        teacher_id = _Teachers[IndexTeacher].teacher_id,
                        has_midterm = Midterm
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
