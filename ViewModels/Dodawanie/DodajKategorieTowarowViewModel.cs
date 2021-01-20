using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajKategorieTowarowViewModel : NowyViewModel<KAT_KategorieTowarow>
    {
        #region Constructor
        public DodajKategorieTowarowViewModel(KAT_KategorieTowarow itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new KAT_KategorieTowarow();
                item.KAT_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj KategorieTowarow";
        }
        #endregion Constructor

        #region Properties
        public string KAT_Nazwa
        {
            get
            {
                return item.KAT_Nazwa;
            }
            set
            {
                if (item.KAT_Nazwa != value)
                {
                    item.KAT_Nazwa = value;
                    base.OnPropertyChanged(() => KAT_Nazwa);
                }
            }
        }

        public string KAT_Opis
        {
            get
            {
                return item.KAT_Opis;
            }
            set
            {
                if (item.KAT_Opis != value)
                {
                    item.KAT_Opis = value;
                    base.OnPropertyChanged(() => KAT_Opis);
                }
            }
        }


        #endregion Properties

        #region Helpers
        public override void Save()
        {
            if (item.KAT_KatID == 0)
            {
                urlopyApiXaml.KAT_KategorieTowarow.Add(item);

            }
            else
            {
                var zdarzenie = urlopyApiXaml.KAT_KategorieTowarow.FirstOrDefault(x => x.KAT_KatID == item.KAT_KatID);
                zdarzenie.KAT_Nazwa = KAT_Nazwa.Trim();
                zdarzenie.KAT_Opis = KAT_Opis.Trim();

            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}