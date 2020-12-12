using System;
using System.Collections.Generic;
using UrlopyApiXaml.Models.Entities;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UrlopyApiXaml;
using UrlopyApiXaml.Models.EntitiesForView;
using UrlopyApiXaml.Helper;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace UrlopyApiXaml.ViewModels
{
    public class ZdarzeniaViewModel : WszystkieViewModel<ZdarzeniaView>
    {
        private BaseCommand _DodajZdarzenie;
        #region Constructor
        public ZdarzeniaViewModel() : base()
        {
            base.DisplayName = "Zdarzenia";
        }
        #endregion Constructor
        public ICommand DodajZdarzenie
        {
            get
            {
                if (_DodajZdarzenie == null)
                {
                    _DodajZdarzenie = new BaseCommand(() => Messenger.Default.Send("DodajZdarzenie"));
                }
                return _DodajZdarzenie;
            }
        }
        #region Helpers
        // metoda load pobierze z bazy wszystkie towary i przypisze je do listy
        public override void load()
        {
            //za pomoca obiektu reprezentujacego cala baze danych o nazwie fakturyentities pobieram
            //wszystkie rekordy z bazy danych i zamieniam je na observableCollection
            List = new ObservableCollection<ZdarzeniaView>
            (
                from zdarz in urlopyApiXaml.ZDA_Zdarzenia
                select new ZdarzeniaView
                {
                    ZDA_ZdaID = "Lp."+zdarz.ZDA_ZdaID,
                    ImieNazwisko = zdarz.PRA_Pracownicy.PRA_Imie + " " + zdarz.PRA_Pracownicy.PRA_Nazwisko,
                    ZDA_Nazwa = zdarz.ZDA_Nazwa
                }
            );
        }
        #endregion Helpers


    }
}