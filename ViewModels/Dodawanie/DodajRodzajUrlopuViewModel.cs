using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    class DodajRodzajUrlopuViewModel : NowyViewModel<RUR_RodzajeUrlopow>
    {
        #region Constructor
        public DodajRodzajUrlopuViewModel(RUR_RodzajeUrlopow itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new RUR_RodzajeUrlopow();
                item.RUR_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj RodzajUrlopu";
        }
        #endregion Constructor

        #region Properties
        public string RUR_Nazwa
        {
            get
            {
                return item.RUR_Nazwa;
            }
            set
            {
                if (item.RUR_Nazwa != value)
                {
                    item.RUR_Nazwa = value;
                    base.OnPropertyChanged(() => RUR_Nazwa);
                }
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            if (item.RUR_RurID ==0)
            {
                urlopyApiXaml.RUR_RodzajeUrlopow.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.RUR_RodzajeUrlopow.FirstOrDefault(x => x.RUR_RurID == item.RUR_RurID);
                zdarzenie.RUR_Nazwa = RUR_Nazwa.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}