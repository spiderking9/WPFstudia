using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajGrafikPracyViewModel : NowyViewModel<GRP_GrafikPracy>
    {
        #region Constructor
        public DodajGrafikPracyViewModel() : base()
        {
            item = new GRP_GrafikPracy();
            base.DisplayName = "Dodaj GrafikPracy";
            GRP_Dzien = DateTime.Now;
            GRP_PraID = urlopyApiXaml.PRA_Pracownicy.FirstOrDefault().PRA_PraID;
        }
        #endregion Constructor

        #region Properties
        public int GRP_PraID
        {
            get
            {
                return item.GRP_PraID;
            }
            set
            {
                if (item.GRP_PraID != value)
                {
                    item.GRP_PraID = value;
                    base.OnPropertyChanged(() => GRP_PraID);
                }
            }
        }
        public IQueryable<PRA_Pracownicy> PracownikComboBoxItems
        {
            get
            {
                return
                    (
                        from prac in urlopyApiXaml.PRA_Pracownicy
                        select prac
                    ).ToList().AsQueryable();
            }
        }

        public DateTime? GRP_Dzien
        {
            get
            {
                return item.GRP_Dzien;
            }
            set
            {
                if (item.GRP_Dzien != value)
                {
                    item.GRP_Dzien = value;
                    base.OnPropertyChanged(() => GRP_Dzien);
                }
            }
        }

        public string GRP_Zmiana
        {
            get
            {
                return item.GRP_Zmiana;
            }
            set
            {
                if (item.GRP_Zmiana != value)
                {
                    item.GRP_Zmiana = value;
                    base.OnPropertyChanged(() => GRP_Zmiana);
                }
            }
        }





        #endregion Properties

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.GRP_GrafikPracy.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}