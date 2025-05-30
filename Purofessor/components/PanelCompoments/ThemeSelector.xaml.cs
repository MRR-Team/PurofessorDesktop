using Purofessor.Helpers;
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

namespace Purofessor.components.PanelComponents
{
    public partial class ThemeSelector : UserControl
    {
        public ThemeSelector()
        {
            InitializeComponent();

            // Pobierz aktualny motyw z ustawień i ustaw zaznaczenie
            string currentTheme = Properties.Settings.Default.theme;
            foreach (ComboBoxItem item in ThemeComboBox.Items)
            {
                if ((string)item.Tag == currentTheme)
                {
                    ThemeComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag is string themeFile)
            {
                // Ustaw motyw
                ThemeHelper.SetTheme(themeFile);

                // Zapisz motyw w ustawieniach
                Properties.Settings.Default.theme = themeFile;
                Properties.Settings.Default.Save();
            }
        }
    }
}