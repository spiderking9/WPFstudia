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
    
    public partial class WUR_WnioskiUrlopowe
    {
        public int WUR_WurID { get; set; }
        public System.DateTime WUR_DataOd { get; set; }
        public System.DateTime WUR_DataDo { get; set; }
        public int WUR_RurID { get; set; }
        public int WUR_PraID { get; set; }
        public Nullable<bool> WUR_CzyAktywny { get; set; }
    
        public virtual PRA_Pracownicy PRA_Pracownicy { get; set; }
        public virtual RUR_RodzajeUrlopow RUR_RodzajeUrlopow { get; set; }
    }
}
