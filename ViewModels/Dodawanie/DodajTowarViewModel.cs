using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajTowarViewModel : NowyViewModel<TOW_Towary>
    {
        #region Constructor
        public DodajTowarViewModel() : base()
        {
            item = new TOW_Towary();
            item.TOW_CzyAktywny = true;
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

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.TOW_Towary.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}