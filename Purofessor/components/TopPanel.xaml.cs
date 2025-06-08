using Purofessor.Views.Pages.User;
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
using Purofessor.Properties;
using Purofessor.Views.Windows.Guest;
using Purofessor.Views.Windows.Dialogs;

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
            DataContext = App.ApiService;
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

        private void ShowRotations_Click(object sender, RoutedEventArgs e)
        {
            SetActiveTab(ShowRotationsButton);
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new ShowRotations());
        }
        private void SetActiveTab(Button newActiveButton)
        {
            if (newActiveButton != null && newActiveButton != _previousTabButton)
            {
                if (_previousTabButton != null)
                {
                    _previousTabButton.BorderThickness = new Thickness(0, 0, 0, 2);
                }
                newActiveButton.BorderThickness = new Thickness(0, 0, 0, 3);
                _previousTabButton = newActiveButton;
            }
            else
            {
                _previousTabButton.BorderThickness = new Thickness(0, 0, 0, 2);
                return;
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
                CustomMessageBox.Show($"Błąd podczas wylogowywania: {ex.Message}");
            }
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            SetActiveTab(null);
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new Profile());

        }
        private void BuildMaker_Click(object sender, RoutedEventArgs e)
        {
            SetActiveTab(BuildMakerButton);
            var parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow?.MainFrame.Navigate(new BuildMaker());


        }
    }
}