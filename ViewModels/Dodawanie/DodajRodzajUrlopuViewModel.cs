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
        public DodajRodzajUrlopuViewModel() : base()
        {
            item = new RUR_RodzajeUrlopow();
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
            urlopyApiXaml.RUR_RodzajeUrlopow.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}