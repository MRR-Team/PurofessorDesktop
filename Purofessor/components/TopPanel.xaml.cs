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
using Purofessor.Helpers;

namespace Purofessor.components
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class TopPanel : UserControl
    {
        private Button _previousTabButton;
        public TopPanel()
        {
            InitializeComponent();
            _previousTabButton = KontraButton;
            LanguageHelper.SetLang(Properties.Settings.Default.lang);
        }

        private void Kontra_Click(object sender, RoutedEventArgs e)
        {
            SetActiveTab(KontraButton);
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new Counterpick());
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            SetActiveTab(StatusButton);
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new ServerStatus());
        }
        private void SetActiveTab(Button newActiveButton)
        {
            if (newActiveButton != _previousTabButton)
            {
                if (_previousTabButton != null)
                {
                    _previousTabButton.BorderThickness = new Thickness(0, 0, 0, 2);
                }
                newActiveButton.BorderThickness = new Thickness(0, 0, 0, 3);
                _previousTabButton = newActiveButton;
            }
        }
        private void LangBtns_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string lang)
            {
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
                LanguageHelper.SetLang(lang);
            }
            else
            {
                MessageBox.Show("Language change error.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
    }
}
