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
    
    public partial class SPP_SposobPlatnosci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPP_SposobPlatnosci()
        {
            this.FAK_Faktury = new HashSet<FAK_Faktury>();
        }
    
        public int SPP_SppID { get; set; }
        public string SPP_Nazwa { get; set; }
        public Nullable<bool> SPP_CzyAktywny { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAK_Faktury> FAK_Faktury { get; set; }
    }
}
