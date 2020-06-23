using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    //to
    public class CommandViewModel : BaseViewModel
    {
        //
        #region Properties
        public ICommand Command { get; private set; }
        #endregion

        #region Constructor
        public CommandViewModel(string displayName, ICommand command, string displayIcon)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            DisplayName = displayName;
            DisplayIcon = displayIcon;
            Command = command;
        }
        #endregion

    }
}
