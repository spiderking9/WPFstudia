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
    class DodajDelegacjeViewModel : NowyViewModel<DEL_Delegacje>, IDataErrorInfo
    {
        #region Constructor
        public DodajDelegacjeViewModel(DEL_Delegacje itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new DEL_Delegacje();
                item.DEL_CzyAktywny = true;
                DEL_DzienOd = DateTime.Now;
                DEL_DzienDo = DateTime.Now;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj Delegacje";

        }
        #endregion Constructor

        #region Properties
        public int DEL_PraID
        {
            get
            {
                return item.DEL_PraID;
            }
            set
            {
                if (item.DEL_PraID != value)
                {
                    item.DEL_PraID = value;
                    base.OnPropertyChanged(() => DEL_PraID);
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
                            PRA_PraID=prac.PRA_PraID,
                            ImieNazwisko=prac.PRA_Imie+" "+prac.PRA_Nazwisko
                        }
                    ).ToList().AsQueryable();
            }
        }
        public string DEL_Tytul
        {
            get
            {
                return item.DEL_Tytul;
            }
            set
            {
                if (item.DEL_Tytul != value)
                {
                    item.DEL_Tytul = value;
                    base.OnPropertyChanged(() => DEL_Tytul);
                }
            }
        }

        public string DEL_JakiTransport
        {
            get
            {
                return item.DEL_JakiTransport;
            }
            set
            {
                if (item.DEL_JakiTransport != value)
                {
                    item.DEL_JakiTransport = value;
                    base.OnPropertyChanged(() => DEL_JakiTransport);
                }
            }
        }
        public string DEL_MiejscowoscStartu
        {
            get
            {
                return item.DEL_MiejscowoscStartu;
            }
            set
            {
                if (item.DEL_MiejscowoscStartu != value)
                {
                    item.DEL_MiejscowoscStartu = value;
                    base.OnPropertyChanged(() => DEL_MiejscowoscStartu);
                }
            }
        }

        public string DEL_MiejscowoscCelu
        {
            get
            {
                return item.DEL_MiejscowoscCelu;
            }
            set
            {
                if (item.DEL_MiejscowoscCelu != value)
                {
                    item.DEL_MiejscowoscCelu = value;
                    base.OnPropertyChanged(() => DEL_MiejscowoscCelu);
                }
            }
        }
        public DateTime DEL_DzienOd
        {
            get
            {
                return item.DEL_DzienOd;
            }
            set
            {
                if (item.DEL_DzienOd != value)
                {
                    item.DEL_DzienOd = value;
                    base.OnPropertyChanged(() => DEL_DzienOd);
                }
            }
        }
        public DateTime DEL_DzienDo
        {
            get
            {
                return item.DEL_DzienDo;
            }
            set
            {
                if (item.DEL_DzienDo != value)
                {
                    item.DEL_DzienDo = value;
                    base.OnPropertyChanged(() => DEL_DzienDo);
                }
            }
        }
        public string DEL_Komentarz
        {
            get
            {
                return item.DEL_Komentarz;
            }
            set
            {
                if (item.DEL_Komentarz != value)
                {
                    item.DEL_Komentarz = value;
                    base.OnPropertyChanged(() => DEL_Komentarz);
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
                if (name == "DEL_Tytul")
                    komunikat = TextValidator.Max50Znakow(this.DEL_Tytul);
                if (name == "DEL_JakiTransport")
                    komunikat = TextValidator.Max50Znakow(this.DEL_JakiTransport);
                if (name == "DEL_MiejscowoscStartu")
                    komunikat = TextValidator.Max50Znakow(this.DEL_MiejscowoscStartu);
                if (name == "DEL_MiejscowoscCelu")
                    komunikat = TextValidator.Max50Znakow(this.DEL_MiejscowoscCelu);
                if (name == "DEL_DzienOd")
                    komunikat = TextValidator.PoprawnaDataDelegacji(this.DEL_DzienOd, DEL_DzienDo);
                if (name == "DEL_DzienDo")
                    komunikat = TextValidator.PoprawnaDataDelegacji(this.DEL_DzienOd, DEL_DzienDo);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["DEL_Tytul"] == null&&
                this["DEL_JakiTransport"] == null &&
                this["DEL_MiejscowoscStartu"] == null &&
                this["DEL_MiejscowoscCelu"] == null &&
                this["DEL_DzienOd"] == null &&
                this["DEL_DzienDo"] == null) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {
            if (item.DEL_DelID == 0)
            {
                urlopyApiXaml.DEL_Delegacje.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.DEL_Delegacje.FirstOrDefault(x => x.DEL_DelID == item.DEL_DelID);
                zdarzenie.DEL_PraID = DEL_PraID;
                zdarzenie.DEL_Tytul = DEL_Tytul.Trim();
                zdarzenie.DEL_JakiTransport = DEL_JakiTransport.Trim();
                zdarzenie.DEL_MiejscowoscStartu = DEL_MiejscowoscStartu;
                zdarzenie.DEL_MiejscowoscCelu = DEL_MiejscowoscCelu;
                zdarzenie.DEL_DzienOd = DEL_DzienOd;
                zdarzenie.DEL_DzienDo = DEL_DzienDo;
                zdarzenie.DEL_Komentarz = DEL_Komentarz;
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}