using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace UrlopyApiXaml.Views
{
    public class DodajUsunEdytujOdswiezViewBase : UserControl
    {
        static DodajUsunEdytujOdswiezViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DodajUsunEdytujOdswiezViewBase), new FrameworkPropertyMetadata(typeof(DodajUsunEdytujOdswiezViewBase)));

        }
    }
}
