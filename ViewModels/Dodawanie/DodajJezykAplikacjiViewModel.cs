using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajJezykAplikacjiViewModel : NowyViewModel<JAP_JezykAplikacji>
    {
        #region Constructor
        public DodajJezykAplikacjiViewModel() : base()
        {
            item = new JAP_JezykAplikacji();
            base.DisplayName = "Dodaj JezykAplikacji";
        }
        #endregion Constructor

        #region Properties
        public string JAP_Nazwa
        {
            get
            {
                return item.JAP_Nazwa;
            }
            set
            {
                if (item.JAP_Nazwa != value)
                {
                    item.JAP_Nazwa = value;
                    base.OnPropertyChanged(() => JAP_Nazwa);
                }
            }
        }


        #endregion Properties

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.JAP_JezykAplikacji.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}