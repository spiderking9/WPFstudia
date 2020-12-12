using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajFaktureViewModel : NowyViewModel<FAK_Faktury>
    {
        #region Constructor
        public DodajFaktureViewModel() : base()
        {
            item = new FAK_Faktury();
            base.DisplayName = "Dodaj Fakture";
            FAK_DataWystawienia = DateTime.Now;
        }
        #endregion Constructor

        #region Properties

        public DateTime FAK_DataWystawienia
        {
            get
            {
                return item.FAK_DataWystawienia;
            }
            set
            {
                if (item.FAK_DataWystawienia != value)
                {
                    item.FAK_DataWystawienia = value;
                    base.OnPropertyChanged(() => FAK_DataWystawienia);
                }
            }
        }
        public int? FAK_KliID
        {
            get
            {
                return item.FAK_KliID;
            }
            set
            {
                if (item.FAK_KliID != value)
                {
                    item.FAK_KliID = value;
                    base.OnPropertyChanged(() => FAK_KliID);
                }
            }
        }
        public IQueryable<KLI_Klienci> KlienciComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from klient in urlopyApiXaml.KLI_Klienci
                        select klient
                    ).ToList().AsQueryable();
            }
        }




        public int? FAK_SppID
        {
            get
            {
                return item.FAK_SppID;
            }
            set
            {
                if (item.FAK_SppID != value)
                {
                    item.FAK_SppID = value;
                    base.OnPropertyChanged(() => FAK_SppID);
                }
            }
        }

        public IQueryable<SPP_SposobPlatnosci> SposobPlatnosciComboBoxItems
        {
            get
            {
                return
                    (
                        from sposob in urlopyApiXaml.SPP_SposobPlatnosci
                        select sposob
                    ).ToList().AsQueryable();
            }
        }


        #endregion Properties

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.FAK_Faktury.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}