using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Purofessor
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        private void ThemeToggle_Checked(object sender, RoutedEventArgs e)
        {
            ApplyTheme("DarkTheme.xaml");
        }

        private void ThemeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ApplyTheme("LightTheme.xaml");
        }

        private void ApplyTheme(string themeFile)
        {
            var dict = new ResourceDictionary();
            dict.Source = new Uri($"Themes/{themeFile}", UriKind.Relative);

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
