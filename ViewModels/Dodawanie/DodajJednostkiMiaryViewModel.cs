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
        public DodajJednostkiMiaryViewModel(JEM_JednostkiMiary itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new JEM_JednostkiMiary();
                item.JEM_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }
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

            if (item.JEM_JemID == 0)
            {
                urlopyApiXaml.JEM_JednostkiMiary.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.JEM_JednostkiMiary.FirstOrDefault(x => x.JEM_JemID == item.JEM_JemID);
                zdarzenie.JEM_Opis = JEM_Opis.Trim();
                zdarzenie.JEM_Nazwa = JEM_Nazwa.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}