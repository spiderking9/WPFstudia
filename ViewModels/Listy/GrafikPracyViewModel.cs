using Caliburn.Micro;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using UrlopyApiXaml.Helper;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models;
using GalaSoft.MvvmLight.Messaging;

namespace UrlopyApiXaml.ViewModels.Listy
{
    public class GrafikPracyViewModel: WszystkieViewModel<GRP_GrafikPracy>
    {
        private GRP_GrafikPracy _Wybrane;

        public GRP_GrafikPracy Wybrane
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
        public GrafikPracyViewModel()
        {
            base.DisplayName = "Grafik Pracy";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<GRP_GrafikPracy>(urlopyApiXaml.GRP_GrafikPracy.Where(x => x.GRP_CzyAktywny == true));
        }

        public override void edit()
        {
            if (Wybrane != null)
                Messenger.Default.Send(urlopyApiXaml.GRP_GrafikPracy.FirstOrDefault(m => m.GRP_GrpID == Wybrane.GRP_GrpID));
        }
        public override void del()
        {
            GRP_GrafikPracy www = urlopyApiXaml.GRP_GrafikPracy.FirstOrDefault(m => m.GRP_GrpID == Wybrane.GRP_GrpID);
            www.GRP_CzyAktywny = false;
            urlopyApiXaml.SaveChanges();
            load();
        }
        public override void add()
        {
            Messenger.Default.Send("DodajGrafikPracy");
        }
        #endregion Helpers
    }
}