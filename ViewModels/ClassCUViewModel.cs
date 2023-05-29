using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    internal class ClassCUViewModel : BaseViewModel
    {
        SchoolEntities context { get; set; }
        public int Index { get; set; }
        public Class Class { get; set; }

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

        private String year;
        public String Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        private String division;
        public String Division
        {
            get
            {
                return division;
            }
            set
            {
                division = value;
                OnPropertyChanged(nameof(Division));
            }
        }

        private String specialization;
        public String Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                specialization = value;
                OnPropertyChanged(nameof(Specialization));
            }
        }

        public ClassCUViewModel()
        {
            context = new SchoolEntities();
            _Teachers = new ObservableCollection<Teacher>(context.Teachers);
            Teachers = new ObservableCollection<string>(context.Teachers.Select(t => t.first_name + " " + t.last_name));

        }

        public ClassCUViewModel(Class _class)
        {
            Class = _class;
            context = new SchoolEntities();
            _Teachers = new ObservableCollection<Teacher>(context.Teachers);
            Teachers = new ObservableCollection<string>(context.Teachers.Select(t => t.first_name + " " + t.last_name));
            Year = Class.year.ToString();
            Division = Class.division;
            Specialization = Class.specialization;
        }

        public bool Confirm()
        {
            if(Class != null) 
            {
                if (Year != null && Division != null && Specialization != null)
                {
                    var result = context.Classes.FirstOrDefault(c => c.class_id == Class.class_id);

                    result.head_teacher_id = _Teachers[Index].teacher_id;
                    result.year = Convert.ToInt16(Year);
                    result.division = Division;
                    result.specialization = Specialization;

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
                if (Year != null && Division != null && Specialization != null)
                {
                    context.Classes.Add(new Class()
                    {
                        head_teacher_id = _Teachers[Index].teacher_id,
                        year = Convert.ToInt16(Year),
                        division = Division,
                        specialization = Specialization
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
