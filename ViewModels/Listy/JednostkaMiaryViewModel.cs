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
    public class JednostkaMiaryViewModel : WszystkieViewModel<JEM_JednostkiMiary>
    {
        private JEM_JednostkiMiary _Wybrane;

        public JEM_JednostkiMiary Wybrane
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
        public JednostkaMiaryViewModel()
        {
            base.DisplayName = "Lista Jednostek Miary";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<JEM_JednostkiMiary>(urlopyApiXaml.JEM_JednostkiMiary.Where(x => x.JEM_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.JEM_JednostkiMiary.FirstOrDefault(m => m.JEM_JemID == Wybrane.JEM_JemID));
        }
        public override void del()
        {
            JEM_JednostkiMiary www = urlopyApiXaml.JEM_JednostkiMiary.FirstOrDefault(m => m.JEM_JemID == Wybrane.JEM_JemID);
            www.JEM_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajJednostkeMiary");
        }
        #endregion Helpers
        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa ASC")
                List = new ObservableCollection<JEM_JednostkiMiary>(List.OrderBy(item => item.JEM_Nazwa));
            if (SortField == "Nazwa DSC")
                List = new ObservableCollection<JEM_JednostkiMiary>(List.OrderByDescending(item => item.JEM_Nazwa));
            if (SortField == "Opis ASC")
                List = new ObservableCollection<JEM_JednostkiMiary>(List.OrderBy(item => item.JEM_Opis));
            if (SortField == "Opis DSC")
                List = new ObservableCollection<JEM_JednostkiMiary>(List.OrderByDescending(item => item.JEM_Opis));
        }
        public override void Find()
        {
            if (FindField == "Nazwa" && FindText != null)
                List = new ObservableCollection<JEM_JednostkiMiary>(List.Where(item => item.JEM_Nazwa != null && item.JEM_Nazwa.StartsWith(FindText)));
            if (FindField == "Opis" && FindText != null)
                List = new ObservableCollection<JEM_JednostkiMiary>(List.Where(item => item.JEM_Opis != null && item.JEM_Opis.StartsWith(FindText)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa ASC", "Nazwa DSC", "Opis ASC", "Opis DSC" };

        }
        #endregion Sort and Find
    }
}