using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajDzialViewModel : NowyViewModel<DZI_Dzialy>, IDataErrorInfo
    {
        #region Constructor
        public DodajDzialViewModel(DZI_Dzialy itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new DZI_Dzialy();
                item.DZI_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj Dział";
        }
        #endregion Constructor

        #region Properties
        public string DZI_Nazwa
        {
            get
            {
                return item.DZI_Nazwa;
            }
            set
            {
                if (item.DZI_Nazwa != value)
                {
                    item.DZI_Nazwa = value;
                    base.OnPropertyChanged(() => DZI_Nazwa);
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
                if (name == "DZI_Nazwa")
                {
                    komunikat = TextValidator.SprawdzCzyZaczynaSieOdDuzej(this.DZI_Nazwa);
                }
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["DZI_Nazwa"] == null) return true;
            return false;
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            if (item.DZI_DziID == 0)
            {
                urlopyApiXaml.DZI_Dzialy.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.DZI_Dzialy.FirstOrDefault(x => x.DZI_DziID == item.DZI_DziID);
                zdarzenie.DZI_Nazwa = DZI_Nazwa.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}