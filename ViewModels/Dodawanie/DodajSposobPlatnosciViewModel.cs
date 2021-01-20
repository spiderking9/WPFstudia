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
        public DodajSposobPlatnosciViewModel(SPP_SposobPlatnosci itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new SPP_SposobPlatnosci();
                item.SPP_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

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
            if (item.SPP_SppID == 0)
            {
                urlopyApiXaml.SPP_SposobPlatnosci.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.SPP_SposobPlatnosci.FirstOrDefault(x => x.SPP_SppID == item.SPP_SppID);
                zdarzenie.SPP_Nazwa = SPP_Nazwa.Trim();
            }

            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}