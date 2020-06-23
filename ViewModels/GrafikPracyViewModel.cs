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
using UrlopyApiXaml;
using UrlopyApiXaml.Models;
using static UrlopyApiXaml.Models.GrafikPracyModel;

namespace UrlopyApiXaml.ViewModels
{
    public class GrafikPracyViewModel : WorkspaceViewModel
    {
        #region Konstruktory
        public GrafikPracyViewModel()
        {
            base.DisplayName = "GrafikPracy";
            GrafikPracyModel xx = new GrafikPracyModel();
            Uzytkownik= new BindableCollection<DataLista>(xx.Lista());

            ResultData3 = new TableData(xx.Naglowki(), xx.Wiersze());

        }

        private BindableCollection<DataLista> _Uzytkownik;
        public BindableCollection<DataLista> Uzytkownik { 
            get 
            {
                return _Uzytkownik;
            } 
            set
            {
                if (_Uzytkownik != value)
                {
                    _Uzytkownik = value;
                    OnPropertyChanged(() => Uzytkownik);
                }
            }
        }

        private TableData _ResultData3;
        public TableData ResultData3
        {
            get
            {
                return _ResultData3;
            }
            set
            {
                if (_ResultData3 != value)
                {
                    _ResultData3 = value;
                    OnPropertyChanged(() => ResultData3);
                }
            }
        }

        public ICommand DodajCommand
        {
            get {
                return new BaseCommand(Dodaj);
            } 

        }

        public void Dodaj()
        {
            GrafikPracyModel xx = new GrafikPracyModel();
            Uzytkownik = new BindableCollection<DataLista>(xx.Lista(LiczOd, LiczDo));
        }

        #endregion
        private int _LiczOd;
        public int LiczOd
        {
            get
            {
                return _LiczOd;
            }
            set
            {
                if (_LiczOd != value)
                {
                    GrafikPracyModel xx = new GrafikPracyModel();
                    _LiczOd = value;
                    Uzytkownik = new BindableCollection<DataLista>(xx.Lista(LiczOd, LiczDo));
                    OnPropertyChanged(() => LiczOd);
                }
            }
        }
        private int _LiczDo;
        public int LiczDo
        {
            get
            {
                return _LiczDo;
            }
            set
            {
                if (_LiczDo != value)
                {
                    GrafikPracyModel xx2 = new GrafikPracyModel();
                    _LiczDo = value;
                    Uzytkownik = new BindableCollection<DataLista>(xx2.Lista(LiczOd, LiczDo));
                    OnPropertyChanged(() => LiczDo);
                }
            }
        }
    }
}
