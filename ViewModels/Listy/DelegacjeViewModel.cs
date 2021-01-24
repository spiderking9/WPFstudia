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
    public class DelegacjeViewModel : WszystkieViewModel<DelegacjaView>
    {
        private DelegacjaView _Wybrane;

        public DelegacjaView Wybrane
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
        public DelegacjeViewModel()
        {
            base.DisplayName = "Lista Delegacji";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<DelegacjaView>(urlopyApiXaml.DEL_Delegacje.Where(x => x.DEL_CzyAktywny == true).Select(ww => new DelegacjaView
            {
                DEL_DelID=ww.DEL_DelID,
                DEL_DzienDo = ww.DEL_DzienDo,
                DEL_DzienOd = ww.DEL_DzienDo,
                DEL_JakiTransport = ww.DEL_JakiTransport,
                DEL_Komentarz = ww.DEL_Komentarz,
                DEL_MiejscowoscCelu = ww.DEL_MiejscowoscCelu,
                DEL_MiejscowoscStartu = ww.DEL_MiejscowoscStartu,
                DEL_PraID = ww.DEL_PraID,
                DEL_Tytul = ww.DEL_Tytul,
                PracownikNazwisko = ww.PRA_Pracownicy.PRA_Imie + " " + ww.PRA_Pracownicy.PRA_Nazwisko
            }));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.DEL_Delegacje.FirstOrDefault(m => m.DEL_DelID == Wybrane.DEL_DelID));
        }
        public override void del()
        {
            DEL_Delegacje www = urlopyApiXaml.DEL_Delegacje.FirstOrDefault(m => m.DEL_DelID == Wybrane.DEL_DelID);
            www.DEL_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajDelegacje");
        }

        #endregion Helpers

        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Pracownik")
                List = new ObservableCollection<DelegacjaView>(List.OrderBy(item => item.PracownikNazwisko));
            if (SortField == "Tytul")
                List = new ObservableCollection<DelegacjaView>(List.OrderBy(item => item.DEL_Tytul));
            if (SortField == "Miejscowosc Startu")
                List = new ObservableCollection<DelegacjaView>(List.OrderBy(item => item.DEL_MiejscowoscStartu));
        }
        public override void Find()
        {
            if (FindField == "Tytul")
                List = new ObservableCollection<DelegacjaView>(List.Where(item => item.DEL_Tytul != null && item.DEL_Tytul.StartsWith(FindText)));
            if (FindField == "Miejscowosc")
                List = new ObservableCollection<DelegacjaView>(List.Where(item => item.DEL_MiejscowoscCelu != null && item.DEL_MiejscowoscCelu.StartsWith(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytul", "Miejscowosc" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Pracownik", "Tytul", "Miejscowosc Startu" };

        }
        #endregion Sort and Find
    }
}
