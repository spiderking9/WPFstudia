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
using UrlopyApiXaml.Views;

namespace UrlopyApiXaml.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PracownicyView.xaml
    /// </summary>
    public partial class PracownicyView : Filtrowanie1ViewBase
    {
        PracownicyViewModel viewModel;
        public PracownicyView()
        {
            InitializeComponent();
            //DataContextChanged += new DependencyPropertyChangedEventHandler(PracownicyViewModel_DataContextChanged);

        }
        //public void PracownicyViewModel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    List<DockPanel> listOfButtons = new List<DockPanel>();
        //    viewModel = (PracownicyViewModel)this.DataContext;

        //    int x = 0;
        //    if (viewModel == null) return;
        //    foreach (var item in viewModel.List)
        //    {
        //        DockPanel w = new DockPanel();
        //        Button edit = new Button();
        //        Label imieNazwisko = new Label();
        //        Label dzial = new Label();
        //        dzial.Content = item.NazwaDzialu;
        //        w.Style = (Style)this.FindResource("dzieckoStackPanel");
        //        if(x==1) w.SetValue(Grid.RowProperty, 0);
        //        else w.SetValue(Grid.RowProperty, x);
        //        imieNazwisko.Content = item.ImieNazwisko;
        //        edit.Content = "button" + x;

        //        w.Children.Add(imieNazwisko);
        //        w.Children.Add(dzial);
        //        w.Children.Add(edit);

        //        //b.Background = Brushes.Blue;
        //        //b.Margin= new Thickness(10, 10, 10, 0);
        //        //b.Height = 30;
        //        listOfButtons.Add(w);
        //        x++;
        //    }

        //    ic.ItemsSource = listOfButtons;
        //}
    }
}
