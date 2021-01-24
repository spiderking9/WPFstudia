using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajJezykAplikacjiViewModel : NowyViewModel<JAP_JezykAplikacji>, IDataErrorInfo
    {
        #region Constructor
        public DodajJezykAplikacjiViewModel(JAP_JezykAplikacji itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new JAP_JezykAplikacji();
                item.JAP_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj JezykAplikacji";
        }
        #endregion Constructor

        #region Properties
        public string JAP_Nazwa
        {
            get
            {
                return item.JAP_Nazwa;
            }
            set
            {
                if (item.JAP_Nazwa != value)
                {
                    item.JAP_Nazwa = value;
                    base.OnPropertyChanged(() => JAP_Nazwa);
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
                if (name == "JAP_Nazwa")
                    komunikat = TextValidator.Max20Znakow(this.JAP_Nazwa);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["JAP_Nazwa"] == null) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            if (item.JAP_JapID == 0)
            {
                urlopyApiXaml.JAP_JezykAplikacji.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.JAP_JezykAplikacji.FirstOrDefault(x => x.JAP_JapID == item.JAP_JapID);
                zdarzenie.JAP_Nazwa = JAP_Nazwa.Trim();
            }

            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}