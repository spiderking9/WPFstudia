using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajStrefeCzasowaViewModel : NowyViewModel<STC_StrefaCzasowa>, IDataErrorInfo
    {
        #region Constructor
        public DodajStrefeCzasowaViewModel(STC_StrefaCzasowa itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new STC_StrefaCzasowa();
                item.STC_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }
            base.DisplayName = "Dodaj Strefe Czasowa";
        }
        #endregion Constructor

        #region Properties
        public string STC_Nazwa
        {
            get
            {
                return item.STC_Nazwa;
            }
            set
            {
                if (item.STC_Nazwa != value)
                {
                    item.STC_Nazwa = value;
                    base.OnPropertyChanged(() => STC_Nazwa);
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
                if (name == "STC_Nazwa")
                    komunikat = TextValidator.Max10Znakow(STC_Nazwa);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["STC_Nazwa"] == null) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            if (item.STC_StcID == 0)
            {
                urlopyApiXaml.STC_StrefaCzasowa.Add(item);

            }
            else
            {
                var zdarzenie = urlopyApiXaml.STC_StrefaCzasowa.FirstOrDefault(x => x.STC_StcID == item.STC_StcID);
                zdarzenie.STC_Nazwa = STC_Nazwa.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}