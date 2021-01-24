﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.Validators;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajWniosekUrlopowyViewModel : NowyViewModel<WUR_WnioskiUrlopowe>, IDataErrorInfo
    {
        #region Constructor
        public DodajWniosekUrlopowyViewModel(WUR_WnioskiUrlopowe itemEdytowany) : base()
        {
            base.DisplayName = "Dodaj Wniosek Urlopowy";
            if (itemEdytowany == null)
            {
                item = new WUR_WnioskiUrlopowe();
                item.WUR_CzyAktywny = true;
                WUR_DataOd = DateTime.Now;
                WUR_DataDo = DateTime.Now;
            }
            else
            {
                item = itemEdytowany;
            }
        }
        #endregion Constructor

        #region Properties
        public DateTime WUR_DataOd
        {
            get
            {
                return item.WUR_DataOd;
            }
            set
            {
                if (item.WUR_DataOd != value)
                {
                    item.WUR_DataOd = value;
                    base.OnPropertyChanged(() => WUR_DataOd);
                }
            }
        }

        public DateTime WUR_DataDo
        {
            get
            {
                return item.WUR_DataDo;
            }
            set
            {
                if (item.WUR_DataDo != value)
                {
                    item.WUR_DataDo = value;
                    base.OnPropertyChanged(() => WUR_DataDo);
                }
            }
        }

        public int WUR_RurID
        {
            get
            {
                return item.WUR_RurID;
            }
            set
            {
                if (item.WUR_RurID != value)
                {
                    item.WUR_RurID = value;
                    base.OnPropertyChanged(() => WUR_RurID);
                }
            }
        }
        public IQueryable<RUR_RodzajeUrlopow> RodzajUrlopuComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from rodzUrlop in urlopyApiXaml.RUR_RodzajeUrlopow
                        where rodzUrlop.RUR_CzyAktywny==true
                        select rodzUrlop
                    ).ToList().AsQueryable();
            }
        }


        public int WUR_PraID
        {
            get
            {
                return item.WUR_PraID;
            }
            set
            {
                if (item.WUR_PraID != value)
                {
                    item.WUR_PraID = value;
                    base.OnPropertyChanged(() => WUR_PraID);
                }
            }
        }

        public IQueryable<PRA_Pracownicy> PracownikComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from prac in urlopyApiXaml.PRA_Pracownicy
                        where prac.PRA_CzyAktywny==true
                        select prac
                    ).ToList().AsQueryable();
            }
        }


        #endregion Properties
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "WUR_DataOd")
                    komunikat = TextValidator.PoprawnaDataUrlopu(WUR_DataOd, WUR_DataDo);
                if (name == "WUR_DataDo")
                    komunikat = TextValidator.PoprawnaDataUrlopu(WUR_DataOd, WUR_DataDo);
                if (name == "WUR_RurID")
                    komunikat = TextValidator.SprawdzKluczObcyInt(WUR_RurID);
                if (name == "WUR_PraID")
                    komunikat = TextValidator.SprawdzKluczObcyInt(WUR_PraID);
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true,
        //rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu

        public override bool IsValid()
        {
            if (this["WUR_DataOd"] == null &&
                this["WUR_DataDo"] == null &&
                this["WUR_PraID"] == null &&
                this["WUR_RurID"] == null) return true;
            return false;
        }
        #endregion Validation
        #region Helpers
        public override void Save()
        {

            if (item.WUR_WurID == 0)
            {
                urlopyApiXaml.WUR_WnioskiUrlopowe.Add(item);
            }
            else
            {
                var zdarzenie = urlopyApiXaml.WUR_WnioskiUrlopowe.FirstOrDefault(x => x.WUR_WurID == item.WUR_WurID);
                zdarzenie.WUR_DataOd = WUR_DataOd;
                zdarzenie.WUR_DataDo = WUR_DataDo;
                zdarzenie.WUR_PraID = WUR_PraID;
                zdarzenie.WUR_RurID = WUR_RurID;
            }
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}