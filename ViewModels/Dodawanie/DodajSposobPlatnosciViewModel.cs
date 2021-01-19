using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajSposobPlatnosciViewModel : NowyViewModel<SPP_SposobPlatnosci>
    {
        #region Constructor
        public DodajSposobPlatnosciViewModel() : base()
        {
            item = new SPP_SposobPlatnosci();
            item.SPP_CzyAktywny = true;
            base.DisplayName = "Dodaj Sposobu Platnosci";
        }
        #endregion Constructor

        #region Properties
        public string SPP_Nazwa
        {
            get
            {
                return item.SPP_Nazwa;
            }
            set
            {
                if (item.SPP_Nazwa != value)
                {
                    item.SPP_Nazwa = value;
                    base.OnPropertyChanged(() => SPP_Nazwa);
                }
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.SPP_SposobPlatnosci.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}