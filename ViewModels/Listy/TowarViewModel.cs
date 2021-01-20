using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.Listy
{
    public class TowarViewModel : WszystkieViewModel<TowarView>
    {
        private TowarView _Wybrane;

        public TowarView Wybrane
        {
            get
            {
                return _Wybrane;
            }
            set
            {
                if (_Wybrane != value)
                {
                    _Wybrane = value;
                }
            }
        }
        #region Konstruktor
        public TowarViewModel()
        {
            base.DisplayName = "Lista Towarow";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<TowarView>(
                from towar in urlopyApiXaml.TOW_Towary
                where towar.TOW_CzyAktywny == true
                select new TowarView
                {
                    TOW_TowID = towar.TOW_TowID,
                    TOW_Nazwa = towar.TOW_Nazwa,
                    TOW_Kod = towar.TOW_Kod,
                    TOW_Opis = towar.TOW_Opis,
                    TOW_KatNazwa = towar.KAT_KategorieTowarow.KAT_Nazwa,
                    TOW_StanIlosciowy = towar.TOW_StanIlosciowy,
                    TOW_Zdjecie = towar.TOW_Zdjecie
                });
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.TOW_Towary.FirstOrDefault(m => m.TOW_TowID == Wybrane.TOW_TowID));
        }
        public override void del()
        {
            TOW_Towary www = urlopyApiXaml.TOW_Towary.FirstOrDefault(m => m.TOW_TowID == Wybrane.TOW_TowID);
            www.TOW_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajNowyTowar");
        }
        #endregion Helpers
    }
}
