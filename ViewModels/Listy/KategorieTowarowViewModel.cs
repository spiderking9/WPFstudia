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
    public class KategorieTowarowViewModel : WszystkieViewModel<KAT_KategorieTowarow>
    {
        private KAT_KategorieTowarow _Wybrane;

        public KAT_KategorieTowarow Wybrane
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
        public KategorieTowarowViewModel()
        {
            base.DisplayName = "Lista Kategorii Towarow";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<KAT_KategorieTowarow>(urlopyApiXaml.KAT_KategorieTowarow.Where(x => x.KAT_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.KAT_KategorieTowarow.FirstOrDefault(m => m.KAT_KatID == Wybrane.KAT_KatID));
        }
        public override void del()
        {
            KAT_KategorieTowarow www = urlopyApiXaml.KAT_KategorieTowarow.FirstOrDefault(m => m.KAT_KatID == Wybrane.KAT_KatID);
            www.KAT_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajKatTowarow");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<KAT_KategorieTowarow>(List.OrderBy(item => item.KAT_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<KAT_KategorieTowarow>(List.OrderByDescending(item => item.KAT_Nazwa));
            if (SortField == "Opis ASC")
                List = new ObservableCollection<KAT_KategorieTowarow>(List.OrderBy(item => item.KAT_Opis));
            if (SortField == "Opis DSC")
                List = new ObservableCollection<KAT_KategorieTowarow>(List.OrderByDescending(item => item.KAT_Opis));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<KAT_KategorieTowarow>(List.Where(item => item.KAT_Nazwa != null && item.KAT_Nazwa.StartsWith(FindText)));
            if (FindField == "Opis" && FindText != null)
                List = new ObservableCollection<KAT_KategorieTowarow>(List.Where(item => item.KAT_Opis != null && item.KAT_Opis.StartsWith(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa ASC", "Nazwa DSC", "Opis ASC", "Opis DSC"};

        }
        #endregion Sort and Find
    }
}