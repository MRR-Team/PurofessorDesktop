using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Purofessor.Helpers
{
    public static class ThemeHelper
    {
        public static void SetTheme(string themeFile)
        {
            if (string.IsNullOrWhiteSpace(themeFile))
            {
                themeFile = "DarkTheme.xaml";
            }

            var dict = new ResourceDictionary
            {
                Source = new Uri($"Themes/{themeFile}", UriKind.Relative)
            };

            // Usuń poprzedni motyw
            var existingThemeDict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.StartsWith("Themes/"));

            if (existingThemeDict != null)
                Application.Current.Resources.MergedDictionaries.Remove(existingThemeDict);

            // Dodaj nowy motyw
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
