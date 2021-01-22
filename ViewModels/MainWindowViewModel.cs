using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UrlopyApiXaml.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using UrlopyApiXaml;
using UrlopyApiXaml.ViewModels.Zakladki;
using UrlopyApiXaml.ViewModels.WybieraniePozycji;
using UrlopyApiXaml.ViewModels.Dodawanie;
using UrlopyApiXaml.ViewModels.Listy;
using GalaSoft.MvvmLight.Messaging;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels
{
    //to jest 
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        //to jest 
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ReadOnlyCollection<CommandViewModel> _Commands2;
        //to jest 
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        private BaseCommand  _PrzegladCommand;
        public ICommand PrzegladCommand 
        {
            get
            {
                if (_PrzegladCommand == null)
                    _PrzegladCommand = new BaseCommand(()=>CreateView(new PrzegladViewModel()));
                return _PrzegladCommand;
            }
        }
        private BaseCommand _InnaDelegacjeCommand;
        public ICommand InnaDelegacjeCommand
        {
            get
            {
                if (_InnaDelegacjeCommand == null)
                    _InnaDelegacjeCommand = new BaseCommand(() => CreateView(new InnaDelegacjaViewModel()));
                return _InnaDelegacjeCommand;
            }
        }

        private BaseCommand _TwojKodCommand;
        public ICommand TwojKodCommand
        {
            get
            {
                if (_TwojKodCommand == null)
                    _TwojKodCommand = new BaseCommand(() => CreateView(new TwojKodViewModel()));
                return _TwojKodCommand;
            }
        }
        private BaseCommand _TowaryCommand;
        public ICommand TowaryCommand
        {
            get
            {
                if (_TowaryCommand == null)
                    _TowaryCommand = new BaseCommand(ShowAllObjects <TowarViewModel>);
                return _TowaryCommand;
            }
        }

        private BaseCommand _OpcjeCommand;
        public ICommand OpcjeCommand
        {
            get
            {
                if (_OpcjeCommand == null)
                    _OpcjeCommand = new BaseCommand(ShowAllObjects<OpcjeViewModel>);
                return _OpcjeCommand;
            }
        }
        private BaseCommand _OAplikacjiCommand;
        public ICommand OAplikacjiCommand
        {
            get
            {
                if (_OAplikacjiCommand == null)
                    _OAplikacjiCommand = new BaseCommand(ShowAllObjects<OAplikacjiViewModel>);
                return _OAplikacjiCommand;
            }
        }

        private BaseCommand _NowaFakturaCommand;
        public ICommand NowaFakturaCommand
        {
            get
            {
                if (_NowaFakturaCommand == null)
                    _NowaFakturaCommand = new BaseCommand(() => CreateView(new NowaFakturaViewModel()));
                return _NowaFakturaCommand;
            }
        }

        private BaseCommand _UrlopyCommand;
        public ICommand UrlopyCommand
        {
            get
            {
                if (_UrlopyCommand == null)
                    _UrlopyCommand = new BaseCommand(() => CreateView(new UrlopyViewModel()));
                return _UrlopyCommand;
            }
        }

        private BaseCommand _DodajUrlopyCommand;
        public ICommand DodajUrlopyCommand
        {
            get
            {
                if (_DodajUrlopyCommand == null)
                    _DodajUrlopyCommand = new BaseCommand(() => CreateView(new DodajUrlopyViewModel()));
                return _DodajUrlopyCommand;
            }
        }
        private BaseCommand _ZdarzeniaCommand;
        public ICommand ZdarzeniaCommand
        {
            get
            {
                if (_ZdarzeniaCommand == null)
                    _ZdarzeniaCommand = new BaseCommand(ShowAllObjects<ZdarzeniaViewModel>);
                return _ZdarzeniaCommand;
            }
        }
        private BaseCommand _KlientCommand;
        public ICommand KlientCommand
        {
            get
            {
                if (_KlientCommand == null)
                    _KlientCommand = new BaseCommand(ShowAllObjects<KlientViewModel>);
                return _KlientCommand;
            }
        }

        private BaseCommand _PracownicyCommand;
        public ICommand PracownicyCommand
        {
            get
            {
                if (_PracownicyCommand == null)
                    _PracownicyCommand = new BaseCommand(ShowAllObjects<PracownicyViewModel>);
                return _PracownicyCommand;
            }
        }

        private BaseCommand _SposoboPlatnosciCommand;
        public ICommand SposoboPlatnosciCommand
        {
            get
            {
                if (_SposoboPlatnosciCommand == null)
                    _SposoboPlatnosciCommand = new BaseCommand(ShowAllObjects<SposobPlatnosciViewModel>);
                return _SposoboPlatnosciCommand;
            }
        }

        private BaseCommand _RodzajUrlopuCommand;
        public ICommand RodzajUrlopuCommand
        {
            get
            {
                if (_RodzajUrlopuCommand == null)
                    _RodzajUrlopuCommand = new BaseCommand(ShowAllObjects<RodzajUrlopuViewModel>);
                return _RodzajUrlopuCommand;
            }
        }

        private BaseCommand _JednostkaMiaryCommand;
        public ICommand JednostkaMiaryCommand
        {
            get
            {
                if (_JednostkaMiaryCommand == null)
                    _JednostkaMiaryCommand = new BaseCommand(ShowAllObjects<JednostkaMiaryViewModel>);
                return _JednostkaMiaryCommand;
            }
        }

        private BaseCommand _KategorieTowarowCommand;
        public ICommand KategorieTowarowCommand
        {
            get
            {
                if (_KategorieTowarowCommand == null)
                    _KategorieTowarowCommand = new BaseCommand(ShowAllObjects<KategorieTowarowViewModel>);
                return _KategorieTowarowCommand;
            }
        }

        private BaseCommand _JezykAplikacjiCommand;
        public ICommand JezykAplikacjiCommand
        {
            get
            {
                if (_JezykAplikacjiCommand == null)
                    _JezykAplikacjiCommand = new BaseCommand(ShowAllObjects<JezykAplikacjiViewModel>);
                return _JezykAplikacjiCommand;
            }
        }
        private BaseCommand _DzialCommand;
        public ICommand DzialCommand
        {
            get
            {
                if (_DzialCommand == null)
                    _DzialCommand = new BaseCommand(ShowAllObjects<DzialViewModel>);
                return _DzialCommand;
            }
        }
        private BaseCommand _StrefaCzasowaCommand;
        public ICommand StrefaCzasowaCommand
        {
            get
            {
                if (_StrefaCzasowaCommand == null)
                    _StrefaCzasowaCommand = new BaseCommand(ShowAllObjects<StrefaCzasowaViewModel>);
                return _StrefaCzasowaCommand;
            }
        }
        private BaseCommand _FotorejestracjaCommand;
        public ICommand FotorejestracjaCommand
        {
            get
            {
                if (_FotorejestracjaCommand == null)
                    _FotorejestracjaCommand = new BaseCommand(ShowAllObjects<FotorejestracjaViewModel>);
                return _FotorejestracjaCommand;
            }
        }
        
        private BaseCommand _LokalizacjeCommand;
        public ICommand LokalizacjeCommand
        {
            get
            {
                if (_LokalizacjeCommand == null)
                    _LokalizacjeCommand = new BaseCommand(ShowAllObjects<LokalizacjeViewModel>);
                return _LokalizacjeCommand;
            }
        }

        private BaseCommand _PracListaCommand;
        public ICommand PracListaCommand
        {
            get
            {
                if (_PracListaCommand == null)
                    _PracListaCommand = new BaseCommand(ShowAllObjects<PracowListaViewModel>);
                return _PracListaCommand;
            }
        }
        private BaseCommand _DelegacjeCommand;
        public ICommand DelegacjeCommand
        {
            get
            {
                if (_DelegacjeCommand == null)
                    _DelegacjeCommand = new BaseCommand(ShowAllObjects<DelegacjeViewModel>);
                return _DelegacjeCommand;
            }
        }

        private BaseCommand _GrafikPracyCommand;
        public ICommand GrafikPracyCommand
        {
            get
            {
                if (_GrafikPracyCommand == null)
                    _GrafikPracyCommand = new BaseCommand(ShowAllObjects<GrafikPracyViewModel>);
                return _GrafikPracyCommand;
            }
        }

        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }

        public ReadOnlyCollection<CommandViewModel> Commands2
        {
            get
            {
                if (_Commands2 == null)
                {
                    List<CommandViewModel> cmds2 = this.CreateCommands2();
                    _Commands2 = new ReadOnlyCollection<CommandViewModel>(cmds2);
                }
                return _Commands2;
            }
        }
        private List<CommandViewModel> CreateCommands2()
        {
            Messenger.Default.Register<string>(this, open);
            Messenger.Default.Register<ZDA_Zdarzenia>(this, openZdarz);
            Messenger.Default.Register<GRP_GrafikPracy>(this, openGraf);
            Messenger.Default.Register<WUR_WnioskiUrlopowe>(this, openWniosekUrlop);
            Messenger.Default.Register<TOW_Towary>(this, openTowary);
            Messenger.Default.Register<SPP_SposobPlatnosci>(this, openSpospPlatnosci);
            Messenger.Default.Register<RUR_RodzajeUrlopow>(this, openRodzajUrlopu);
            Messenger.Default.Register<JEM_JednostkiMiary>(this, openJednostkMiary);
            Messenger.Default.Register<JAP_JezykAplikacji>(this, openJezykAplikacji);
            Messenger.Default.Register<KAT_KategorieTowarow>(this, openKatTowarow);
            Messenger.Default.Register<KLI_Klienci>(this, openKlient);
            Messenger.Default.Register<DZI_Dzialy>(this, openDzial);
            Messenger.Default.Register<STC_StrefaCzasowa>(this, openStrefaCzas);
            Messenger.Default.Register<DEL_Delegacje>(this, openDelegacje);
            Messenger.Default.Register<FOT_Fotorejestracja>(this, openFotorejestracje);
            Messenger.Default.Register<PRA_Pracownicy>(this, openPracownik);

            return new List<CommandViewModel>
            {
                new CommandViewModel("DodajGrafikPracy",new BaseCommand(() => this.CreateView(new DodajGrafikPracyViewModel(null))),"\uf2bb"),
                new CommandViewModel("DodajPracownika",new BaseCommand(() => this.CreateView(new DodajPracownikaViewModel(null))),"\uf2cd"),
                new CommandViewModel("DodajFakture",new BaseCommand(() => this.CreateView(new DodajFaktureViewModel())),"\uf1f3"),
                new CommandViewModel("DodajUrlopy",DodajUrlopyCommand,"\uf030"),
                new CommandViewModel("DodajJezykApp",new BaseCommand(() => this.CreateView(new DodajJezykAplikacjiViewModel(null))),"\uf2cd"),
                new CommandViewModel("DodajJednMiary",new BaseCommand(() => this.CreateView(new DodajJednostkiMiaryViewModel(null))),"\uf2cd"),
                new CommandViewModel("DodajKatTowar",new BaseCommand(() => this.CreateView(new DodajKategorieTowarowViewModel(null))),"\uf1f3"),
                new CommandViewModel("DodajKlienta",new BaseCommand(() => this.CreateView(new DodajKlientaViewModel(null))),"\uf1f3"),
                new CommandViewModel("DodajPozycjeFaktury",new BaseCommand(() => this.CreateView(new DodajPozycjeFakturViewModel())),"\uf2cd"),
                new CommandViewModel("DodajRodzajUrlopu",new BaseCommand(() => this.CreateView(new DodajRodzajUrlopuViewModel(null))),"\uf2cd"),
                new CommandViewModel("DodajSposobPlatnosci",new BaseCommand(() => this.CreateView(new DodajSposobPlatnosciViewModel(null))),"\uf2cd"),
                new CommandViewModel("DodajTowar",new BaseCommand(() => this.CreateView(new DodajTowarViewModel(null))),"\uf2cd"),
                new CommandViewModel("DodajWniosekUrlop",new BaseCommand(() => this.CreateView(new DodajWniosekUrlopowyViewModel(null))),"\uf2cd"),
                new CommandViewModel("DodajDzial",new BaseCommand(() => this.CreateView(new DodajDzialViewModel(null))),"\uf2bb"),
                new CommandViewModel("DodajStrefeCzas",new BaseCommand(() => this.CreateView(new DodajStrefeCzasowaViewModel(null))),"\uf2cd"),
                new CommandViewModel("DodajDelegac",new BaseCommand(() => this.CreateView(new DodajDelegacjeViewModel(null))),"\uf030"),
            };
        }

        private List<CommandViewModel> CreateCommands()
        {

            return new List<CommandViewModel>
            {
                //tu
                new CommandViewModel("Przeglad", PrzegladCommand, "\uf187"),
                new CommandViewModel("Zdarzenia",ZdarzeniaCommand, "\uf270"),
                new CommandViewModel("GrafikPracy",GrafikPracyCommand,"\uf2bb"),
                new CommandViewModel("Pracownicy",PracownicyCommand,"\uf2cd"),
                new CommandViewModel("PracLista",PracListaCommand,"\uf2cd"),
                new CommandViewModel("Faktura",NowaFakturaCommand,"\uf1f3"),
                new CommandViewModel("Lokalizacje",LokalizacjeCommand,"\uf030"),
                new CommandViewModel("Urlopy",UrlopyCommand,"\uf030"),
                new CommandViewModel("Towary", TowaryCommand, "\uf187"),
                new CommandViewModel("Spos Plat",SposoboPlatnosciCommand,"\uf2cd"),
                new CommandViewModel("Rodzaj Urlop", RodzajUrlopuCommand, "\uf187"),
                new CommandViewModel("Jedno Miary",JednostkaMiaryCommand,"\uf1f3"),
                new CommandViewModel("Jezyk App",JezykAplikacjiCommand,"\uf2bb"),
                new CommandViewModel("Kat Towar",KategorieTowarowCommand,"\uf2bb"),
                new CommandViewModel("Klienci",KlientCommand,"\uf1f3"),
                new CommandViewModel("Dzialy",DzialCommand,"\uf2cd"),
                new CommandViewModel("Strefy Czas",StrefaCzasowaCommand,"\uf030"),
                new CommandViewModel("Delegacje",DelegacjeCommand,"\uf2bb"),
                new CommandViewModel("Fotorejestracje",FotorejestracjaCommand,"\uf1f3"),

            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void open(string name) 
        {
            if (name == "DodajNowyWniosekUrlopowy")
                CreateView(new DodajWniosekUrlopowyViewModel(null));
            if (name == "PokazListeWnioskowUrlopowych")
                ShowAllObjects<ListaWnioskowUrlopowychViewModel>();
            if (name == "DodajZdarzenie")
                CreateView(new DodajZdarzenieViewModel(null));
            if (name == "EdytujPracownika")
                CreateView(new DodajPracownikaViewModel(null));
            if (name == "ShowTowarPF")
                ShowAllObjects<TowaryViewModel>();
            if (name == "DodajNowyTowar")
                CreateView(new DodajTowarViewModel(null));
            if (name == "ShowFakturyPF")
                ShowAllObjects<FakturyViewModel>();
            if (name == "ShowJednostkaMiaryPF")
                ShowAllObjects<JednostkiMiaryViewModel>();
            if (name == "DodajGrafikPracy")
                CreateView(new DodajGrafikPracyViewModel(null));
            if (name == "DodajSposobPlatnosci")
                CreateView(new DodajSposobPlatnosciViewModel(null)); 
            if (name == "DodajRodzajUrlopu")
                CreateView(new DodajRodzajUrlopuViewModel(null)); 
            if (name == "DodajJednostkeMiary")
                CreateView(new DodajJednostkiMiaryViewModel(null)); 
            if (name == "DodajJezykApp")
                CreateView(new DodajJezykAplikacjiViewModel(null));
            if (name == "DodajKatTowarow")
                CreateView(new DodajKategorieTowarowViewModel(null));
            if (name == "DodajKlienta")
                CreateView(new DodajKlientaViewModel(null)); 
            if (name == "DodajDzial")
                CreateView(new DodajDzialViewModel(null)); 
            if (name == "DodajStrefeCzasowa")
                CreateView(new DodajStrefeCzasowaViewModel(null));
            if (name == "DodajDelegacje")
                CreateView(new DodajDelegacjeViewModel(null));
        }
        private void openPracownik(PRA_Pracownicy objekt)
        {
            CreateView(new DodajPracownikaViewModel(objekt));
        }
        private void openFotorejestracje(FOT_Fotorejestracja objekt)
        {
            CreateView(new DodajFotorejestracjeViewModel(objekt));
        }
        private void openDzial(DZI_Dzialy objekt)
        {
            CreateView(new DodajDzialViewModel(objekt));
        }
        private void openDelegacje(DEL_Delegacje objekt)
        {
            CreateView(new DodajDelegacjeViewModel(objekt));
        }
        private void openStrefaCzas(STC_StrefaCzasowa objekt)
        {
            CreateView(new DodajStrefeCzasowaViewModel(objekt));
        }
        private void openKlient(KLI_Klienci objekt)
        {
            CreateView(new DodajKlientaViewModel(objekt));
        }
        private void openKatTowarow(KAT_KategorieTowarow objekt)
        {
            CreateView(new DodajKategorieTowarowViewModel(objekt));
        }
        private void openZdarz(ZDA_Zdarzenia objekt)
        {
            CreateView(new DodajZdarzenieViewModel(objekt));
        }
        private void openGraf(GRP_GrafikPracy objekt)
        {
            CreateView(new DodajGrafikPracyViewModel(objekt));
        }

        private void openWniosekUrlop(WUR_WnioskiUrlopowe objekt)
        {
            CreateView(new DodajWniosekUrlopowyViewModel(objekt));
        }
        private void openTowary(TOW_Towary objekt)
        {
            CreateView(new DodajTowarViewModel(objekt));
        }
        private void openRodzajUrlopu(RUR_RodzajeUrlopow objekt)
        {
            CreateView(new DodajRodzajUrlopuViewModel(objekt));
        }
        

        private void openSpospPlatnosci(SPP_SposobPlatnosci objekt)
        {
            CreateView(new DodajSposobPlatnosciViewModel(objekt));
        }
        private void openJednostkMiary(JEM_JednostkiMiary objekt)
        {
            CreateView(new DodajJednostkiMiaryViewModel(objekt));
        }
        private void openJezykAplikacji(JAP_JezykAplikacji objekt)
        {
            CreateView(new DodajJezykAplikacjiViewModel(objekt));
        }


        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        

        //zeby sie kod nie powtarzal Show all 
        private void ShowAllObjects<T>() where T : WorkspaceViewModel, new()
        {
            T workspace =
            this.Workspaces.FirstOrDefault
            (vm => vm is T)
            as T;
            if (workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        //
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
