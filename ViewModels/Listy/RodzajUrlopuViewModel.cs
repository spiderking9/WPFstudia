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
    public class RodzajUrlopuViewModel : WszystkieViewModel<RUR_RodzajeUrlopow>
    {
        private RUR_RodzajeUrlopow _Wybrane;

        public RUR_RodzajeUrlopow Wybrane
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
        public RodzajUrlopuViewModel()
        {
            base.DisplayName = "Lista Rodzajów Urlopów";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<RUR_RodzajeUrlopow>(urlopyApiXaml.RUR_RodzajeUrlopow.Where(x => x.RUR_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.RUR_RodzajeUrlopow.FirstOrDefault(m => m.RUR_RurID == Wybrane.RUR_RurID));
        }
        public override void del()
        {
            RUR_RodzajeUrlopow www = urlopyApiXaml.RUR_RodzajeUrlopow.FirstOrDefault(m => m.RUR_RurID == Wybrane.RUR_RurID);
            www.RUR_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajRodzajUrlopu");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<RUR_RodzajeUrlopow>(List.OrderBy(item => item.RUR_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<RUR_RodzajeUrlopow>(List.OrderByDescending(item => item.RUR_Nazwa));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<RUR_RodzajeUrlopow>(List.Where(item => item.RUR_Nazwa != null && item.RUR_Nazwa.StartsWith(FindText)));
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