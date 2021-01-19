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
        #endregion Helpers

    }
}
