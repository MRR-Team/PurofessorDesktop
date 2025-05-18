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
using System.Text.Json;

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
            var user = App.ApiService.LoggedUser;
            if (user != null)
            {
                string ProfileButtonHi = ProfileButton.Content?.ToString() ?? "Welcome";
                ProfileButton.Content = $"{ProfileButtonHi}, {user.Name}";
            }
            else
            {
                ProfileButton.Content = "Profil";
            }
            LanguageHelper.SetLang(Properties.Settings.Default.lang);
            foreach (ComboBoxItem item in LanguageSelector.Items)
            {
                if ((string)item.Tag == Properties.Settings.Default.lang)
                {
                    LanguageSelector.SelectedItem = item;
                    break;
                }
            }
            _previousTabButton = KontraButton;

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
        private void LanguageSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageSelector.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag is string lang)
            {
                LanguageHelper.SetLang(lang);

                // Save language choice to settings if needed
                Properties.Settings.Default.lang = lang;
                Properties.Settings.Default.Save();
            }
        }
        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await App.ApiService.LogoutAsync(); // jeśli masz ApiService jako singleton/globalnie dostępny

                // Przekieruj użytkownika na stronę logowania lub zamknij okno
                var loginWindow = new LoginWindow();
                loginWindow.Show();

                // Zamknij aktualne okno główne (np. MainWindow)
                Window.GetWindow(this)?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wylogowywania: {ex.Message}");
            }
        }

    }
}
