using System;
using System.Collections.Generic;
using System.Linq;
using UrlopyApiXaml.Models.Entities;
using System.Text;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    class DodajJednostkiMiaryViewModel : NowyViewModel<JEM_JednostkiMiary>
    {
        #region Constructor
        public DodajJednostkiMiaryViewModel() : base()
        {
            item = new JEM_JednostkiMiary();
            base.DisplayName = "Dodaj JednostkiMiary";
        }
        #endregion Constructor

        #region Properties
        public string JEM_Nazwa
        {
            get
            {
                return item.JEM_Nazwa;
            }
            set
            {
                if (item.JEM_Nazwa != value)
                {
                    item.JEM_Nazwa = value;
                    base.OnPropertyChanged(() => JEM_Nazwa);
                }
            }
        }

        public string JEM_Opis
        {
            get
            {
                return item.JEM_Opis;
            }
            set
            {
                if (item.JEM_Opis != value)
                {
                    item.JEM_Opis = value;
                    base.OnPropertyChanged(() => JEM_Opis);
                }
            }
        }


        #endregion Properties

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.JEM_JednostkiMiary.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}