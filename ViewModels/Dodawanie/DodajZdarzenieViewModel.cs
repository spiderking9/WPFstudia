using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajZdarzenieViewModel : NowyViewModel<ZDA_Zdarzenia>, IDataErrorInfo
    {
        #region Constructor
        public DodajZdarzenieViewModel(ZDA_Zdarzenia itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new ZDA_Zdarzenia();
                item.ZDA_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }
            base.DisplayName = "Dodaj Zdarzenie";
        }
        #endregion Constructor

        #region Properties

        public int ZDA_PraID
        {
            get
            {
                return item.ZDA_PraID;
            }
            set
            {
                if (item.ZDA_PraID != value)
                {
                    item.ZDA_PraID = value;
                    base.OnPropertyChanged(() => ZDA_PraID);
                }
            }
        }
        public IQueryable<PRA_Pracownicy> PracownikComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from klient in urlopyApiXaml.PRA_Pracownicy
                        where klient.PRA_CzyAktywny==true
                        select klient
                    ).ToList().AsQueryable();
            }
        }




        public string ZDA_Nazwa
        {
            get
            {
                return item.ZDA_Nazwa;
            }
            set
            {
                if (item.ZDA_Nazwa != value)
                {
                    item.ZDA_Nazwa = value;
                    base.OnPropertyChanged(() => ZDA_Nazwa);
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
                if (name == "ZDA_Nazwa")
                    komunikat = TextValidator.Max50Znakow(ZDA_Nazwa);
                if (name == "ZDA_PraID")
                    komunikat = TextValidator.SprawdzKluczObcyInt(ZDA_PraID);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["WUR_DataOd"] == null &&
                this["WUR_DataDo"] == null &&
                this["WUR_PraID"] == null &&
                this["WUR_RurID"] == null) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            if (item.ZDA_ZdaID == 0)
            {
                urlopyApiXaml.ZDA_Zdarzenia.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.ZDA_Zdarzenia.FirstOrDefault(x => x.ZDA_ZdaID == item.ZDA_ZdaID);
                zdarzenie.ZDA_Nazwa = ZDA_Nazwa.Trim();
                zdarzenie.ZDA_PraID = ZDA_PraID;
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}