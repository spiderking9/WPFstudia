using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlopyApiXaml.Models.EntitiesForView
{
    public class DelegacjaView
    {
        public int DEL_DelID { get; set; }
        public int DEL_PraID { get; set; }
        public string PracownikNazwisko { get; set; }
        public string DEL_Tytul { get; set; }
        public string DEL_JakiTransport { get; set; }
        public string DEL_MiejscowoscStartu { get; set; }
        public string DEL_MiejscowoscCelu { get; set; }
        public DateTime DEL_DzienOd { get; set; }
        public DateTime DEL_DzienDo { get; set; }
        public string DEL_Komentarz { get; set; }

    }
}
