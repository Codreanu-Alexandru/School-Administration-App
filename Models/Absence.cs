//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Absence
    {
        public long subject_id { get; set; }
        public long student_id { get; set; }
        public System.DateTime date { get; set; }
        public bool excused { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
