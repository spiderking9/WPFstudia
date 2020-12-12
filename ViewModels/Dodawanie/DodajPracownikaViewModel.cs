using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajPracownikaViewModel : NowyViewModel<PRA_Pracownicy>
    {
        #region Constructor
        public DodajPracownikaViewModel() : base()
        {

            Messenger.Default.Register<int>(this, getPracownikId);
            item = new PRA_Pracownicy();
            base.DisplayName = "Dodaj Pracownika";
            //Messenger.Default.Register<PRA_Pracownicy>(this, getWybranyKontrahent);
        }
        #endregion Constructor

        #region Properties
        public int PRA_PraID
        {
            get
            {
                return item.PRA_PraID;
            }
            set
            {
                if (item.PRA_PraID != value)
                {
                    item.PRA_PraID = value;
                    base.OnPropertyChanged(() => PRA_PraID);
                }
            }
        }

        public string PRA_Imie
        {
            get
            {
                return item.PRA_Imie;
            }
            set
            {
                if (item.PRA_Imie != value)
                {
                    item.PRA_Imie = value;
                    base.OnPropertyChanged(() => PRA_Imie);
                }
            }
        }

        public int? PRA_DziID
        {
            get
            {
                return item.PRA_DziID;
            }
            set
            {
                if (item.PRA_DziID != value)
                {
                    item.PRA_DziID = value;
                    base.OnPropertyChanged(() => PRA_DziID);
                }
            }
        }

        public IQueryable<DZI_Dzialy> DzialComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from dzial in urlopyApiXaml.DZI_Dzialy
                        select dzial
                    ).ToList().AsQueryable();
            }
        }

        public string PRA_Nazwisko
        {
            get
            {
                return item.PRA_Nazwisko;
            }
            set
            {
                if (item.PRA_Nazwisko != value)
                {
                    item.PRA_Nazwisko = value;
                    base.OnPropertyChanged(() => PRA_Nazwisko);
                }
            }
        }
        public string PRA_ILogin
        {
            get
            {
                return item.PRA_ILogin;
            }
            set
            {
                if (item.PRA_ILogin != value)
                {
                    item.PRA_ILogin = value;
                    base.OnPropertyChanged(() => PRA_ILogin);
                }
            }
        }
        public byte[] PRA_Haslo
        {
            get
            {
                return item.PRA_Haslo;
            }
            set
            {
                if (item.PRA_Haslo != value)
                {
                    item.PRA_Haslo = value;
                    base.OnPropertyChanged(() => PRA_Haslo);
                }
            }
        }
        public string PRA_UrlZdjecia
        {
            get
            {
                return item.PRA_UrlZdjecia;
            }
            set
            {
                if (item.PRA_UrlZdjecia != value)
                {
                    item.PRA_UrlZdjecia = value;
                    base.OnPropertyChanged(() => PRA_UrlZdjecia);
                }
            }
        }
        public int? PRA_StcID
        {
            get
            {
                return item.PRA_StcID;
            }
            set
            {
                if (item.PRA_StcID != value)
                {
                    item.PRA_StcID = value;
                    base.OnPropertyChanged(() => PRA_StcID);
                }
            }
        }
        public IQueryable<STC_StrefaCzasowa> StrefaCzasowaComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from strefa in urlopyApiXaml.STC_StrefaCzasowa
                        select strefa
                    ).ToList().AsQueryable();
            }
        }
        public string PRA_Email
        {
            get
            {
                return item.PRA_Email;
            }
            set
            {
                if (item.PRA_Email != value)
                {
                    item.PRA_Email = value;
                    base.OnPropertyChanged(() => PRA_Email);
                }
            }
        }
        public string PRA_Telefon
        {
            get
            {
                return item.PRA_Telefon;
            }
            set
            {
                if (item.PRA_Telefon != value)
                {
                    item.PRA_Telefon = value;
                    base.OnPropertyChanged(() => PRA_Telefon);
                }
            }
        }
        public string PRA_Ulica
        {
            get
            {
                return item.PRA_Ulica;
            }
            set
            {
                if (item.PRA_Ulica != value)
                {
                    item.PRA_Ulica = value;
                    base.OnPropertyChanged(() => PRA_Ulica);
                }
            }
        }
        public string PRA_Miasto
        {
            get
            {
                return item.PRA_Miasto;
            }
            set
            {
                if (item.PRA_Miasto != value)
                {
                    item.PRA_Miasto = value;
                    base.OnPropertyChanged(() => PRA_Miasto);
                }
            }
        }
        public string PRA_KodPocztowy
        {
            get
            {
                return item.PRA_KodPocztowy;
            }
            set
            {
                if (item.PRA_KodPocztowy != value)
                {
                    item.PRA_KodPocztowy = value;
                    base.OnPropertyChanged(() => PRA_KodPocztowy);
                }
            }
        }
        public bool? PRA_CzyZatrudniony
        {
            get
            {
                return item.PRA_CzyZatrudniony;
            }
            set
            {
                if (item.PRA_CzyZatrudniony != value)
                {
                    item.PRA_CzyZatrudniony = value;
                    base.OnPropertyChanged(() => PRA_CzyZatrudniony);
                }
            }
        }
        public int? PRA_JapID
        {
            get
            {
                return item.PRA_JapID;
            }
            set
            {
                if (item.PRA_JapID != value)
                {
                    item.PRA_JapID = value;
                    base.OnPropertyChanged(() => PRA_JapID);
                }
            }
        }

        public IQueryable<JAP_JezykAplikacji> JezykAplikacjiComboBoxItems
        {
            get
            {
                return
                    (
                        from jezyk in urlopyApiXaml.JAP_JezykAplikacji
                        select jezyk
                    ).ToList().AsQueryable();
            }
        }
        public bool? PRA_ZgodaMarketingowa
        {
            get
            {
                return item.PRA_ZgodaMarketingowa;
            }
            set
            {
                if (item.PRA_ZgodaMarketingowa != value)
                {
                    item.PRA_ZgodaMarketingowa = value;
                    base.OnPropertyChanged(() => PRA_ZgodaMarketingowa);
                }
            }
        }
        public string PRA_Wojewodztwo
        {
            get
            {
                return item.PRA_Wojewodztwo;
            }
            set
            {
                if (item.PRA_Wojewodztwo != value)
                {
                    item.PRA_Wojewodztwo = value;
                    base.OnPropertyChanged(() => PRA_Wojewodztwo);
                }
            }
        }
        public string PRA_NrDomu
        {
            get
            {
                return item.PRA_NrDomu;
            }
            set
            {
                if (item.PRA_NrDomu != value)
                {
                    item.PRA_NrDomu = value;
                    base.OnPropertyChanged(() => PRA_NrDomu);
                }
            }
        }
        public string PRA_Gmina
        {
            get
            {
                return item.PRA_Gmina;
            }
            set
            {
                if (item.PRA_Gmina != value)
                {
                    item.PRA_Gmina = value;
                    base.OnPropertyChanged(() => PRA_Gmina);
                }
            }
        }


        #endregion Properties

        #region Helpers
        public override void Save()
        {
            item.PRA_CzyAktywny = true;
            if (item.PRA_PraID== 0)
                urlopyApiXaml.PRA_Pracownicy.Add(item);
            urlopyApiXaml.SaveChanges();
        }
        private void getPracownikId(int pracId)
        {
            item = urlopyApiXaml.PRA_Pracownicy.FirstOrDefault(x=>x.PRA_PraID == pracId);
        }

        #endregion Helpers

    }
}