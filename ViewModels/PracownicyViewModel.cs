using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UrlopyApiXaml;
using UrlopyApiXaml.Helper;
using UrlopyApiXaml.Models.Entities;
using UrlopyApiXaml.Models.EntitiesForView;

namespace UrlopyApiXaml.ViewModels
{
    public class PracownicyViewModel : WszystkieViewModel<PracownicyView> //bo wszystkie zakladki dziedzicza po WorkSpaceViewModel
    {
        int pracId;
        #region Konstruktor
        public PracownicyViewModel()
        {
            base.DisplayName = "Pracownicy";

        }
        private ObservableCollection<DzialLiczbaPracownikow> _ListDzialow;
        public ObservableCollection<DzialLiczbaPracownikow> ListDzialow
        {
            get
            {
                if (_ListDzialow == null) load(); //jezeli lista jest pusta to wywolujemy metode load
                return _ListDzialow;
            }
            set
            {
                _ListDzialow = value; OnPropertyChanged(() => ListDzialow);
            }
        }
        public int PRA_PraID
        {
            set
            {
                if (pracId != value)
                {
                    pracId = value;
                }
            }
        }
        #endregion

        public override void load()
        {
            List = new ObservableCollection<PracownicyView>
                (
                    from prac in urlopyApiXaml.PRA_Pracownicy
                    select new PracownicyView
                    {
                        PRA_PraID= prac.PRA_PraID,
                        ImieNazwisko= prac.PRA_Imie+" "+prac.PRA_Nazwisko,
                        NazwaDzialu= prac.DZI_Dzialy.DZI_Nazwa
                    }
                );

            ListDzialow = new ObservableCollection<DzialLiczbaPracownikow>(
                    from dzial in urlopyApiXaml.DZI_Dzialy
                    join prac in urlopyApiXaml.PRA_Pracownicy
                    on dzial.DZI_DziID equals prac.PRA_DziID
                    group prac by dzial into g
                    select new DzialLiczbaPracownikow
                    {
                        NazwaDzialu=g.Key.DZI_Nazwa,
                        LiczbaPracownikow=g.Count()
                    }
                );
        }
        private BaseCommand _EditCommand;

        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new BaseCommand(() => Messenger.Default.Send("EdytujPracownika"));
                }
                return _EditCommand;
            }
        }

        private void Edit()
        {
            Messenger.Default.Send("EdytujPracownika");
            Messenger.Default.Send(pracId);
            OnRequestClose();
        }


        //SaveAndClose()
    }
}
