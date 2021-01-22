using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UrlopyApiXaml.Helper;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.ViewModels
{
    public abstract class NowyViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        protected UrlopyEntities urlopyApiXaml;
        protected T item;
        //komenda do zapisu towaru
        private BaseCommand _SaveCommand;
        #endregion Fields

        #region Constructor
        public NowyViewModel()
        {
            urlopyApiXaml = new UrlopyEntities();
        }
        #endregion Constructor

        #region Command

        //to jest komenda ktora zostanie podpieta pod przycisk Zapisz i wywola metode SaveAndClose 
        //ktora bedzie zdefiniowana nizej 
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                }
                return _SaveCommand;
            }
        }
        #endregion Command
        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }

        #endregion

        #region Helpers
        public abstract void Save();
        private void SaveAndClose()
        {
            if (IsValid())
            {
                Save();
                ShowMessageBox("Dokument  został  zapisany  do  bazy");
                OnRequestClose();
            }
            else
            {
                ShowMessageBox("Popraw Błędy");
            }
        }
        #endregion Helpers

    }
}
