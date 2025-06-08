using System;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Helpers;
using Purofessor.Views.Pages.User;
using Purofessor.Views.Windows.Guest;

namespace Purofessor.Views.Pages.Guest
{
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void LoginLink_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new Login());
        }

        private void GuestLink_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();

            Window.GetWindow(this)?.Close();
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordHintText.Visibility = Visibility.Visible;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordHintText.Visibility = Visibility.Collapsed;
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Wypełnij wszystkie pola.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Hasła nie są takie same.");
                return;
            }

            try
            {
                bool success = await ApiService.Instance.RegisterAsync(login, password, email);
                if (success)
                {
                    MessageBox.Show("Rejestracja zakończona sukcesem! Wysłaliśmy do ciebie maila w celu weryfikacji");
                    var parentWindow = Window.GetWindow(this) as LoginWindow;
                    parentWindow?.LoginFrame.Navigate(new Login());
                }
                else
                {
                    MessageBox.Show("Rejestracja nie powiodła się. Sprawdź dane.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas rejestracji: {ex.Message}");
            }
        }
    }
}
