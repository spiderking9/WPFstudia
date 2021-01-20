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
        public DodajJezykAplikacjiViewModel(JAP_JezykAplikacji itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new JAP_JezykAplikacji();
                item.JAP_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

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
            if (item.JAP_JapID == 0)
            {
                urlopyApiXaml.JAP_JezykAplikacji.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.JAP_JezykAplikacji.FirstOrDefault(x => x.JAP_JapID == item.JAP_JapID);
                zdarzenie.JAP_Nazwa = JAP_Nazwa.Trim();
            }

            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}