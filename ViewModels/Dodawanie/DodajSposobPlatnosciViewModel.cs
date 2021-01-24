using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajSposobPlatnosciViewModel : NowyViewModel<SPP_SposobPlatnosci>, IDataErrorInfo
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
                if (name == "SPP_Nazwa")
                    komunikat = TextValidator.Max20Znakow(SPP_Nazwa);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["SPP_Nazwa"] == null) return true;
            return false;
        }
        #endregion Validation
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