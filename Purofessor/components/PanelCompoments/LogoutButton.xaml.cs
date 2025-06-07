using Purofessor.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Views.Windows.Guest;

namespace Purofessor.components.PanelComponents
{
    public partial class LogoutButton : UserControl
    {
        public LogoutButton()
        {
            InitializeComponent();
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await App.ApiService.LogoutAsync();

                var loginWindow = new LoginWindow();
                loginWindow.Show();

                Window.GetWindow(this)?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wylogowywania: {ex.Message}");
            }
        }
    }
}
