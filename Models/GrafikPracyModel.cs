using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UrlopyApiXaml.Models
{
    public class GrafikPracyModel
    {
        public GrafikPracyModel()
        {

        }
        public List<DataLista> Lista(int LiczOd = 2, int LiczDo = 10)
        {
            List<User> listaUserowNaglowek = new List<User>();
            
            for (int i = LiczOd; i <= LiczDo; ++i)
            {
                listaUserowNaglowek.Add(new User { ID = i, Name = i.ToString() });
            }
            List<DataLista> dataLista = new List<DataLista>(); 
            

            //tutaj przypisalem naglowek tabeli
            dataLista.Add(new DataLista { Nazwisko = "Nazwisko", Lists = listaUserowNaglowek });


            //przykladowe bebechy rekordu
            List<User> listaBebechy = new List<User>();
            listaBebechy.Add(new User {ID=3,Name="sdfsdfsd" });
            listaBebechy.Add(new User { ID = 5, Name = "123123" });
            listaBebechy.Add(new User { ID = 11, Name = "aaaaaaaa" });
            listaBebechy.Add(new User { ID = 13, Name = "zzzzzzzzz" });

            //przykladowy rekord
            dataLista.Add(new DataLista { Nazwisko = "Mariusz Macierewicz", Lists = listaBebechy });

            return dataLista;
        }


        public class DataLista
        {
            public String Nazwisko { get; set; }
            public List<User> Lists { get; set; }
        }
        public class User
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return this.Name.ToString();
            }
        }



        public class TableDataRow
        {
            public TableDataRow(List<string> cells)
            {
                Cells = cells;
            }

            public List<string> Cells { get; }
        }

        public class TableData
        {
            public TableData(List<string> columnHeaders, List<TableDataRow> rows)
            {
                for (int i = 0; i < rows.Count; i++)
                    //if (rows[i].Cells.Count != columnHeaders.Count)
                    //    throw new ArgumentException(nameof(rows));

                ColumnHeaders = columnHeaders;
                Rows = rows;
            }

            public List<string> ColumnHeaders { get; }
            public List<TableDataRow> Rows { get; }
        }

        public List<string> Naglowki()
        {

            //naglowki lista           columnHeader
            List<string> ListaNaglowkow = new List<string>();
            ListaNaglowkow.Add("Nazwisko");
            ListaNaglowkow.Add("1");
            ListaNaglowkow.Add("2");
            ListaNaglowkow.Add("3");
            ListaNaglowkow.Add("4");
            ListaNaglowkow.Add("5");
            ListaNaglowkow.Add("6");
            ListaNaglowkow.Add("7");
            ListaNaglowkow.Add("8");
            ListaNaglowkow.Add("9");
            ListaNaglowkow.Add("10");
            ListaNaglowkow.Add("11");
            ListaNaglowkow.Add("12");
            ListaNaglowkow.Add("13");
            ListaNaglowkow.Add("14");
            ListaNaglowkow.Add("15");
            ListaNaglowkow.Add("16");
            ListaNaglowkow.Add("17");
            ListaNaglowkow.Add("18");
            ListaNaglowkow.Add("19");
            ListaNaglowkow.Add("20");
            ListaNaglowkow.Add("21");
            ListaNaglowkow.Add("22");
            ListaNaglowkow.Add("23");
            ListaNaglowkow.Add("24");
            ListaNaglowkow.Add("25");
            ListaNaglowkow.Add("26");
            ListaNaglowkow.Add("27");
            ListaNaglowkow.Add("28");
            ListaNaglowkow.Add("29");
            ListaNaglowkow.Add("30");

            return ListaNaglowkow;
        }
        public List<TableDataRow> Wiersze()
        {

            //lista wierszy z listami komorek
            List<TableDataRow> ListazListaWierwszy = new List<TableDataRow>();

            List<string> ListaWiersz1111 = new List<string>();
            ListaWiersz1111.Add("Jakubiak");
            ListaWiersz1111.Add("222222");
            ListaWiersz1111.Add("3333");
            ListaWiersz1111.Add("23423");
            ListaWiersz1111.Add("333werwe3");
            ListaWiersz1111.Add("333sdfsd3");
            ListaWiersz1111.Add("33sdfs33");


            List<string> ListaWiersz22222 = new List<string>();
            ListaWiersz22222.Add("Karol");
            ListaWiersz22222.Add("22dfgdf2222");
            ListaWiersz22222.Add("333werwe3");
            ListaWiersz22222.Add("333sdfsd3");
            ListaWiersz22222.Add("33aa33");
            ListaWiersz22222.Add("23423");
            ListaWiersz22222.Add("33sdfs33");


            TableDataRow wwww = new TableDataRow(ListaWiersz1111);
            TableDataRow wwww2 = new TableDataRow(ListaWiersz22222);

            ListazListaWierwszy.Add(wwww);
            ListazListaWierwszy.Add(wwww2);
            ListazListaWierwszy.Add(wwww);
            ListazListaWierwszy.Add(wwww2);
            ListazListaWierwszy.Add(wwww);
            ListazListaWierwszy.Add(wwww2);
            ListazListaWierwszy.Add(wwww);
            ListazListaWierwszy.Add(wwww2);

            return ListazListaWierwszy;
        }


    }
}
