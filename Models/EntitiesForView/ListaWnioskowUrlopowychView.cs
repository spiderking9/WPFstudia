using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlopyApiXaml.Models.EntitiesForView
{
    public class ListaWnioskowUrlopowychView
    {
        public int WUR_WurID { get; set; }
        public DateTime WUR_DataOd { get; set; }
        public DateTime WUR_DataDo { get; set; }
        public string RodzajUrlopu { get; set; }
        public string NazwaPracownika { get; set; }

    }
}
