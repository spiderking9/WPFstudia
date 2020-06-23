using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml;

namespace UrlopyApiXaml.ViewModels
{
    public class PracownicyViewModel : WorkspaceViewModel //bo wszystkie zakladki dziedzicza po WorkSpaceViewModel
    {
        #region Konstruktor
        public PracownicyViewModel()
        {
            base.DisplayName = "Pracownicy";
        }
        #endregion

    }
}
