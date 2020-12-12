﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels.Dodawanie
{
    public class DodajZdarzenieViewModel : NowyViewModel<ZDA_Zdarzenia>
    {
        #region Constructor
        public DodajZdarzenieViewModel() : base()
        {
            item = new ZDA_Zdarzenia();
            base.DisplayName = "Dodaj Zdarzenie";
        }
        #endregion Constructor

        #region Properties

        public int? ZDA_PraID
        {
            get
            {
                return item.ZDA_PraID;
            }
            set
            {
                if (item.ZDA_PraID != value)
                {
                    item.ZDA_PraID = value;
                    base.OnPropertyChanged(() => ZDA_PraID);
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
                        from klient in urlopyApiXaml.PRA_Pracownicy
                        select klient
                    ).ToList().AsQueryable();
            }
        }




        public string ZDA_Nazwa
        {
            get
            {
                return item.ZDA_Nazwa;
            }
            set
            {
                if (item.ZDA_Nazwa != value)
                {
                    item.ZDA_Nazwa = value;
                    base.OnPropertyChanged(() => ZDA_Nazwa);
                }
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            urlopyApiXaml.ZDA_Zdarzenia.Add(item);
            urlopyApiXaml.SaveChanges();
        }

        #endregion Helpers

    }
}