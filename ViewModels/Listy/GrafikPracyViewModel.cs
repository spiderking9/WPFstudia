using Caliburn.Micro;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using UrlopyApiXaml.Helper;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models;
using GalaSoft.MvvmLight.Messaging;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.Listy
{
    public class GrafikPracyViewModel: WszystkieViewModel<GrafikPracyView>
    {
        private GrafikPracyView _Wybrane;

        public GrafikPracyView Wybrane
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
        public GrafikPracyViewModel()
        {
            base.DisplayName = "Grafik Pracy";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<GrafikPracyView>(urlopyApiXaml.GRP_GrafikPracy.Where(x => x.GRP_CzyAktywny == true).Select(w=>new GrafikPracyView
            {
                GRP_GrpID=w.GRP_GrpID,
                GRP_Dzien=w.GRP_Dzien,
                GRP_PraID=w.GRP_PraID,
                GRP_Zmiana=w.GRP_Zmiana,
                PracownikNazwisko=w.PRA_Pracownicy.PRA_Imie+" "+w.PRA_Pracownicy.PRA_Nazwisko
            }));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.GRP_GrafikPracy.FirstOrDefault(m => m.GRP_GrpID == Wybrane.GRP_GrpID));
        }
        public override void del()
        {
            GRP_GrafikPracy www = urlopyApiXaml.GRP_GrafikPracy.FirstOrDefault(m => m.GRP_GrpID == Wybrane.GRP_GrpID);
            www.GRP_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajGrafikPracy");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Zmiana ASC")
                List = new ObservableCollection<GrafikPracyView>(List.OrderBy(item => item.GRP_Zmiana));
            if (SortField == "Zmiana DSC")
                List = new ObservableCollection<GrafikPracyView>(List.OrderByDescending(item => item.GRP_Zmiana));
            if (SortField == "Pracownik ASC")
                List = new ObservableCollection<GrafikPracyView>(List.OrderBy(item => item.PracownikNazwisko));
            if (SortField == "Pracownik DSC")
                List = new ObservableCollection<GrafikPracyView>(List.OrderByDescending(item => item.PracownikNazwisko));

        }
        public override void Find()
        {
            if (FindField == "Zmiana" && FindText != null)
                List = new ObservableCollection<GrafikPracyView>(List.Where(item => item.GRP_Zmiana != null && item.GRP_Zmiana.ToLower().Contains(FindText.ToLower())));
            if (FindField == "Pracownik" && FindText != null)
                List = new ObservableCollection<GrafikPracyView>(List.Where(item => item.PracownikNazwisko != null && item.PracownikNazwisko.ToLower().Contains(FindText.ToLower())));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Zmiana", "Pracownik" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Zmiana ASC", "Zmiana DSC", "Pracownik ASC", "Pracownik DSC" };

        }
        #endregion Sort and Find
    }
}