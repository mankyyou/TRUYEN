//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace helloworld.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LUUTRU
    {
        public int Maluu { get; set; }
        public Nullable<int> Matruyen { get; set; }
        public Nullable<int> Mand { get; set; }
    
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
        public virtual TRUYEN TRUYEN { get; set; }
    }
}