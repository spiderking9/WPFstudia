using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using UrlopyApiXaml;
using UrlopyApiXaml.Helper;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels
{
    public class NowaFakturaViewModel : WszystkieViewModel<FAK_Faktury>
    {
        #region Fields
        protected DZI_Dzialy item;
        //komenda do zapisu towaru
        private BaseCommand _SaveCommand;
        #endregion Fields
        #region Constructors
        public NowaFakturaViewModel()
        {
            urlopyApiXaml = new UrlopyEntities();
            item = new DZI_Dzialy();
            base.DisplayName = "Faktura";
        }
        #endregion
        private ObservableCollection<KLI_Klienci> _ListaKlientow;
        public ObservableCollection<KLI_Klienci> ListaKlientow
        {
            get
            {
                if (_ListaKlientow == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _ListaKlientow;
            }
            set
            {
                _ListaKlientow = value; OnPropertyChanged(() => ListaKlientow);
            }
        }

        

        private ObservableCollection<JEM_JednostkiMiary> _ListaJednostekMiar;
        public ObservableCollection<JEM_JednostkiMiary> ListaJednostekMiar
        {
            get
            {
                if (_ListaJednostekMiar == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _ListaJednostekMiar;
            }
            set
            {
                _ListaJednostekMiar = value; OnPropertyChanged(() => ListaJednostekMiar);
            }
        }
        private ObservableCollection<DZI_Dzialy> _ListaDzialy;
        public ObservableCollection<DZI_Dzialy> ListaDzialy
        {
            get
            {
                if (_ListaDzialy == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _ListaDzialy;
            }
            set
            {
                _ListaDzialy = value; OnPropertyChanged(() => ListaDzialy);
            }
        }

        private ObservableCollection<KAT_KategorieTowarow> _ListaKategorie;
        public ObservableCollection<KAT_KategorieTowarow> ListaKategorie
        {
            get
            {
                if (_ListaKategorie == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _ListaKategorie;
            }
            set
            {
                _ListaKategorie = value; OnPropertyChanged(() => ListaKategorie);
            }
        }

        private ObservableCollection<URL_Urlopy> _ListaUrlopy;
        public ObservableCollection<URL_Urlopy> ListaUrlopy
        {
            get
            {
                if (_ListaUrlopy == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _ListaUrlopy;
            }
            set
            {
                _ListaUrlopy = value; OnPropertyChanged(() => ListaUrlopy);
            }
        }
        private ObservableCollection<PRA_Pracownicy> _ListaPracownicy;
        public ObservableCollection<PRA_Pracownicy> ListaPracownicy
        {
            get
            {
                if (_ListaPracownicy == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _ListaPracownicy;
            }
            set
            {
                _ListaPracownicy = value; OnPropertyChanged(() => ListaPracownicy);
            }
        }

        private ObservableCollection<TOW_Towary> _ListaTowarow;
        public ObservableCollection<TOW_Towary> ListaTowarow
        {
            get
            {
                if (_ListaTowarow == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _ListaTowarow;
            }
            set
            {
                _ListaTowarow = value; OnPropertyChanged(() => ListaTowarow);
            }
        }
        #region Helpers
        // metoda load pobierze z bazy wszystkie towary i przypisze je do listy
        public override void load()
        {
            //za pomoca obiektu reprezentujacego cala baze danych o nazwie fakturyentities pobieram
            //wszystkie rekordy z bazy danych i zamieniam je na observableCollection
            List = new ObservableCollection<FAK_Faktury>(urlopyApiXaml.FAK_Faktury);//
            ListaKlientow= new ObservableCollection<KLI_Klienci>(urlopyApiXaml.KLI_Klienci);//
            ListaKategorie = new ObservableCollection<KAT_KategorieTowarow>(urlopyApiXaml.KAT_KategorieTowarow);//
            ListaJednostekMiar = new ObservableCollection<JEM_JednostkiMiary>(urlopyApiXaml.JEM_JednostkiMiary);//
            ListaDzialy = new ObservableCollection<DZI_Dzialy>(urlopyApiXaml.DZI_Dzialy);//
            ListaUrlopy = new ObservableCollection<URL_Urlopy>(urlopyApiXaml.URL_Urlopy);
            ListaPracownicy= new ObservableCollection<PRA_Pracownicy>(urlopyApiXaml.PRA_Pracownicy);//
            ListaTowarow = new ObservableCollection<TOW_Towary>(urlopyApiXaml.TOW_Towary); //
        }
        #endregion Helpers





        #region Command

        //to jest komenda ktora zostanie podpieta pod przycisk Zapisz i wywola metode SaveAndClose 
        //ktora bedzie zdefiniowana nizej 
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                }
                return _SaveCommand;
            }
        }
        #endregion Command

        public string DZI_Nazwa
        {
            get
            {
                return item.DZI_Nazwa;
            }
            set
            {
                if (item.DZI_Nazwa != value)
                {
                    item.DZI_Nazwa = value;
                    base.OnPropertyChanged(() => DZI_Nazwa);
                }
            }
        }

        #region Helpers
        private void SaveAndClose()
        {
            urlopyApiXaml.DZI_Dzialy.Add(item);
            urlopyApiXaml.SaveChanges();
            OnRequestClose();
        }
        #endregion Helpers
    }
}
