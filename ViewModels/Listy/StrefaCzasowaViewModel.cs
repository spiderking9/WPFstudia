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
    public class StrefaCzasowaViewModel : WszystkieViewModel<STC_StrefaCzasowa>
    {
        private STC_StrefaCzasowa _Wybrane;

        public STC_StrefaCzasowa Wybrane
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
        public StrefaCzasowaViewModel()
        {
            base.DisplayName = "Lista Stref Czasowych";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<STC_StrefaCzasowa>(urlopyApiXaml.STC_StrefaCzasowa.Where(x => x.STC_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.STC_StrefaCzasowa.FirstOrDefault(m => m.STC_StcID == Wybrane.STC_StcID));
        }
        public override void del()
        {
            STC_StrefaCzasowa www = urlopyApiXaml.STC_StrefaCzasowa.FirstOrDefault(m => m.STC_StcID == Wybrane.STC_StcID);
            www.STC_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajStrefeCzasowa");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<STC_StrefaCzasowa>(List.OrderBy(item => item.STC_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<STC_StrefaCzasowa>(List.OrderByDescending(item => item.STC_Nazwa));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText!=null)
                List = new ObservableCollection<STC_StrefaCzasowa>(List.Where(item => item.STC_Nazwa != null && item.STC_Nazwa.StartsWith(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa ASC", "Nazwa DSC"};

        }
        #endregion Sort and Find
    }
}