using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajKlientaViewModel : NowyViewModel<KLI_Klienci>, IDataErrorInfo
    {
        #region Constructor
        public DodajKlientaViewModel(KLI_Klienci itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new KLI_Klienci();
                item.KLI_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj Klienta";
        }
        #endregion Constructor

        #region Properties
        public string KLI_Nazwa
        {
            get
            {
                return item.KLI_Nazwa;
            }
            set
            {
                if (item.KLI_Nazwa != value)
                {
                    item.KLI_Nazwa = value;
                    base.OnPropertyChanged(() => KLI_Nazwa);
                }
            }
        }

        public string KLI_Adres
        {
            get
            {
                return item.KLI_Adres;
            }
            set
            {
                if (item.KLI_Adres != value)
                {
                    item.KLI_Adres = value;
                    base.OnPropertyChanged(() => KLI_Adres);
                }
            }
        }

        public string KLI_Telefon
        {
            get
            {
                return item.KLI_Telefon;
            }
            set
            {
                if (item.KLI_Telefon != value)
                {
                    item.KLI_Telefon = value;
                    base.OnPropertyChanged(() => KLI_Telefon);
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
                if (name == "KLI_Nazwa")
                    komunikat = TextValidator.Max50Znakow(KLI_Nazwa);
                if (name == "KLI_Adres")
                    komunikat = TextValidator.Max50Znakow(KLI_Adres);
                if (name == "KLI_Telefon")
                    komunikat = TextValidator.SprawdzCzyPoprawnyNrTel(KLI_Telefon);

                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["KLI_Adres"] == null &&
                this["KLI_Nazwa"] == null &&
                this["KLI_Telefon"] == null) return true;
            return false;
        }
        #endregion Validation

        #region Helpers
        public override void Save()
        {
            if (item.KLI_KliID == 0)
            {
                urlopyApiXaml.KLI_Klienci.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.KLI_Klienci.FirstOrDefault(x => x.KLI_KliID == item.KLI_KliID);
                zdarzenie.KLI_Nazwa = KLI_Nazwa.Trim();
                zdarzenie.KLI_Adres = KLI_Adres.Trim();
                zdarzenie.KLI_Telefon = KLI_Telefon.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}