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
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<TowarView>(List.OrderBy(item => item.TOW_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<TowarView>(List.OrderByDescending(item => item.TOW_Nazwa));
            if (SortField == "Kategoria ASC")
                List = new ObservableCollection<TowarView>(List.OrderBy(item => item.TOW_KatNazwa));
            if (SortField == "Kategoria DSC")
                List = new ObservableCollection<TowarView>(List.OrderByDescending(item => item.TOW_KatNazwa));
            if (SortField == "Stan Ilosciowy ASC")
                List = new ObservableCollection<TowarView>(List.OrderBy(item => item.TOW_StanIlosciowy));
            if (SortField == "Stan Ilosciowy DSC")
                List = new ObservableCollection<TowarView>(List.OrderByDescending(item => item.TOW_StanIlosciowy));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<TowarView>(List.Where(item => item.TOW_Nazwa != null && item.TOW_Nazwa.StartsWith(FindText)));
            if (FindField == "Opis" && FindText != null)
                List = new ObservableCollection<TowarView>(List.Where(item => item.TOW_Opis != null && item.TOW_Opis.StartsWith(FindText)));
            if (FindField == "Stan Ilosciowy")
                List = new ObservableCollection<TowarView>(List.Where(item => item.TOW_StanIlosciowy != null && item.TOW_StanIlosciowy == Convert.ToInt32(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis", "Stan Ilosciowy" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa ASC", "Nazwa DSC", "Kategoria ASC", "Kategoria DSC", "Stan Ilosciowy ASC", "Stan Ilosciowy DSC" };

        }
        #endregion Sort and Find
    }
}
