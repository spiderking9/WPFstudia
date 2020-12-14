using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UrlopyApiXaml.Helper;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajPozycjeFakturViewModel : NowyViewModel<POF_PozycjeFaktury>
    {
        #region Constructor
        public DodajPozycjeFakturViewModel() : base()
        {

            //Messenger.Default.Register<int>(this, getPracownikId);
            item = new POF_PozycjeFaktury();
            base.DisplayName = "Dodaj PozycjeFaktury";
            Messenger.Default.Register<TowarView>(this, getWybranyTowar);
            Messenger.Default.Register<FakturyView>(this, getWybranaFaktura);
            Messenger.Default.Register<JEM_JednostkiMiary>(this, getWybranaJednostkaMiary);
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
            FakturaNazwa = "Faktura o nr: "+ fakt.FAK_FakID+ " dla klienta o nazwie: "+ fakt.NazwaKlienta;
        }
        private void getWybranaJednostkaMiary(JEM_JednostkiMiary jedn)
        {
            POF_JemID = jedn.JEM_JemID;
            JednostkaMiaryNazwa = jedn.JEM_Nazwa;
        }

        #endregion Helpers

    }
}