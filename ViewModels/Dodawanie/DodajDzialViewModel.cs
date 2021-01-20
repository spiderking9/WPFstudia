using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajDzialViewModel : NowyViewModel<DZI_Dzialy>
    {
        #region Constructor
        public DodajDzialViewModel(DZI_Dzialy itemEdytowany) : base()
        {
            if (itemEdytowany == null)
            {
                item = new DZI_Dzialy();
                item.DZI_CzyAktywny = true;
            }
            else
            {
                item = itemEdytowany;
            }

            base.DisplayName = "Dodaj Dział";
        }
        #endregion Constructor

        #region Properties
        public string DZI_Nazwa
        {
            get
            {
                return item.DZI_Nazwa;
            }
            set
            {
                if (item.DZI_Nazwa != value)
                {
                    item.DZI_Nazwa = value;
                    base.OnPropertyChanged(() => DZI_Nazwa);
                }
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            if (item.DZI_DziID == 0)
            {
                urlopyApiXaml.DZI_Dzialy.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.DZI_Dzialy.FirstOrDefault(x => x.DZI_DziID == item.DZI_DziID);
                zdarzenie.DZI_Nazwa = DZI_Nazwa.Trim();
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}