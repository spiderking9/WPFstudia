using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlopyApiXaml.Models.EntitiesForView
{
    public class FakturyView
    {
        public int FAK_FakID { get; set; }
        public DateTime FAK_DataWystawienia { get; set; }
        public string NazwaKlienta { get; set; }
        public string SposobPlatnosci { get; set; }

    }
}
