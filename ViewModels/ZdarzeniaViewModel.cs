using System;
using System.Collections.Generic;
using UrlopyApiXaml.Models.Entities;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UrlopyApiXaml;
using UrlopyApiXaml.Models.EntitiesForView;
using UrlopyApiXaml.Helper;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace UrlopyApiXaml.ViewModels
{
    public class ZdarzeniaViewModel : WszystkieViewModel<ZdarzeniaView>
    {

        private ZdarzeniaView _WybraneZdarzenie;

        public ZdarzeniaView WybraneZdarzenie
        {
            get
            {
                return _WybraneZdarzenie;
            }
            set
            {
                if (_WybraneZdarzenie != value)
                {
                    _WybraneZdarzenie = value;
                }
            }
        }
        #region Constructor
        public ZdarzeniaViewModel() : base()
        {
            base.DisplayName = "Zdarzenia";
        }
        #endregion Constructor


        #region Helpers
        // metoda load pobierze z bazy wszystkie towary i przypisze je do listy
        public override void load()
        {
            //za pomoca obiektu reprezentujacego cala baze danych o nazwie fakturyentities pobieram
            //wszystkie rekordy z bazy danych i zamieniam je na observableCollection
            List = new ObservableCollection<ZdarzeniaView>
            (
                from zdarz in urlopyApiXaml.ZDA_Zdarzenia
                where zdarz.ZDA_CzyAktywny==true
                select new ZdarzeniaView
                {
                    ZDA_ZdaID = zdarz.ZDA_ZdaID,
                    ImieNazwisko = zdarz.PRA_Pracownicy.PRA_Imie + " " + zdarz.PRA_Pracownicy.PRA_Nazwisko,
                    ZDA_Nazwa = zdarz.ZDA_Nazwa
                }
            );
        }
        public override void edit()
        {
            if(WybraneZdarzenie!=null)
            Messenger.Default.Send(urlopyApiXaml.ZDA_Zdarzenia.FirstOrDefault(m => m.ZDA_ZdaID == WybraneZdarzenie.ZDA_ZdaID));
        }
        public override void del()
        {
            ZDA_Zdarzenia www = urlopyApiXaml.ZDA_Zdarzenia.FirstOrDefault(m => m.ZDA_ZdaID == WybraneZdarzenie.ZDA_ZdaID);
            www.ZDA_CzyAktywny=false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajZdarzenie");
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<ZdarzeniaView>(List.OrderBy(item => item.ZDA_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<ZdarzeniaView>(List.OrderByDescending(item => item.ZDA_Nazwa));
            if (SortField == "Pracownik ASC")
                List = new ObservableCollection<ZdarzeniaView>(List.OrderBy(item => item.ImieNazwisko));
            if (SortField == "Pracownik DSC")
                List = new ObservableCollection<ZdarzeniaView>(List.OrderByDescending(item => item.ImieNazwisko));

        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<ZdarzeniaView>(List.Where(item => item.ZDA_Nazwa != null && item.ZDA_Nazwa.ToLower().Contains(FindText.ToLower())));
            if (FindField == "Pracownik")
                List = new ObservableCollection<ZdarzeniaView>(List.Where(item => item.ImieNazwisko != null && item.ImieNazwisko.ToLower().Contains(FindText.ToLower())));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Pracownik"};
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa ASC", "Nazwa DSC", "Pracownik ASC", "Pracownik DSC"};

        }
        #endregion Sort and Find
    }
}