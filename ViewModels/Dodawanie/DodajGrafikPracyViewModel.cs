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
        public DodajGrafikPracyViewModel(GRP_GrafikPracy itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new GRP_GrafikPracy();
                item.GRP_CzyAktywny = true;
                GRP_Dzien = DateTime.Now;
            }
            else
            {
                item = itemEdytowany;
            }
            base.DisplayName = "Dodaj GrafikPracy";

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
                        where prac.PRA_CzyAktywny==true
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
            if (item.GRP_GrpID == 0)
            {
                urlopyApiXaml.GRP_GrafikPracy.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.GRP_GrafikPracy.FirstOrDefault(x => x.GRP_GrpID == item.GRP_GrpID);
                zdarzenie.GRP_PraID = GRP_PraID;
                zdarzenie.GRP_Zmiana = GRP_Zmiana.Trim();
                zdarzenie.GRP_Dzien = GRP_Dzien;

            }
                urlopyApiXaml.SaveChanges();

            #endregion Helpers
        }
    }
}