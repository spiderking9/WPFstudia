using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels.Listy
{
    public class RodzajUrlopuViewModel : WszystkieViewModel<RUR_RodzajeUrlopow>
    {
        private RUR_RodzajeUrlopow _Wybrane;

        public RUR_RodzajeUrlopow Wybrane
        {
            get
            {
                return _Wybrane;
            }
            set
            {
                if (_Wybrane != value)
                {
                    _Wybrane = value;
                }
            }
        }
        #region Konstruktor
        public RodzajUrlopuViewModel()
        {
            base.DisplayName = "Lista Rodzajów Urlopów";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<RUR_RodzajeUrlopow>(urlopyApiXaml.RUR_RodzajeUrlopow.Where(x => x.RUR_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.RUR_RodzajeUrlopow.FirstOrDefault(m => m.RUR_RurID == Wybrane.RUR_RurID));
        }
        public override void del()
        {
            RUR_RodzajeUrlopow www = urlopyApiXaml.RUR_RodzajeUrlopow.FirstOrDefault(m => m.RUR_RurID == Wybrane.RUR_RurID);
            www.RUR_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajRodzajUrlopu");
        }
        #endregion Helpers
    }
}