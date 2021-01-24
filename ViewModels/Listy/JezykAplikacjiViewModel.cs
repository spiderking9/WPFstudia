using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.Listy
{
    public class JezykAplikacjiViewModel : WszystkieViewModel<JAP_JezykAplikacji>
    {
        private JAP_JezykAplikacji _Wybrane;

        public JAP_JezykAplikacji Wybrane
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
        public JezykAplikacjiViewModel()
        {
            base.DisplayName = "Lista Jezyk Aplikacji";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<JAP_JezykAplikacji>(urlopyApiXaml.JAP_JezykAplikacji.Where(x => x.JAP_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.JAP_JezykAplikacji.FirstOrDefault(m => m.JAP_JapID == Wybrane.JAP_JapID));
        }
        public override void del()
        {
            JAP_JezykAplikacji www = urlopyApiXaml.JAP_JezykAplikacji.FirstOrDefault(m => m.JAP_JapID == Wybrane.JAP_JapID);
            www.JAP_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajJezykApp");
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<JAP_JezykAplikacji>(List.OrderBy(item => item.JAP_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<JAP_JezykAplikacji>(List.OrderByDescending(item => item.JAP_Nazwa));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<JAP_JezykAplikacji>(List.Where(item => item.JAP_Nazwa != null && item.JAP_Nazwa.StartsWith(FindText)));
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