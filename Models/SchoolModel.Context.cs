﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tema_3_MVP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SchoolEntities : DbContext
    {
        public SchoolEntities()
            : base("name=SchoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Absence> Absences { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
    
        public virtual int CreateAbsence(Nullable<int> subject_id, Nullable<int> student_id, Nullable<System.DateTime> date, Nullable<bool> excused)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var excusedParameter = excused.HasValue ?
                new ObjectParameter("excused", excused) :
                new ObjectParameter("excused", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateAbsence", subject_idParameter, student_idParameter, dateParameter, excusedParameter);
        }
    
        public virtual int CreateClass(Nullable<int> head_teacher_id, Nullable<int> year, string division, string specialization)
        {
            var head_teacher_idParameter = head_teacher_id.HasValue ?
                new ObjectParameter("head_teacher_id", head_teacher_id) :
                new ObjectParameter("head_teacher_id", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var divisionParameter = division != null ?
                new ObjectParameter("division", division) :
                new ObjectParameter("division", typeof(string));
    
            var specializationParameter = specialization != null ?
                new ObjectParameter("specialization", specialization) :
                new ObjectParameter("specialization", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateClass", head_teacher_idParameter, yearParameter, divisionParameter, specializationParameter);
        }
    
        public virtual int CreateGrade(Nullable<int> subject_id, Nullable<int> student_id, Nullable<decimal> score, Nullable<bool> midterm)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("score", score) :
                new ObjectParameter("score", typeof(decimal));
    
            var midtermParameter = midterm.HasValue ?
                new ObjectParameter("midterm", midterm) :
                new ObjectParameter("midterm", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateGrade", subject_idParameter, student_idParameter, scoreParameter, midtermParameter);
        }
    
        public virtual int CreateStudent(string account_name, string account_password, string first_name, string last_name, Nullable<int> class_id)
        {
            var account_nameParameter = account_name != null ?
                new ObjectParameter("account_name", account_name) :
                new ObjectParameter("account_name", typeof(string));
    
            var account_passwordParameter = account_password != null ?
                new ObjectParameter("account_password", account_password) :
                new ObjectParameter("account_password", typeof(string));
    
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            var class_idParameter = class_id.HasValue ?
                new ObjectParameter("class_id", class_id) :
                new ObjectParameter("class_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateStudent", account_nameParameter, account_passwordParameter, first_nameParameter, last_nameParameter, class_idParameter);
        }
    
        public virtual int CreateSubject(Nullable<int> class_id, Nullable<int> teacher_id, string subject_name, Nullable<bool> has_midterm)
        {
            var class_idParameter = class_id.HasValue ?
                new ObjectParameter("class_id", class_id) :
                new ObjectParameter("class_id", typeof(int));
    
            var teacher_idParameter = teacher_id.HasValue ?
                new ObjectParameter("teacher_id", teacher_id) :
                new ObjectParameter("teacher_id", typeof(int));
    
            var subject_nameParameter = subject_name != null ?
                new ObjectParameter("subject_name", subject_name) :
                new ObjectParameter("subject_name", typeof(string));
    
            var has_midtermParameter = has_midterm.HasValue ?
                new ObjectParameter("has_midterm", has_midterm) :
                new ObjectParameter("has_midterm", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateSubject", class_idParameter, teacher_idParameter, subject_nameParameter, has_midtermParameter);
        }
    
        public virtual int CreateTeacher(string account_name, string account_password, string first_name, string last_name)
        {
            var account_nameParameter = account_name != null ?
                new ObjectParameter("account_name", account_name) :
                new ObjectParameter("account_name", typeof(string));
    
            var account_passwordParameter = account_password != null ?
                new ObjectParameter("account_password", account_password) :
                new ObjectParameter("account_password", typeof(string));
    
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateTeacher", account_nameParameter, account_passwordParameter, first_nameParameter, last_nameParameter);
        }
    
        public virtual int DeleteAbsence(Nullable<int> subject_id, Nullable<int> student_id, Nullable<System.DateTime> date)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteAbsence", subject_idParameter, student_idParameter, dateParameter);
        }
    
        public virtual int DeleteClass(Nullable<int> class_id)
        {
            var class_idParameter = class_id.HasValue ?
                new ObjectParameter("class_id", class_id) :
                new ObjectParameter("class_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteClass", class_idParameter);
        }
    
        public virtual int DeleteGrade(Nullable<int> subject_id, Nullable<int> student_id, Nullable<bool> midterm, Nullable<decimal> score)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            var midtermParameter = midterm.HasValue ?
                new ObjectParameter("midterm", midterm) :
                new ObjectParameter("midterm", typeof(bool));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("score", score) :
                new ObjectParameter("score", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteGrade", subject_idParameter, student_idParameter, midtermParameter, scoreParameter);
        }
    
        public virtual int DeleteStudent(Nullable<int> student_id)
        {
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStudent", student_idParameter);
        }
    
        public virtual int DeleteSubject(Nullable<int> subject_id)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteSubject", subject_idParameter);
        }
    
        public virtual int DeleteTeacher(Nullable<int> teacher_id)
        {
            var teacher_idParameter = teacher_id.HasValue ?
                new ObjectParameter("teacher_id", teacher_id) :
                new ObjectParameter("teacher_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteTeacher", teacher_idParameter);
        }
    
        public virtual ObjectResult<GetAllAbsences_Result> GetAllAbsences()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllAbsences_Result>("GetAllAbsences");
        }
    
        public virtual ObjectResult<GetAllClasses_Result> GetAllClasses()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllClasses_Result>("GetAllClasses");
        }
    
        public virtual ObjectResult<GetAllGrades_Result> GetAllGrades()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllGrades_Result>("GetAllGrades");
        }
    
        public virtual ObjectResult<GetAllStudentAbsences_Result> GetAllStudentAbsences(Nullable<int> student_id)
        {
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllStudentAbsences_Result>("GetAllStudentAbsences", student_idParameter);
        }
    
        public virtual ObjectResult<GetAllStudentGrades_Result> GetAllStudentGrades(Nullable<int> student_id)
        {
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllStudentGrades_Result>("GetAllStudentGrades", student_idParameter);
        }
    
        public virtual ObjectResult<GetAllStudents_Result> GetAllStudents()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllStudents_Result>("GetAllStudents");
        }
    
        public virtual ObjectResult<GetAllSubjectGrades_Result> GetAllSubjectGrades(Nullable<int> subject_id)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllSubjectGrades_Result>("GetAllSubjectGrades", subject_idParameter);
        }
    
        public virtual ObjectResult<GetAllSubjects_Result> GetAllSubjects()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllSubjects_Result>("GetAllSubjects");
        }
    
        public virtual ObjectResult<GetAllTeachers_Result> GetAllTeachers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllTeachers_Result>("GetAllTeachers");
        }
    
        public virtual ObjectResult<GetAllTeacherSubjects_Result> GetAllTeacherSubjects(Nullable<int> teacher_id)
        {
            var teacher_idParameter = teacher_id.HasValue ?
                new ObjectParameter("teacher_id", teacher_id) :
                new ObjectParameter("teacher_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllTeacherSubjects_Result>("GetAllTeacherSubjects", teacher_idParameter);
        }
    
        public virtual int UpdateAbsence(Nullable<int> subject_id, Nullable<int> student_id, Nullable<System.DateTime> date, Nullable<bool> excused, Nullable<System.DateTime> old_date)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var excusedParameter = excused.HasValue ?
                new ObjectParameter("excused", excused) :
                new ObjectParameter("excused", typeof(bool));
    
            var old_dateParameter = old_date.HasValue ?
                new ObjectParameter("old_date", old_date) :
                new ObjectParameter("old_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateAbsence", subject_idParameter, student_idParameter, dateParameter, excusedParameter, old_dateParameter);
        }
    
        public virtual int UpdateClass(Nullable<int> class_id, Nullable<int> head_teacher_id, Nullable<int> year, string division, string specialization)
        {
            var class_idParameter = class_id.HasValue ?
                new ObjectParameter("class_id", class_id) :
                new ObjectParameter("class_id", typeof(int));
    
            var head_teacher_idParameter = head_teacher_id.HasValue ?
                new ObjectParameter("head_teacher_id", head_teacher_id) :
                new ObjectParameter("head_teacher_id", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var divisionParameter = division != null ?
                new ObjectParameter("division", division) :
                new ObjectParameter("division", typeof(string));
    
            var specializationParameter = specialization != null ?
                new ObjectParameter("specialization", specialization) :
                new ObjectParameter("specialization", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateClass", class_idParameter, head_teacher_idParameter, yearParameter, divisionParameter, specializationParameter);
        }
    
        public virtual int UpdateGrade(Nullable<int> subject_id, Nullable<int> student_id, Nullable<decimal> score, Nullable<bool> midterm, Nullable<decimal> old_score)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("score", score) :
                new ObjectParameter("score", typeof(decimal));
    
            var midtermParameter = midterm.HasValue ?
                new ObjectParameter("midterm", midterm) :
                new ObjectParameter("midterm", typeof(bool));
    
            var old_scoreParameter = old_score.HasValue ?
                new ObjectParameter("old_score", old_score) :
                new ObjectParameter("old_score", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateGrade", subject_idParameter, student_idParameter, scoreParameter, midtermParameter, old_scoreParameter);
        }
    
        public virtual int UpdateStudent(Nullable<int> student_id, string account_name, string account_password, Nullable<int> role_id, string first_name, string last_name, Nullable<int> class_id)
        {
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            var account_nameParameter = account_name != null ?
                new ObjectParameter("account_name", account_name) :
                new ObjectParameter("account_name", typeof(string));
    
            var account_passwordParameter = account_password != null ?
                new ObjectParameter("account_password", account_password) :
                new ObjectParameter("account_password", typeof(string));
    
            var role_idParameter = role_id.HasValue ?
                new ObjectParameter("role_id", role_id) :
                new ObjectParameter("role_id", typeof(int));
    
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            var class_idParameter = class_id.HasValue ?
                new ObjectParameter("class_id", class_id) :
                new ObjectParameter("class_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateStudent", student_idParameter, account_nameParameter, account_passwordParameter, role_idParameter, first_nameParameter, last_nameParameter, class_idParameter);
        }
    
        public virtual int UpdateSubject(Nullable<int> subject_id, Nullable<int> class_id, Nullable<int> teacher_id, string subject_name, Nullable<bool> has_midterm)
        {
            var subject_idParameter = subject_id.HasValue ?
                new ObjectParameter("subject_id", subject_id) :
                new ObjectParameter("subject_id", typeof(int));
    
            var class_idParameter = class_id.HasValue ?
                new ObjectParameter("class_id", class_id) :
                new ObjectParameter("class_id", typeof(int));
    
            var teacher_idParameter = teacher_id.HasValue ?
                new ObjectParameter("teacher_id", teacher_id) :
                new ObjectParameter("teacher_id", typeof(int));
    
            var subject_nameParameter = subject_name != null ?
                new ObjectParameter("subject_name", subject_name) :
                new ObjectParameter("subject_name", typeof(string));
    
            var has_midtermParameter = has_midterm.HasValue ?
                new ObjectParameter("has_midterm", has_midterm) :
                new ObjectParameter("has_midterm", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateSubject", subject_idParameter, class_idParameter, teacher_idParameter, subject_nameParameter, has_midtermParameter);
        }
    
        public virtual int UpdateTeacher(Nullable<int> teacher_id, string account_name, string account_password, Nullable<int> role_id, string first_name, string last_name)
        {
            var teacher_idParameter = teacher_id.HasValue ?
                new ObjectParameter("teacher_id", teacher_id) :
                new ObjectParameter("teacher_id", typeof(int));
    
            var account_nameParameter = account_name != null ?
                new ObjectParameter("account_name", account_name) :
                new ObjectParameter("account_name", typeof(string));
    
            var account_passwordParameter = account_password != null ?
                new ObjectParameter("account_password", account_password) :
                new ObjectParameter("account_password", typeof(string));
    
            var role_idParameter = role_id.HasValue ?
                new ObjectParameter("role_id", role_id) :
                new ObjectParameter("role_id", typeof(int));
    
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTeacher", teacher_idParameter, account_nameParameter, account_passwordParameter, role_idParameter, first_nameParameter, last_nameParameter);
        }
    }
}
