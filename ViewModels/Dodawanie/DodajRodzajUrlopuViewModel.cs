using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    class DodajRodzajUrlopuViewModel : NowyViewModel<RUR_RodzajeUrlopow>, IDataErrorInfo
    {
        #region Constructor
        public DodajRodzajUrlopuViewModel(RUR_RodzajeUrlopow itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new RUR_RodzajeUrlopow();
                item.RUR_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj RodzajUrlopu";
        }
        #endregion Constructor

        #region Properties
        public string RUR_Nazwa
        {
            get
            {
                return item.RUR_Nazwa;
            }
            set
            {
                if (item.RUR_Nazwa != value)
                {
                    item.RUR_Nazwa = value;
                    base.OnPropertyChanged(() => RUR_Nazwa);
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
                if (name == "RUR_Nazwa")
                    komunikat = TextValidator.Max10Znakow(RUR_Nazwa);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["RUR_Nazwa"] == null ) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            if (item.RUR_RurID ==0)
            {
                urlopyApiXaml.RUR_RodzajeUrlopow.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.RUR_RodzajeUrlopow.FirstOrDefault(x => x.RUR_RurID == item.RUR_RurID);
                zdarzenie.RUR_Nazwa = RUR_Nazwa.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}