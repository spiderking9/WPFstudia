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
    public class DzialViewModel : WszystkieViewModel<DZI_Dzialy>
    {
        private DZI_Dzialy _Wybrane;

        public DZI_Dzialy Wybrane
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
        public DzialViewModel()
        {
            base.DisplayName = "Lista Dzialow";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<DZI_Dzialy>(urlopyApiXaml.DZI_Dzialy.Where(x => x.DZI_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.DZI_Dzialy.FirstOrDefault(m => m.DZI_DziID == Wybrane.DZI_DziID));
        }
        public override void del()
        {
            DZI_Dzialy www = urlopyApiXaml.DZI_Dzialy.FirstOrDefault(m => m.DZI_DziID == Wybrane.DZI_DziID);
            www.DZI_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajDzial");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<DZI_Dzialy>(List.OrderBy(item => item.DZI_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<DZI_Dzialy>(List.OrderByDescending(item => item.DZI_Nazwa));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<DZI_Dzialy>(List.Where(item => item.DZI_Nazwa != null && item.DZI_Nazwa.StartsWith(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa ASC", "Nazwa DSC" };

        }
        #endregion Sort and Find
    }
}
