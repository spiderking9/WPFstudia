using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UrlopyApiXaml.Helper;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //to jest pole odpowiedzialne za polaczenie z baza danych
        protected UrlopyEntities urlopyApiXaml;
        //to jest komenda ktora wywola ladowanie wszystkich towarow z bazy danych
        private BaseCommand _LoadCommand;
        //w tej kolekcji beda przechowywane wszystkie towary z bazy danych
        private ObservableCollection<T> _List;
        private BaseCommand _DodajCommand;
        private BaseCommand _DelCommand;
        private BaseCommand _EditCommand;
        #endregion Fields
        #region Properties
        //ta komenda wywoluje komende Load
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }

        public ICommand DelCommand
        {
            get
            {
                if (_DelCommand == null)
                {
                    _DelCommand = new BaseCommand(() => del());
                }
                return _DelCommand;
            }
        }
        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new BaseCommand(() => edit());
                }
                return _EditCommand;
            }
        }
        public ICommand DodajCommand
        {
            get
            {
                if (_DodajCommand == null)
                {
                    _DodajCommand = new BaseCommand(() => add());
                }
                return _DodajCommand;
            }
        }
        public string SortField { get; set; }
        //to jest lista stringow po ktorych moge sortowac, ktore wyswietlaja sie w rozwijanym comboboxie
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        //to jest komenda ktora zostanie podpieta pod przycisk sortuj i wywola ona metode Sort
        private BaseCommand _SortCommand;

        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }

        public string FindField { get; set; }
        //to jest poczatek wyszukiwanej frazy wpisywanej w textboxie
        public string FindText { get; set; }
        //to jest wlasciwosc ktora wypelnia liste wyboru w comboboxie
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _List;
            }
            set
            {
                _List = value; OnPropertyChanged(() => List);
            }
        }
        #endregion Properties
        #region Constructor
        public WszystkieViewModel()
        {
            urlopyApiXaml = new UrlopyEntities();

        }
        #endregion Constructor
        #region Helpers
        // metoda load pobierze z bazy wszystkie towary i przypisze je do listy
        public abstract void load();
        public virtual void add() { }
        public virtual void del() { }
        public virtual void edit() { }
        public virtual void Sort() { }
        public virtual List<string> GetComboboxSortList() { return new List<string>(); }
        public virtual void Find() { }
        public virtual List<string> GetComboboxFindList() { return new List<string>(); }
        #endregion Helpers

    }
}
