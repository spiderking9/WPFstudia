using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.WybieraniePozycji
{
    public class JednostkiMiaryViewModel : WszystkieViewModel<JEM_JednostkiMiary>
    {
        #region Konstruktor
        public JednostkiMiaryViewModel()
        {
            base.DisplayName = "JednostkiMiary";
        }
        #endregion Konstruktor
        private JEM_JednostkiMiary _WybranaJednostkaMiary;
        public JEM_JednostkiMiary WybranaJednostkaMiary
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
            List = new ObservableCollection<JEM_JednostkiMiary>(urlopyApiXaml.JEM_JednostkiMiary);
        }
        #endregion Helpers
    }
}