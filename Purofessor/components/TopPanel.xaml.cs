using Purofessor.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Globalization;
using System.Security.Policy;

namespace Purofessor.components
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class TopPanel : UserControl
    {
        public TopPanel()
        {
            InitializeComponent();
        }

        private void Kontra_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new Counterpick());
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new ServerStatus());
        }

        private void LangBtns_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string lang)
            {
                SetLang(lang);
            }
            else
            {
                MessageBox.Show("Language change error.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void SetLang(String lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            Application.Current.Resources.MergedDictionaries.Clear();
            ResourceDictionary resdict = new ResourceDictionary()
            {
                Source = new Uri($"/Languages/Dictionary-{lang}.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(resdict);
            EnglishBtn.IsEnabled = true;
            PolishBtn.IsEnabled = true;
            switch (lang) 
            { 
                case "en":
                    EnglishBtn.IsEnabled = false;
                    break;
                case "pl":
                    PolishBtn.IsEnabled = false;
                    break;

            }
        }
    }
}
