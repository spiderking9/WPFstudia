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
using MVVMFirma.ViewModels;

namespace UrlopyApiXaml.ViewModels
{
    //to jest 
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        //to jest 
        private ReadOnlyCollection<CommandViewModel> _Commands;
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
                new CommandViewModel("Urlopy",UrlopyCommand,"\uf030")
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
        //
        //zeby sie kod nie powtarzal  Kontrachent, Przeglad, Faktura
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
