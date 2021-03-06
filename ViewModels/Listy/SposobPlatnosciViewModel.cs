﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.Listy
{
    public class SposobPlatnosciViewModel : WszystkieViewModel<SPP_SposobPlatnosci>
    {
        private SPP_SposobPlatnosci _Wybrane;

        public SPP_SposobPlatnosci Wybrane
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
        public SposobPlatnosciViewModel()
        {
            base.DisplayName = "Lista Sposobow Platnosci";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<SPP_SposobPlatnosci>(urlopyApiXaml.SPP_SposobPlatnosci.Where(x => x.SPP_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.SPP_SposobPlatnosci.FirstOrDefault(m => m.SPP_SppID == Wybrane.SPP_SppID));
        }
        public override void del()
        {
            SPP_SposobPlatnosci www = urlopyApiXaml.SPP_SposobPlatnosci.FirstOrDefault(m => m.SPP_SppID == Wybrane.SPP_SppID);
            www.SPP_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajSposobPlatnosci");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<SPP_SposobPlatnosci>(List.OrderBy(item => item.SPP_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<SPP_SposobPlatnosci>(List.OrderByDescending(item => item.SPP_Nazwa));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<SPP_SposobPlatnosci>(List.Where(item => item.SPP_Nazwa != null && item.SPP_Nazwa.StartsWith(FindText)));
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
