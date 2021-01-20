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
    public class FotorejestracjaViewModel : WszystkieViewModel<FotorejestracjaView>
    {
        private FotorejestracjaView _Wybrane;

        public FotorejestracjaView Wybrane
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
        public FotorejestracjaViewModel()
        {
            base.DisplayName = "Lista Fotorejestracji";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<FotorejestracjaView>(urlopyApiXaml.FOT_Fotorejestracja.Where(x => x.FOT_CzyAktywny == true).Select(
                x=>new FotorejestracjaView{
                    FOT_PraID=x.FOT_PraID,
                    FOT_DataWejscia=x.FOT_DataWejscia,
                    FOT_DataWyjscia=x.FOT_DataWyjscia,
                    FOT_FotID=x.FOT_FotID,
                    FOT_GodzinaWejscia=x.FOT_GodzinaWejscia,
                    FOT_GodzinaWyjscia=x.FOT_GodzinaWyjscia,
                    PracownikNazwa=x.PRA_Pracownicy.PRA_Imie+" "+x.PRA_Pracownicy.PRA_Nazwisko
                }));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.FOT_Fotorejestracja.FirstOrDefault(m => m.FOT_FotID == Wybrane.FOT_FotID));
        }
        public override void del()
        {
            FOT_Fotorejestracja www = urlopyApiXaml.FOT_Fotorejestracja.FirstOrDefault(m => m.FOT_FotID == Wybrane.FOT_FotID);
            www.FOT_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            //brak dzialania poniewaz fotorejestracja powinna byc wykonywana przez urzadzenie zczytujace
            //Messenger.Default.Send("DodajFotorejestracje");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Pracownik")
                List = new ObservableCollection<FotorejestracjaView>(List.OrderBy(item => item.PracownikNazwa));
            if (SortField == "DataWejscia")
                List = new ObservableCollection<FotorejestracjaView>(List.OrderBy(item => item.FOT_DataWejscia));
            if (SortField == "DataWyjscia")
                List = new ObservableCollection<FotorejestracjaView>(List.OrderBy(item => item.FOT_DataWyjscia));
        }
        public override void Find()
        {
            if (FindField == "Pracownik")
                List = new ObservableCollection<FotorejestracjaView>(List.Where(item => item.PracownikNazwa != null && item.PracownikNazwa.StartsWith(FindText)));
            if (FindField == "Dzien Wejscia")
                List = new ObservableCollection<FotorejestracjaView>(List.Where(item => item.FOT_DataWejscia != null && item.FOT_DataWejscia.Day== Convert.ToInt32(FindText)));
            if (FindField == "Dzien Wyjscia")
                List = new ObservableCollection<FotorejestracjaView>(List.Where(item => item.FOT_DataWyjscia != null && item.FOT_DataWyjscia.Day == Convert.ToInt32(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Pracownik", "Dzien Wejscia", "Dzien Wyjscia"};
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Pracownik", "DataWejscia", "DataWyjscia" };

        }
        #endregion Sort and Find
    }
}
