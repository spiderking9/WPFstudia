﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UrlopyApiXaml.Helper;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajPozycjeFakturViewModel : NowyViewModel<POF_PozycjeFaktury>, IDataErrorInfo
    {
        #region Constructor
        public DodajPozycjeFakturViewModel() : base()
        {
            item = new POF_PozycjeFaktury();
            item.POF_CzyAktywny = true;
            base.DisplayName = "Dodaj PozycjeFaktury";
            Messenger.Default.Register<TowarView>(this, getWybranyTowar);
            Messenger.Default.Register<FakturyView>(this, getWybranaFaktura);
            Messenger.Default.Register<JednostkaMiaryView>(this, getWybranaJednostkaMiary);
        }
        #endregion Constructor

        #region Properties
        public int POF_TowID
        {
            get
            {
                return item.POF_TowID;
            }
            set
            {
                if (item.POF_TowID != value)
                {
                    item.POF_TowID = value;
                    base.OnPropertyChanged(() => POF_TowID);
                }
            }
        }
        private string _TowarNazwa;
        public string TowarNazwa
        {
            get
            {
                return _TowarNazwa;
            }
            set
            {
                if (_TowarNazwa != value)
                {
                    _TowarNazwa = value;
                    base.OnPropertyChanged(() => TowarNazwa);
                }
            }
        }

        private BaseCommand _ShowTowar;
        public ICommand ShowTowar
        {
            get
            {
                if (_ShowTowar == null)
                {
                    _ShowTowar = new BaseCommand(() => Messenger.Default.Send("ShowTowarPF"));
                }
                return _ShowTowar;
            }
        }

        public int POF_FakID
        {
            get
            {
                return item.POF_FakID;
            }
            set
            {
                if (item.POF_FakID != value)
                {
                    item.POF_FakID = value;
                    base.OnPropertyChanged(() => POF_FakID);
                }
            }
        }
        private string _FakturaNazwa;
        public string FakturaNazwa
        {
            get
            {
                return _FakturaNazwa;
            }
            set
            {
                if (_FakturaNazwa != value)
                {
                    _FakturaNazwa = value;
                    base.OnPropertyChanged(() => FakturaNazwa);
                }
            }
        }
        private BaseCommand _ShowFaktura;
        public ICommand ShowFaktura
        {
            get
            {
                if (_ShowFaktura == null)
                {
                    _ShowFaktura = new BaseCommand(() => Messenger.Default.Send("ShowFakturyPF"));
                }
                return _ShowFaktura;
            }
        }
        public int POF_JemID
        {
            get
            {
                return item.POF_JemID;
            }
            set
            {
                if (item.POF_JemID != value)
                {
                    item.POF_JemID = value;
                    base.OnPropertyChanged(() => POF_JemID);
                }
            }
        }
        private string _JednostkaMiaryNazwa;
        public string JednostkaMiaryNazwa
        {
            get
            {
                return _JednostkaMiaryNazwa;
            }
            set
            {
                if (_JednostkaMiaryNazwa != value)
                {
                    _JednostkaMiaryNazwa = value;
                    base.OnPropertyChanged(() => JednostkaMiaryNazwa);
                }
            }
        }
        private BaseCommand _ShowJednostkaMiary;
        public ICommand ShowJednostkaMiary
        {
            get
            {
                if (_ShowJednostkaMiary == null)
                {
                    _ShowJednostkaMiary = new BaseCommand(() => Messenger.Default.Send("ShowJednostkaMiaryPF"));
                }
                return _ShowJednostkaMiary;
            }
        }
        public string POF_Nazwa
        {
            get
            {
                return item.POF_Nazwa;
            }
            set
            {
                if (item.POF_Nazwa != value)
                {
                    item.POF_Nazwa = value;
                    base.OnPropertyChanged(() => POF_Nazwa);
                }
            }
        }
        public int POF_Ilosc
        {
            get
            {
                return item.POF_Ilosc;
            }
            set
            {
                if (item.POF_Ilosc != value)
                {
                    item.POF_Ilosc = value;
                    base.OnPropertyChanged(() => POF_Ilosc);
                }
            }
        }
        public decimal POF_Cena
        {
            get
            {
                return item.POF_Cena;
            }
            set
            {
                if (item.POF_Cena != value)
                {
                    item.POF_Cena = value;
                    base.OnPropertyChanged(() => POF_Cena);
                }
            }
        }
        public decimal POF_Rabat
        {
            get
            {
                return item.POF_Rabat;
            }
            set
            {
                if (item.POF_Rabat != value)
                {
                    item.POF_Rabat = value;
                    base.OnPropertyChanged(() => POF_Rabat);
                }
            }
        }

        public decimal POF_Marza
        {
            get
            {
                return item.POF_Marza;
            }
            set
            {
                if (item.POF_Marza != value)
                {
                    item.POF_Marza = value;
                    base.OnPropertyChanged(() => POF_Marza);
                }
            }
        }


        #endregion Properties
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "POF_Nazwa")
                    komunikat = TextValidator.Max50Znakow(POF_Nazwa);
                if (name == "POF_Ilosc")
                    komunikat = TextValidator.IloscSztuk(POF_Ilosc);
                if (name == "POF_Cena")
                    komunikat = TextValidator.SpradzDecimal(POF_Cena);
                if (name == "POF_Rabat")
                    komunikat = TextValidator.SpradzDecimal(POF_Rabat);
                if (name == "POF_Marza")
                    komunikat = TextValidator.SpradzDecimal(POF_Marza);

                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["POF_Nazwa"] == null &&
                this["POF_Ilosc"] == null &&
                this["POF_Cena"] == null &&
                this["POF_Rabat"] == null &&
                this["POF_Marza"] == null) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.POF_PozycjeFaktury.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        private void getWybranyTowar(TowarView towar)
        {
            POF_TowID = towar.TOW_TowID;
            TowarNazwa = towar.TOW_Nazwa;
        }
        private void getWybranaFaktura(FakturyView fakt)
        {
            POF_FakID = fakt.FAK_FakID;
            FakturaNazwa = "nr: "+ fakt.FAK_FakID+ " klient: "+ fakt.NazwaKlienta;
        }
        private void getWybranaJednostkaMiary(JednostkaMiaryView jedn)
        {
            POF_JemID = jedn.JEM_JemID;
            JednostkaMiaryNazwa = jedn.JEM_Nazwa;
        }

        #endregion Helpers

    }
}