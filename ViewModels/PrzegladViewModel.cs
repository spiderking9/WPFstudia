using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UrlopyApiXaml;
using UrlopyApiXaml.Helper;
using UrlopyApiXaml.Models.BusinessLogic;
using UrlopyApiXaml.Models.Entities;


namespace UrlopyApiXaml.ViewModels
{
    public class PrzegladViewModel : WszystkieViewModel<Nowa>
    {
        private BaseCommand _DodajNowyWniosekUrlopowy;
        private BaseCommand _PokazListeWnioskowUrlopowych;
        private BaseCommand _PrzesunWPrawo;
        private BaseCommand _PrzesunWLewo;
        private DateTime _Data=DateTime.Now;
        private DateTime _Data2 = DateTime.Now.AddDays(14);
        private int _PraID;
        public int PraID
        {
            get
            {
                return _PraID;
            }
            set
            {
                if (_PraID != value)
                {
                    _PraID = value;
                    load();
                    base.OnPropertyChanged(() => PraID);
                }
            }
        }


        public IQueryable<PRA_Pracownicy> PracownicyComboBoxItems
        {
            get
            {
                return
                    (
                        from dzial in urlopyApiXaml.PRA_Pracownicy
                        select dzial
                    ).ToList().AsQueryable();
            }
        }
        public DateTime Data
        {
            get
            {
                return _Data;
            }
            set
            {
                if (_Data != value)
                {
                    _Data = value;
                    base.OnPropertyChanged(() => Data);
                }
            }
        }

        public DateTime Data2
        {
            get
            {
                return _Data2;
            }
            set
            {
                if (_Data2 != value)
                {
                    _Data2 = value;
                    base.OnPropertyChanged(() => Data2);
                }
            }
        }
        private string _DataString;
        public string DataString
        {
            get
            {
                return _DataString;
            }
            set
            {
                if (_DataString != value)
                {
                    _DataString = value;
                    base.OnPropertyChanged(() => DataString);
                }
            }
        }



        public ICommand DodajNowyWniosekUrlopowy
        {
            get
            {
                if (_DodajNowyWniosekUrlopowy == null)
                {
                    _DodajNowyWniosekUrlopowy = new BaseCommand(() => Messenger.Default.Send("DodajNowyWniosekUrlopowy"));
                }
                return _DodajNowyWniosekUrlopowy;
            }
        }
        public ICommand PokazListeWnioskowUrlopowych
        {
            get
            {
                if (_PokazListeWnioskowUrlopowych == null)
                {
                    _PokazListeWnioskowUrlopowych = new BaseCommand(() => Messenger.Default.Send("PokazListeWnioskowUrlopowych"));
                }
                return _PokazListeWnioskowUrlopowych;
            }
        }

        public ICommand PrzesunWPrawo
        {
            get
            {
                if (_PrzesunWPrawo == null)
                {
                    _PrzesunWPrawo = new BaseCommand(() => 
                    {
                        Data = Data.AddDays(1);
                        Data2 = Data2.AddDays(1);
                        UrlopAlboZmianaPracy.setDataString(Data, Data2);
                        load();
                    });
                }
                return _PrzesunWPrawo;
            }
        }
        public ICommand PrzesunWLewo
        {
            get
            {
                if (_PrzesunWLewo == null)
                {
                    _PrzesunWLewo = new BaseCommand(() => 
                    { 
                        Data = Data.AddDays(-1); 
                        Data2 = Data2.AddDays(-1);
                        UrlopAlboZmianaPracy.setDataString(Data, Data2);
                        load();
                    });
                }
                return _PrzesunWLewo;
            }
        }

        public PrzegladViewModel()
        {
            DataString = UrlopAlboZmianaPracy.setDataString(Data, Data2);
            base.DisplayName = "Przeglad";
        }

        public override void load()
        {
            List = new UrlopAlboZmianaPracy(urlopyApiXaml).GetZmiana(Data, PraID);
        }
    }
}
