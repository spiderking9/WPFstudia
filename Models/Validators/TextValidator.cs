using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.Models.Validators
{
    public class TextValidator: ValidationRule
    {
        public static string MusiszWpisacMax50Znakow(string text)
        {
            if (text == null || text.Length == 0 || text.Length>50)
                return "Wpisz wartosc pozycji, nie wiecej niz 50 znakow";
            return null;
        }
        public static string Max50Znakow(string text)
        {
            if (text == null || text.Length == 0 || text.Length > 50)
                return "Wpisz wartosc pozycji, nie wiecej niz 50 znakow";
            return null;
        }
        public static string Max100Znakow(string text)
        {
            if (text == null || text.Length == 0 || text.Length > 100)
                return "Wpisz wartosc pozycji, nie wiecej niz 100 znakow";
            return null;
        }
        public static string Max127Znakow(string text)
        {
            if (text == null || text.Length == 0 || text.Length > 127)
                return "Wpisz wartosc pozycji, nie wiecej niz 127 znakow";
            return null;
        }
        public static string Max10Znakow(string text)
        {
            if (text==null || text.Length==0 || text.Length > 10)
                return "Wpisz wartosc pozycji, nie wiecej niz 10 znakow";
            return null;
        }
        public static string Max20Znakow(string text)
        {
            if (text == null || text.Length == 0 || text.Length > 20)
                return "Wpisz wartosc pozycji, nie wiecej niz 20 znakow";
            return null;
        }
        public static string Max255Znakow(string text)
        {
            if (text == null || text.Length == 0 || text.Length > 255)
                return "Wpisz wartosc pozycji, nie wiecej niz 255 znakow";
            return null;
        }
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if (char.IsLower(wartosc, 0))
                {
                    return "Rozpocznij duża litera";
                }
            }
            catch (Exception)
            {

            };
            return null;
        }
        public static string SprawdzCzyPoprawnyNrTel(string text)
        {
            Regex EmailRegex = new Regex(@"^(\+48)?\d{9}$");
            if (text == null || !EmailRegex.IsMatch(text))
                return "Wpisz poprawny nr telefonu";
            return null;
        }
        public static string PoprawnaDataWnioskuUrlopowego(DateTime dataOd, DateTime dataDo)
        {
            if ((dataOd - dataDo).TotalDays > 0 && (dataOd - DateTime.Today).TotalDays > 0 && (dataDo - DateTime.Today).TotalDays > 0)
                return "Wpisz date przyszla, tak aby start byl rowny lub mniejszy od konca";
            return null;
        }
        public static string PoprawnaDataUrlopu(DateTime dataOd, DateTime dataDo)
        {
            if ((dataOd - dataDo).TotalDays>0)
                return "Roznica dni jest mniejsza ";
            return null;
        }

        public static string PoprawnaDataDelegacji(DateTime dataOd, DateTime dataDo)
        {
            if ((dataOd - dataDo).TotalDays > 0)
                return "Sprawdz obie daty delegacji";
            return null;
        }

        public static string Zmiana123(string text)
        {
            if (text == null || text.Length == 0 || text !="1"|| text != "2" || text != "3")
                return "Wpisz zmiane 1 , 2 lub 3";
            return null;
        }
        
        public static string SprawdzKluczObcyInt(int text)
        {
            if (text == 0)
                return "Wpisz zmiane 1 , 2 lub 3";
            return null;
        }
        public static string SprawdzKluczObcy<T>(string key, T defaultValue)
        {
            if (defaultValue == null)
                return "Nie wybrano elementu";
            return null;
        }

        public static string IloscSztuk(int ilosc)
        {
            if (ilosc<0 && ilosc%10!=0)
                return "Podaj ilosc, nie moze byc ulamkiem i mniejsze od zera";
            return null;
        }
        public static string SpradzDecimal(decimal ilosc)
        {
            if (ilosc <= 0 && ilosc % 0.01m == 0m)
                return "Podaj ilosc, nie moze byc ulamkiem i mniejsze od zera";
            return null;
        }


        public static string ValidateEmail(string email)
        {
            try
            {
                Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (email == null || !EmailRegex.IsMatch(email))
                    return "Podaj poprawny format emaila";
            }
            catch (Exception)
            {

            };
            return null;

        }
        public static string ValidateKodPocztowy(string kod)
        {
            Regex EmailRegex = new Regex(@"/^[0-9]{2}-[0-9]{3}$/");
            if (kod == null ||  !EmailRegex.IsMatch(kod))
                return "Podaj poprawny format emaila";

            return null;
        }
        public static string ValidateLoginCzyNieDubel(string login, UrlopyEntities bazaDanych,int idEdytowanego)
        {
            var czyPowtorka = bazaDanych.PRA_Pracownicy.FirstOrDefault(x => x.PRA_ILogin == login) !=null && bazaDanych.PRA_Pracownicy.FirstOrDefault(x => x.PRA_ILogin == login).PRA_PraID!=idEdytowanego;
            if (czyPowtorka)
                return "Zmien login, juz ktos taki ma";

            return null;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i;
            if (int.TryParse(value.ToString(), out i))
                return new ValidationResult(true, CultureInfo.CurrentCulture);

            return new ValidationResult(false, "sdfsdfsdf");
        }
    }
}
