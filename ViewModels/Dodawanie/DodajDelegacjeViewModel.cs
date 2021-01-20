using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    class DodajDelegacjeViewModel : NowyViewModel<DEL_Delegacje>
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
                        select new PracownicyView
                        {
                            PraID=prac.PRA_PraID,
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