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
    public class ListaWnioskowUrlopowychViewModel : WszystkieViewModel<ListaWnioskowUrlopowychView>
    {
        private ListaWnioskowUrlopowychView _Wybrane;

        public ListaWnioskowUrlopowychView Wybrane
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
                where listaWnioskow.WUR_CzyAktywny==true
                select new ListaWnioskowUrlopowychView
                {
                    WUR_WurID=listaWnioskow.WUR_WurID,
                    WUR_DataDo = listaWnioskow.WUR_DataOd,
                    WUR_DataOd = listaWnioskow.WUR_DataOd,
                    NazwaPracownika = listaWnioskow.PRA_Pracownicy.PRA_Imie+" " +listaWnioskow.PRA_Pracownicy.PRA_Nazwisko,
                    RodzajUrlopu = listaWnioskow.RUR_RodzajeUrlopow.RUR_Nazwa
                });
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.WUR_WnioskiUrlopowe.FirstOrDefault(m => m.WUR_WurID == Wybrane.WUR_WurID));
        }
        public override void del()
        {
            WUR_WnioskiUrlopowe www = urlopyApiXaml.WUR_WnioskiUrlopowe.FirstOrDefault(m => m.WUR_WurID == Wybrane.WUR_WurID);
            www.WUR_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajNowyWniosekUrlopowy");
        }
        #endregion Helpers
    }
}