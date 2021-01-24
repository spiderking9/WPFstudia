using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajFotorejestracjeViewModel : NowyViewModel<FOT_Fotorejestracja>, IDataErrorInfo
    {
        #region Constructor
        public DodajFotorejestracjeViewModel(FOT_Fotorejestracja itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new FOT_Fotorejestracja();
                item.FOT_CzyAktywny = true;
                FOT_DataWejscia = DateTime.Today;
                FOT_DataWyjscia = DateTime.Today;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj Fotorejestracje";

        }
        #endregion Constructor

        #region Properties
        public TimeSpan FOT_GodzinaWejscia
        {
            get
            {
                return item.FOT_GodzinaWejscia;
            }
            set
            {
                if (item.FOT_GodzinaWejscia != value)
                {
                    item.FOT_GodzinaWejscia = value;
                    base.OnPropertyChanged(() => FOT_GodzinaWejscia);
                }
            }
        }
        public TimeSpan FOT_GodzinaWyjscia
        {
            get
            {
                return item.FOT_GodzinaWyjscia;
            }
            set
            {
                if (item.FOT_GodzinaWyjscia != value)
                {
                    item.FOT_GodzinaWyjscia = value;
                    base.OnPropertyChanged(() => FOT_GodzinaWyjscia);
                }
            }
        }
        public int FOT_PraID
        {
            get
            {
                return item.FOT_PraID;
            }
            set
            {
                if (item.FOT_PraID != value)
                {
                    item.FOT_PraID = value;
                    base.OnPropertyChanged(() => FOT_PraID);
                }
            }
        }
        public IQueryable<PracownicyView> PracownicyComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from prac in urlopyApiXaml.PRA_Pracownicy
                        where prac.PRA_CzyAktywny==true
                        select new PracownicyView
                        {
                            PRA_PraID = prac.PRA_PraID,
                            ImieNazwisko = prac.PRA_Imie + " " + prac.PRA_Nazwisko
                        }
                    ).ToList().AsQueryable();
            }
        }
        public DateTime FOT_DataWejscia
        {
            get
            {
                return item.FOT_DataWejscia;
            }
            set
            {
                if (item.FOT_DataWejscia != value)
                {
                    item.FOT_DataWejscia = value;
                    base.OnPropertyChanged(() => FOT_DataWejscia);
                }
            }
        }
        public DateTime FOT_DataWyjscia
        {
            get
            {
                return item.FOT_DataWyjscia;
            }
            set
            {
                if (item.FOT_DataWyjscia != value)
                {
                    item.FOT_DataWyjscia = value;
                    base.OnPropertyChanged(() => FOT_DataWyjscia);
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
                if (name == "FOT_DataWejscia")
                    komunikat = TextValidator.PoprawnaDataDelegacji(this.FOT_DataWejscia, FOT_DataWyjscia);
                if (name == "FOT_DataWyjscia")
                    komunikat = TextValidator.PoprawnaDataDelegacji(this.FOT_DataWejscia, FOT_DataWyjscia);

                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["FOT_DataWejscia"] == null &&
                this["FOT_DataWyjscia"] == null) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            if (item.FOT_FotID == 0)
            {
                urlopyApiXaml.FOT_Fotorejestracja.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.FOT_Fotorejestracja.FirstOrDefault(x => x.FOT_FotID == item.FOT_FotID);
                zdarzenie.FOT_PraID = FOT_PraID;
                zdarzenie.FOT_GodzinaWejscia = FOT_GodzinaWejscia;
                zdarzenie.FOT_GodzinaWyjscia = FOT_GodzinaWyjscia;
                zdarzenie.FOT_DataWejscia = FOT_DataWejscia;
                zdarzenie.FOT_DataWyjscia = FOT_DataWyjscia;
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}