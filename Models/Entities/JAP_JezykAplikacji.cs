//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrlopyApiXaml.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class JAP_JezykAplikacji
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JAP_JezykAplikacji()
        {
            this.PRA_Pracownicy = new HashSet<PRA_Pracownicy>();
        }
    
        public int JAP_JapID { get; set; }
        public string JAP_Nazwa { get; set; }
        public bool JAP_CzyAktywny { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRA_Pracownicy> PRA_Pracownicy { get; set; }
    }
}