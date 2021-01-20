using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlopyApiXaml.Models.EntitiesForView
{
    public class FotorejestracjaView
    {
        public int FOT_FotID { get; set; }
        public TimeSpan FOT_GodzinaWejscia { get; set; }
        public TimeSpan FOT_GodzinaWyjscia { get; set; }
        public int FOT_PraID { get; set; }
        public string PracownikNazwa { get; set; }

        public DateTime FOT_DataWejscia { get; set; }
        public DateTime FOT_DataWyjscia { get; set; }
    }
}
