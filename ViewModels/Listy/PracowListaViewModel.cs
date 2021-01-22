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
    public class PracowListaViewModel : WszystkieViewModel<PracownicyView>
    {
        private PracownicyView _Wybrane;

        public PracownicyView Wybrane
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
        public PracowListaViewModel()
        {
            base.DisplayName = "Lista Pracownikow";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<PracownicyView>(urlopyApiXaml.PRA_Pracownicy.Where(x => x.PRA_CzyAktywny == true).Select(w => new PracownicyView
            {
                ImieNazwisko = w.PRA_Imie + " " + w.PRA_Nazwisko,
                PRA_ILogin = w.PRA_ILogin,
                PRA_KodPocztowy = w.PRA_KodPocztowy,
                PRA_NrDomu = w.PRA_NrDomu,
                PRA_Telefon = w.PRA_Telefon,
                PRA_Miasto = w.PRA_Miasto,
                PRA_Ulica = w.PRA_Ulica,
                PRA_Gmina = w.PRA_Gmina,
                PRA_UrlZdjecia = w.PRA_UrlZdjecia,
                PRA_Wojewodztwo = w.PRA_Wojewodztwo,
                JezykAplikacji = w.JAP_JezykAplikacji.JAP_Nazwa,
                NazwaDzialu = w.DZI_Dzialy.DZI_Nazwa,
                PRA_CzyZatrudniony = w.PRA_CzyZatrudniony,
                PRA_Email = w.PRA_Email,
                PRA_PraID = w.PRA_PraID,
                PRA_ZgodaMarketingowa = w.PRA_ZgodaMarketingowa,
                StrefaCzasowa = w.STC_StrefaCzasowa.STC_Nazwa,
            }));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.PRA_Pracownicy.FirstOrDefault(m => m.PRA_PraID == Wybrane.PRA_PraID));
        }
        public override void del()
        {
            if (Wybrane != null && Wybrane.PRA_PraID != 0)
            {
                PRA_Pracownicy www = urlopyApiXaml.PRA_Pracownicy.FirstOrDefault(m => m.PRA_PraID == Wybrane.PRA_PraID);
                www.PRA_CzyAktywny = false;
                urlopyApiXaml.SaveChanges();
                load();
            }
        }
        public override void add()
        {
            Messenger.Default.Send("DodajPracownika");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwisko ASC")
                List = new ObservableCollection<PracownicyView>(List.OrderBy(item => item.ImieNazwisko));
            if (SortField == "Nazwisko DSC")
                List = new ObservableCollection<PracownicyView>(List.OrderByDescending(item => item.ImieNazwisko));
            if (SortField == "Dzial ASC")
                List = new ObservableCollection<PracownicyView>(List.OrderBy(item => item.NazwaDzialu));
            if (SortField == "Dzial DSC")
                List = new ObservableCollection<PracownicyView>(List.OrderByDescending(item => item.NazwaDzialu));
            if (SortField == "Miasto ASC")
                List = new ObservableCollection<PracownicyView>(List.OrderBy(item => item.PRA_Miasto));
            if (SortField == "Miasto ASC")
                List = new ObservableCollection<PracownicyView>(List.OrderByDescending(item => item.PRA_Miasto));
        }
        public override void Find()
        {
            if (FindField == "Nazwisko" && FindText != null)
                List = new ObservableCollection<PracownicyView>(List.Where(item => item.PRA_Nazwisko != null && item.PRA_Nazwisko.StartsWith(FindText)));
            if (FindField == "Dzial" && FindText != null)
                List = new ObservableCollection<PracownicyView>(List.Where(item => item.NazwaDzialu != null && item.NazwaDzialu.StartsWith(FindText)));
            if (FindField == "Miasto" && FindText != null)
                List = new ObservableCollection<PracownicyView>(List.Where(item => item.PRA_Miasto != null && item.PRA_Miasto.StartsWith(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwisko", "Dzial", "Miasto" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwisko ASC", "Nazwisko DSC", "Dzial ASC", "Dzial DSC", "Miasto ASC", "Miasto DSC" };

        }
        #endregion Sort and Find
    }
}