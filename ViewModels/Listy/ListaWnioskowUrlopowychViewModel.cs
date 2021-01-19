using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.Listy
{
    public class ListaWnioskowUrlopowychViewModel : WszystkieViewModel<ListaWnioskowUrlopowychView>
    {
        #region Konstruktor
        public ListaWnioskowUrlopowychViewModel()
        {
            base.DisplayName = "Lista Wnioskow Urlopowych";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<ListaWnioskowUrlopowychView>(
                from listaWnioskow in urlopyApiXaml.WUR_WnioskiUrlopowe
                select new ListaWnioskowUrlopowychView
                {
                    WUR_WurID=listaWnioskow.WUR_WurID,
                    WUR_DataDo = listaWnioskow.WUR_DataOd,
                    WUR_DataOd = listaWnioskow.WUR_DataOd,
                    NazwaPracownika = listaWnioskow.PRA_Pracownicy.PRA_Imie+" " +listaWnioskow.PRA_Pracownicy.PRA_Nazwisko,
                    RodzajUrlopu = listaWnioskow.RUR_RodzajeUrlopow.RUR_Nazwa
                });
        }
        #endregion Helpers
    }
}