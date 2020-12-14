using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.WybieraniePozycji
{
    public class TowaryViewModel : WszystkieViewModel<TowarView>
    {
        #region Konstruktor
        public TowaryViewModel()
        {
            base.DisplayName = "Towary";
        }
        #endregion Konstruktor
        private TowarView _WybranTowar;
        public TowarView WybranyTowar
        {
            get
            {
                return _WybranTowar;
            }
            set
            {
                if (_WybranTowar != value)
                {
                    _WybranTowar = value;
                    Messenger.Default.Send(_WybranTowar);
                    OnRequestClose();

                }
            }
        }
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<TowarView>(
                from towar in urlopyApiXaml.TOW_Towary
                select new TowarView
                {
                    TOW_TowID = towar.TOW_TowID,
                    TOW_Nazwa = towar.TOW_Nazwa,
                    TOW_Kod = towar.TOW_Kod,
                    TOW_Opis= towar.TOW_Opis,
                    TOW_KatNazwa = towar.KAT_KategorieTowarow.KAT_Nazwa,
                    TOW_StanIlosciowy = towar.TOW_StanIlosciowy,
                    TOW_Zdjecie = towar.TOW_Zdjecie
                });
        }
        #endregion Helpers
    }
}