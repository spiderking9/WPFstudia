using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.Models.BusinessLogic
{
    public class UrlopAlboZmianaPracy : DatebaseClass
    {
        public UrlopAlboZmianaPracy(UrlopyEntities urlopyApiXaml) :base(urlopyApiXaml)
        {

        }
        public ObservableCollection<Nowa> GetZmiana(DateTime Data, int PraID)
        {
            ObservableCollection<Nowa> List = new ObservableCollection<Nowa>();
            for (int i = 0; i < 15; i++)
            {
                var dataCell = Data.AddDays(i);
                int? idUrlopu = urlopyApiXaml.URL_Urlopy.Where(x =>
                           x.URL_PraID == PraID
                           && x.URL_DzienOd <= dataCell
                           && x.URL_DzienDo >= dataCell
                     ).Select(w => w.URL_RurID).FirstOrDefault();
                Nowa nowa = new Nowa();
                nowa.id = i;
                var zmiana = urlopyApiXaml.GRP_GrafikPracy.Where(
                    cc => cc.GRP_PraID == PraID &&
                    cc.GRP_Dzien.Value.Day == dataCell.Day &&
                    cc.GRP_Dzien.Value.Month == dataCell.Month &&
                    cc.GRP_Dzien.Value.Year == dataCell.Year
                    ).Select(w => w.GRP_Zmiana).FirstOrDefault() ?? "-";
                nowa.rodzajZmiany = idUrlopu != null ? urlopyApiXaml.RUR_RodzajeUrlopow.Where(x => x.RUR_RurID == idUrlopu).Select(c => c.RUR_Nazwa).FirstOrDefault() : zmiana;
                nowa.data = Data.AddDays(i).ToString("dd MMMM");

                List.Add(nowa);
            }

            return List;
        }
        public static string setDataString(DateTime Data, DateTime Data2)
        {

            return Data.ToString("dd MMMM yyy") + " - " + Data2.ToString("dd MMMM yyy");
        }
    }
    public class Nowa
    {
        public int id { get; set; }
        public string data { get; set; }
        public string rodzajZmiany { get; set; }
    }
}
