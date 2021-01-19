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
        private BaseCommand _DelegacjeCommand;
        public ICommand DelegacjeCommand
        {
            get
            {
                if (_DelegacjeCommand == null)
                    _DelegacjeCommand = new BaseCommand(() => CreateView(new DelegacjeViewModel()));
                return _DelegacjeCommand;
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
           // Messenger.Default.Register<ZDA_Zdarzenia>(this, openZdarz);


            return new List<CommandViewModel>
            {
                new CommandViewModel("DodajGrafikPracy",new BaseCommand(() => this.CreateView(new DodajGrafikPracyViewModel())),"\uf2bb"),
                new CommandViewModel("DodajPracownika",new BaseCommand(() => this.CreateView(new DodajPracownikaViewModel())),"\uf2cd"),
                new CommandViewModel("DodajFakture",new BaseCommand(() => this.CreateView(new DodajFaktureViewModel())),"\uf1f3"),
                new CommandViewModel("DodajUrlopy",DodajUrlopyCommand,"\uf030"),
                new CommandViewModel("DodajJezykApp",new BaseCommand(() => this.CreateView(new DodajJezykAplikacjiViewModel())),"\uf2cd"),
                new CommandViewModel("DodajJednMiary",new BaseCommand(() => this.CreateView(new DodajJednostkiMiaryViewModel())),"\uf2cd"),
                new CommandViewModel("DodajKatTowar",new BaseCommand(() => this.CreateView(new DodajKategorieTowarowViewModel())),"\uf1f3"),
                new CommandViewModel("DodajKlienta",new BaseCommand(() => this.CreateView(new DodajKlientaViewModel())),"\uf1f3"),
                new CommandViewModel("DodajPozycjeFaktury",new BaseCommand(() => this.CreateView(new DodajPozycjeFakturViewModel())),"\uf2cd"),
                new CommandViewModel("DodajRodzajUrlopu",new BaseCommand(() => this.CreateView(new DodajRodzajUrlopuViewModel())),"\uf2cd"),
                new CommandViewModel("DodajSposobPlatnosci",new BaseCommand(() => this.CreateView(new DodajSposobPlatnosciViewModel())),"\uf2cd"),
                new CommandViewModel("DodajTowar",new BaseCommand(() => this.CreateView(new DodajTowarViewModel())),"\uf2cd"),
                new CommandViewModel("DodajWniosekUrlop",new BaseCommand(() => this.CreateView(new DodajWniosekUrlopowyViewModel())),"\uf2cd")
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
                new CommandViewModel("Faktura",NowaFakturaCommand,"\uf1f3"),
                new CommandViewModel("Lokalizacje",LokalizacjeCommand,"\uf030"),
                new CommandViewModel("Urlopy",UrlopyCommand,"\uf030"),
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
                CreateView(new DodajWniosekUrlopowyViewModel());
            if (name == "PokazListeWnioskowUrlopowych")
                ShowAllObjects<ListaWnioskowUrlopowychViewModel>();
            if (name == "DodajZdarzenie")
                CreateView(new DodajZdarzenieViewModel(null));
            if (name == "EdytujPracownika")
                CreateView(new DodajPracownikaViewModel());
            if (name == "ShowTowarPF")
                ShowAllObjects<TowaryViewModel>();
            if (name == "ShowFakturyPF")
                ShowAllObjects<FakturyViewModel>();
            if (name == "ShowJednostkaMiaryPF")
                ShowAllObjects<JednostkiMiaryViewModel>();
        }
        private void openZdarz(object objekt)
        {
                CreateView(new DodajZdarzenieViewModel(objekt as ZDA_Zdarzenia));
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
