using System.Windows;
using System.Windows.Controls;
using Purofessor.Helpers;

namespace Purofessor.components.PanelComponents
{
    public partial class LangSelector : UserControl
    {
        public LangSelector()
        {
            InitializeComponent();

            string currentLang = Properties.Settings.Default.lang;
            foreach (ComboBoxItem item in LanguageComboBox.Items)
            {
                if ((string)item.Tag == currentLang)
                {
                    LanguageComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag is string lang)
            {
                LanguageHelper.SetLang(lang);
                Properties.Settings.Default.lang = lang;
                Properties.Settings.Default.Save();
            }
        }
    }
}
