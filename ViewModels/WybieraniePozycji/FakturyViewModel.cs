using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.WybieraniePozycji
{
    public class FakturyViewModel : WszystkieViewModel<FakturyView>
    {
        #region Konstruktor
        public FakturyViewModel()
        {
            base.DisplayName = "Faktury";
        }
        #endregion Konstruktor
        private FakturyView _WybranaFaktura;
        public FakturyView WybranaFaktura
        {
            get
            {
                return _WybranaFaktura;
            }
            set
            {
                if (_WybranaFaktura != value)
                {
                    _WybranaFaktura = value;
                    Messenger.Default.Send(_WybranaFaktura);
                    OnRequestClose();

                }
            }
        }
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<FakturyView>(
                from fakt in urlopyApiXaml.FAK_Faktury
                select new FakturyView
                {
                    FAK_FakID = fakt.FAK_FakID,
                    FAK_DataWystawienia = fakt.FAK_DataWystawienia,
                    NazwaKlienta = fakt.KLI_Klienci.KLI_Nazwa,
                    SposobPlatnosci = fakt.SPP_SposobPlatnosci.SPP_Nazwa
    });
        }
        #endregion Helpers
    }
}