using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajKlientaViewModel : NowyViewModel<KLI_Klienci>
    {
        #region Constructor
        public DodajKlientaViewModel() : base()
        {
            item = new KLI_Klienci();
            item.KLI_CzyAktywny = true;
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

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.KLI_Klienci.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}