using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UrlopyApiXaml.ViewModels;
using UrlopyApiXaml.ViewModels.Zakladki;

namespace UrlopyApiXaml.Views.Zakladki
{
    /// <summary>
    /// Logika interakcji dla klasy DelegacjeView.xaml
    /// </summary>
    public partial class DelegacjeView : UserControl
    {
        public DelegacjeView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajDelegacjeWindowView win2 = new DodajDelegacjeWindowView
            {
                Title = "Dodaj Delegacje",
                Content = new DodajDelegacjeView(),
                Height = 500,
                Width= 500
            };
            win2.ShowDialog();
        }
    }
}
