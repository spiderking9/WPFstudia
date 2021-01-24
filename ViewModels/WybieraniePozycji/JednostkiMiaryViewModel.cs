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
    public class JednostkiMiaryViewModel : WszystkieViewModel<JednostkaMiaryView>
    {
        #region Konstruktor
        public JednostkiMiaryViewModel()
        {
            base.DisplayName = "JednostkiMiary";
        }
        #endregion Konstruktor
        private JednostkaMiaryView _WybranaJednostkaMiary;
        public JednostkaMiaryView WybranaJednostkaMiary
        {
            get
            {
                return _WybranaJednostkaMiary;
            }
            set
            {
                if (_WybranaJednostkaMiary != value)
                {
                    _WybranaJednostkaMiary = value;
                    Messenger.Default.Send(_WybranaJednostkaMiary);
                    OnRequestClose();

                }
            }
        }
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<JednostkaMiaryView>(urlopyApiXaml.JEM_JednostkiMiary.Select(x=>new JednostkaMiaryView {
                JEM_JemID=x.JEM_JemID,
                JEM_Nazwa=x.JEM_Nazwa,
                JEM_Opis=x.JEM_Opis
            }));
        }
        #endregion Helpers
    }
}