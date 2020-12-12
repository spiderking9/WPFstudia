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


namespace UrlopyApiXaml.ViewModels
{
    public class GrafikPracyViewModel: WszystkieViewModel<GRP_GrafikPracy>
    {
        #region Konstruktor
        public GrafikPracyViewModel()
        {
            base.DisplayName = "Grafik Pracy";
        }
        #endregion Konstruktor
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<GRP_GrafikPracy>(urlopyApiXaml.GRP_GrafikPracy);
        }
        #endregion Helpers
    }
}