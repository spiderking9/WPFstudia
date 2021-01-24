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
    public class DodajUrlopyViewModel : NowyViewModel<URL_Urlopy>, IDataErrorInfo
    {
        #region Constructor
        public DodajUrlopyViewModel() : base()
        {
            item = new URL_Urlopy();
            item.URL_CzyAktywny = true;
            base.DisplayName = "Dodaj Urlopy";
            URL_DzienDo = DateTime.Now;
            URL_DzienOd = DateTime.Now;
        }
        #endregion Constructor

        #region Properties
        public int? URL_PraID
        {
            get
            {
                return item.URL_PraID;
            }
            set
            {
                if (item.URL_PraID != value)
                {
                    item.URL_PraID = value;
                    base.OnPropertyChanged(() => URL_PraID);
                }
            }
        }
        public IQueryable<PracownicyView> PracownikComboBoxItems
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
                            ImieNazwisko = prac.PRA_Imie+" "+prac.PRA_Nazwisko
                        }
                    ).ToList().AsQueryable();
            }
        }

        public DateTime URL_DzienOd
        {
            get
            {
                return item.URL_DzienOd;
            }
            set
            {
                if (item.URL_DzienOd != value)
                {
                    item.URL_DzienOd = value;
                    base.OnPropertyChanged(() => URL_DzienOd);
                }
            }
        }

        public DateTime URL_DzienDo
        {
            get
            {
                return item.URL_DzienDo;
            }
            set
            {
                if (item.URL_DzienDo != value)
                {
                    item.URL_DzienDo = value;
                    base.OnPropertyChanged(() => URL_DzienDo);
                }
            }
        }

        public int? URL_RurID
        {
            get
            {
                return item.URL_RurID;
            }
            set
            {
                if (item.URL_RurID != value)
                {
                    item.URL_RurID = value;
                    base.OnPropertyChanged(() => URL_RurID);
                }
            }
        }

        public IQueryable<RUR_RodzajeUrlopow> RodzajUrlopuComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from rodz in urlopyApiXaml.RUR_RodzajeUrlopow
                        where rodz.RUR_CzyAktywny==true
                        select rodz
                    ).ToList().AsQueryable();
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
                if (name == "URL_DzienOd")
                    komunikat = TextValidator.PoprawnaDataUrlopu(URL_DzienOd, URL_DzienDo);
                if (name == "URL_DzienDo")
                    komunikat = TextValidator.PoprawnaDataUrlopu(URL_DzienOd, URL_DzienDo);

                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["URL_DzienOd"] == null &&
                this["URL_DzienDo"] == null ) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.URL_Urlopy.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}