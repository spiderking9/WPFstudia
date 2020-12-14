using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajStrefeCzasowaViewModel : NowyViewModel<STC_StrefaCzasowa>
    {
        #region Constructor
        public DodajStrefeCzasowaViewModel() : base()
        {
            item = new STC_StrefaCzasowa();
            base.DisplayName = "Dodaj Strefe Czasowa";
        }
        #endregion Constructor

        #region Properties
        public string STC_Nazwa
        {
            get
            {
                return item.STC_Nazwa;
            }
            set
            {
                if (item.STC_Nazwa != value)
                {
                    item.STC_Nazwa = value;
                    base.OnPropertyChanged(() => STC_Nazwa);
                }
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.STC_StrefaCzasowa.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}