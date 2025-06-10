using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Views.Windows.Guest;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Helpers.Modules.Strategies; // dodaj to

namespace Purofessor.Views.Pages.Guest
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            try
            {
                var strategy = new EmailPasswordLoginStrategy(App.ApiService, login, password);
                string? token = await App.ApiService.Auth.LoginAsync(strategy);

                if (!string.IsNullOrEmpty(token))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Window.GetWindow(this)?.Close();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Błąd logowania:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterLink_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new Register());
        }

        private void GuestLink_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();
            Window.GetWindow(this)?.Close();
        }

        private async void GoogleLoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var strategy = new GoogleLoginStrategy(App.ApiService);
                string? token = await App.ApiService.Auth.LoginAsync(strategy);

                if (!string.IsNullOrEmpty(token))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Window.GetWindow(this)?.Close();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Błąd logowania przez Google:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ForgotPassword());
        }
    }
}
