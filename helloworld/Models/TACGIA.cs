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
    
    public partial class TACGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TACGIA()
        {
            this.TRUYENs = new HashSet<TRUYEN>();
        }
    
        public int Matacgia { get; set; }
        public string Tentacgia { get; set; }
        public string Diachi { get; set; }
        public string Tieusu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRUYEN> TRUYENs { get; set; }
    }
}
