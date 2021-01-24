using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajTowarViewModel : NowyViewModel<TOW_Towary>, IDataErrorInfo
    {
        #region Constructor
        public DodajTowarViewModel(TOW_Towary itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new TOW_Towary();
                item.TOW_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj Towar";

        }
        #endregion Constructor

        #region Properties
        public string TOW_Nazwa
        {
            get
            {
                return item.TOW_Nazwa;
            }
            set
            {
                if (item.TOW_Nazwa != value)
                {
                    item.TOW_Nazwa = value;
                    base.OnPropertyChanged(() => TOW_Nazwa);
                }
            }
        }

        public string TOW_Kod
        {
            get
            {
                return item.TOW_Kod;
            }
            set
            {
                if (item.TOW_Kod != value)
                {
                    item.TOW_Kod = value;
                    base.OnPropertyChanged(() => TOW_Kod);
                }
            }
        }
        public string TOW_Opis
        {
            get
            {
                return item.TOW_Opis;
            }
            set
            {
                if (item.TOW_Opis != value)
                {
                    item.TOW_Opis = value;
                    base.OnPropertyChanged(() => TOW_Opis);
                }
            }
        }
        public int TOW_KatID
        {
            get
            {
                return item.TOW_KatID;
            }
            set
            {
                if (item.TOW_KatID != value)
                {
                    item.TOW_KatID = value;
                    base.OnPropertyChanged(() => TOW_KatID);
                }
            }
        }
        public IQueryable<KAT_KategorieTowarow> KategorieComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from katTowarow in urlopyApiXaml.KAT_KategorieTowarow
                        where katTowarow.KAT_CzyAktywny==true
                        select katTowarow
                    ).ToList().AsQueryable();
            }
        }

        public int TOW_StanIlosciowy
        {
            get
            {
                return item.TOW_StanIlosciowy;
            }
            set
            {
                if (item.TOW_StanIlosciowy != value)
                {
                    item.TOW_StanIlosciowy = value;
                    base.OnPropertyChanged(() => TOW_StanIlosciowy);
                }
            }
        }

        public string TOW_Zdjecie
        {
            get
            {
                return item.TOW_Zdjecie;
            }
            set
            {
                if (item.TOW_Zdjecie != value)
                {
                    item.TOW_Zdjecie = value;
                    base.OnPropertyChanged(() => TOW_Zdjecie);
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
                if (name == "TOW_Nazwa")
                    komunikat = TextValidator.Max50Znakow(TOW_Nazwa);
                if (name == "TOW_Kod")
                    komunikat = TextValidator.Max50Znakow(TOW_Kod);
                if (name == "TOW_Opis")
                    komunikat = TextValidator.Max50Znakow(TOW_Opis);
                if (name == "TOW_StanIlosciowy")
                    komunikat = TextValidator.IloscSztuk(TOW_StanIlosciowy);
                if (name == "TOW_Zdjecie")
                    komunikat = TextValidator.Max50Znakow(TOW_Zdjecie);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["TOW_Nazwa"] == null&&
                this["TOW_Kod"] == null &&
                this["TOW_Opis"] == null &&
                this["TOW_StanIlosciowy"] == null &&
                this["TOW_Zdjecie"] == null) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            if (item.TOW_TowID == 0)
            {
                urlopyApiXaml.TOW_Towary.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.TOW_Towary.FirstOrDefault(x => x.TOW_TowID == item.TOW_TowID);
                zdarzenie.TOW_Kod = TOW_Kod.Trim();
                zdarzenie.TOW_Nazwa = TOW_Nazwa.Trim();
                zdarzenie.TOW_Opis = TOW_Opis.Trim();
                zdarzenie.TOW_StanIlosciowy = TOW_StanIlosciowy;
                zdarzenie.TOW_KatID = TOW_KatID;
                zdarzenie.TOW_Zdjecie = TOW_Zdjecie.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}