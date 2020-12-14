using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajWniosekUrlopowyViewModel : NowyViewModel<WUR_WnioskiUrlopowe>
    {
        #region Constructor
        public DodajWniosekUrlopowyViewModel() : base()
        {
            item = new WUR_WnioskiUrlopowe();
            base.DisplayName = "Dodaj Wniosek Urlopowy";
            WUR_DataOd = DateTime.Now;
            WUR_DataDo = DateTime.Now;
        }
        #endregion Constructor

        #region Properties
        public DateTime WUR_DataOd
        {
            get
            {
                return item.WUR_DataOd;
            }
            set
            {
                if (item.WUR_DataOd != value)
                {
                    item.WUR_DataOd = value;
                    base.OnPropertyChanged(() => WUR_DataOd);
                }
            }
        }

        public DateTime WUR_DataDo
        {
            get
            {
                return item.WUR_DataDo;
            }
            set
            {
                if (item.WUR_DataDo != value)
                {
                    item.WUR_DataDo = value;
                    base.OnPropertyChanged(() => WUR_DataDo);
                }
            }
        }

        public int WUR_RurID
        {
            get
            {
                return item.WUR_RurID;
            }
            set
            {
                if (item.WUR_RurID != value)
                {
                    item.WUR_RurID = value;
                    base.OnPropertyChanged(() => WUR_RurID);
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
                        from rodzUrlop in urlopyApiXaml.RUR_RodzajeUrlopow
                        select rodzUrlop
                    ).ToList().AsQueryable();
            }
        }


        public int WUR_PraID
        {
            get
            {
                return item.WUR_PraID;
            }
            set
            {
                if (item.WUR_PraID != value)
                {
                    item.WUR_PraID = value;
                    base.OnPropertyChanged(() => WUR_PraID);
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
                        from prac in urlopyApiXaml.PRA_Pracownicy
                        select prac
                    ).ToList().AsQueryable();
            }
        }


        #endregion Properties

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.WUR_WnioskiUrlopowe.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}