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
    
    public partial class Resource
    {
        public long resource_id { get; set; }
        public long subject_id { get; set; }
        public string resource_name { get; set; }
    
        public virtual Subject Subject { get; set; }
    }
}