using System;
using System.Collections.Generic;
using System.Linq;
using UrlopyApiXaml.Models.Entities;
using System.Text;
using System.ComponentModel;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    class DodajJednostkiMiaryViewModel : NowyViewModel<JEM_JednostkiMiary>, IDataErrorInfo
    {
        #region Constructor
        public DodajJednostkiMiaryViewModel(JEM_JednostkiMiary itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new JEM_JednostkiMiary();
                item.JEM_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }
            base.DisplayName = "Dodaj JednostkiMiary";
        }
        #endregion Constructor

        #region Properties
        public string JEM_Nazwa
        {
            get
            {
                return item.JEM_Nazwa;
            }
            set
            {
                if (item.JEM_Nazwa != value)
                {
                    item.JEM_Nazwa = value;
                    base.OnPropertyChanged(() => JEM_Nazwa);
                }
            }
        }

        public string JEM_Opis
        {
            get
            {
                return item.JEM_Opis;
            }
            set
            {
                if (item.JEM_Opis != value)
                {
                    item.JEM_Opis = value;
                    base.OnPropertyChanged(() => JEM_Opis);
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
                if (name == "JEM_Nazwa")
                    komunikat = TextValidator.Max50Znakow(this.JEM_Nazwa);
                if (name == "JEM_Opis")
                    komunikat = TextValidator.Max50Znakow(this.JEM_Opis);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["JEM_Nazwa"] == null &&
                this["JEM_Opis"] == null) return true;
            return false;
        }
        #endregion Validation

        #region Helpers
        public override void Save()
        {

            if (item.JEM_JemID == 0)
            {
                urlopyApiXaml.JEM_JednostkiMiary.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.JEM_JednostkiMiary.FirstOrDefault(x => x.JEM_JemID == item.JEM_JemID);
                zdarzenie.JEM_Opis = JEM_Opis.Trim();
                zdarzenie.JEM_Nazwa = JEM_Nazwa.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}