using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Purofessor.Helpers
{
    public static class LanguageHelper
    {
        public static void SetLang(string lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            string dictPath = $"/Languages/Dictionary-{lang}.xaml";
            var newDict = new ResourceDictionary { Source = new Uri(dictPath, UriKind.Relative) };

            // Znajdujemy i usuwamy istniejący słownik językowy
            for (int i = 0; i < Application.Current.Resources.MergedDictionaries.Count; i++)
            {
                var dict = Application.Current.Resources.MergedDictionaries[i];
                if (dict.Source != null && dict.Source.OriginalString.Contains("/Languages/Dictionary-"))
                {
                    Application.Current.Resources.MergedDictionaries.RemoveAt(i);
                    break;
                }
            }

            // Dodajemy nowy słownik językowy
            Application.Current.Resources.MergedDictionaries.Add(newDict);

            // Zapisujemy język do ustawień
            Properties.Settings.Default.lang = lang;
            Properties.Settings.Default.Save();
        }
    }
}
