using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlopyApiXaml.Models.EntitiesForView
{
    public class PracownicyView
    {
        public int PRA_PraID { get; set; }
        public string PRA_Imie { get; set; }
        public string PRA_Nazwisko { get; set; }
        public string ImieNazwisko { get; set; }
        public int PRA_DziID { get; set; }
        public string NazwaDzialu { get; set; }
        public string PRA_ILogin { get; set; }
        public byte[] PRA_Haslo { get; set; }
        public string PRA_UrlZdjecia { get; set; }
        public int PRA_StcID { get; set; }
        public string StrefaCzasowa { get; set; }
        public string PRA_Email { get; set; }
        public string PRA_Telefon { get; set; }
        public string PRA_Ulica { get; set; }
        public string PRA_Miasto { get; set; }
        public string PRA_KodPocztowy { get; set; }
        public bool? PRA_CzyZatrudniony { get; set; }
        public int PRA_JapID { get; set; }
        public string JezykAplikacji { get; set; }
        public bool? PRA_ZgodaMarketingowa { get; set; }
        public string PRA_Wojewodztwo { get; set; }
        public string PRA_NrDomu { get; set; }
        public string PRA_Gmina { get; set; }

    }
}
