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
    public class KlientViewModel : WszystkieViewModel<KLI_Klienci>
    {
        private KLI_Klienci _Wybrane;

        public KLI_Klienci Wybrane
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
        public KlientViewModel()
        {
            base.DisplayName = "Lista Klientow";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<KLI_Klienci>(urlopyApiXaml.KLI_Klienci.Where(x => x.KLI_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.KLI_Klienci.FirstOrDefault(m => m.KLI_KliID == Wybrane.KLI_KliID));
        }
        public override void del()
        {
            if (Wybrane!=null && Wybrane.KLI_KliID!=0)
            {
                KLI_Klienci www = urlopyApiXaml.KLI_Klienci.FirstOrDefault(m => m.KLI_KliID == Wybrane.KLI_KliID);
                www.KLI_CzyAktywny = false;
                urlopyApiXaml.SaveChanges();
                load();
            }
        }
        public override void add()
        {
            Messenger.Default.Send("DodajKlienta");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<KLI_Klienci>(List.OrderBy(item => item.KLI_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<KLI_Klienci>(List.OrderByDescending(item => item.KLI_Nazwa));
            if (SortField == "Adres ASC")
                List = new ObservableCollection<KLI_Klienci>(List.OrderBy(item => item.KLI_Adres));
            if (SortField == "Adres DSC")
                List = new ObservableCollection<KLI_Klienci>(List.OrderByDescending(item => item.KLI_Adres));
            if (SortField == "Telefon")
                List = new ObservableCollection<KLI_Klienci>(List.OrderByDescending(item => item.KLI_Telefon));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<KLI_Klienci>(List.Where(item => item.KLI_Nazwa != null && item.KLI_Nazwa.StartsWith(FindText)));
            if (FindField == "Adres" && FindText != null)
                List = new ObservableCollection<KLI_Klienci>(List.Where(item => item.KLI_Adres != null && item.KLI_Adres.StartsWith(FindText)));
            if (FindField == "Telefon" && FindText != null)
                List = new ObservableCollection<KLI_Klienci>(List.Where(item => item.KLI_Telefon != null && item.KLI_Telefon.StartsWith(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Adres", "Telefon" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa ASC", "Nazwa DSC", "Adres ASC", "Adres DSC", "Telefon" };

        }
        #endregion Sort and Find
    }
}