using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tema_3_MVP.Models;

namespace Tema_3_MVP.ViewModels
{
    class AbsencesViewModel : BaseViewModel
    {
        public int Index { get; set; }

        public Account Account { get; set; }

        private ObservableCollection<Absence> absences;
        public ObservableCollection<Absence> Absences 
        {
            get
            {
                return absences;
            }
            set
            {
                absences = value;
                OnPropertyChanged(nameof(Absences));
            }
        }

        public void PopulateAbsences()
        {
            var context = new SchoolEntities();
            Absences = new ObservableCollection<Absence>();

            var absenceData = context.GetAllAbsences();

            switch (Account.role_id)
            {
                case 1:
                    var student = context.Students.FirstOrDefault(s => s.account_id == Account.account_id);
                    foreach (var absence in absenceData)
                    {
                        if(student.student_id == absence.student_id)
                        {
                            Absences.Add(new Absence()
                            {
                                student_id = absence.student_id,
                                subject_id = absence.subject_id,
                                date = absence.date,
                                excused = absence.excused
                            });
                        }
                    }
                    break;

                case 2:
                    var t_teacher = context.Teachers.Where(t => t.account_id == Account.account_id).FirstOrDefault();
                    var t_subjectIds = context.Subjects
                        .Where(s => s.teacher_id == t_teacher.teacher_id)
                        .Select(s => s.subject_id)
                        .ToList();
                    foreach (var absence in absenceData)
                    {
                        if(t_subjectIds.Contains(absence.subject_id))
                        {
                            Absences.Add(new Absence()
                            {
                                student_id = absence.student_id,
                                subject_id = absence.subject_id,
                                date = absence.date,
                                excused = absence.excused
                            });
                        }
                    }
                    break;

                case 3:
                    var ht_teacher = context.Teachers.Where(t => t.account_id == Account.account_id).FirstOrDefault();
                    var ht_subjectIds = context.Subjects
                        .Where(s => s.teacher_id == ht_teacher.teacher_id)
                        .Select(s => s.subject_id)
                        .ToList();

                    foreach (var absence in absenceData)
                    {
                        if (ht_subjectIds.Contains(absence.subject_id))
                        {
                            Absences.Add(new Absence()
                            {
                                student_id = absence.student_id,
                                subject_id = absence.subject_id,
                                date = absence.date,
                                excused = absence.excused
                            });
                        }
                    }
                    break;

                case 4:
                    foreach (var absence in absenceData)
                    {
                        Absences.Add(new Absence()
                        {
                            student_id = absence.student_id,
                            subject_id = absence.subject_id,
                            date = absence.date,
                            excused = absence.excused
                        });
                    }
                    break;

                default:
                    break;
            }
        }

        public AbsencesViewModel(Account account)
        {
            Account = account;
            PopulateAbsences();
        }
    }
}
