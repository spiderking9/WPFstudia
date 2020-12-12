using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Helper;
using System.Windows.Input;
using UrlopyApiXaml.ViewModels;

namespace UrlopyApiXaml
{
    //to ...
    public abstract class WorkspaceViewModel : BaseViewModel
    {
        //kaz...
        #region Fields
        private BaseCommand _CloseCommand;
        #endregion 

        #region Constructor
        public WorkspaceViewModel()
        {
        }
        #endregion 

        #region CloseCommand
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => OnRequestClose());
                return _CloseCommand;
            }
        }
        #endregion 

        #region RequestClose [event]
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion 
    }
}
