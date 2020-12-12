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
        #endregion Helpers

    }
}
