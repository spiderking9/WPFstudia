using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlopyApiXaml.Models.EntitiesForView
{
    public class GrafikPracyView
    {
        public int GRP_GrpID { get; set; }
        public int GRP_PraID { get; set; }
        public string PracownikNazwisko { get; set; }
        public DateTime? GRP_Dzien { get; set; }
        public string GRP_Zmiana { get; set; }
    }
}
