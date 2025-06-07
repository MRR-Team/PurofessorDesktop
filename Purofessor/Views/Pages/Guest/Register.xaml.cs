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
using Purofessor.Helpers;
using Purofessor.Views.Windows.Guest;

namespace Purofessor.Views.Pages.Guest
{

    public partial class Register : Page
    {
        private readonly ApiService _apiService;

        public Register()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }
        private void LoginLink_Click(object sender, RoutedEventArgs e)
        {
            // Załaduj stronę rejestracji
            this.NavigationService?.Navigate(new Login());
        }
        private void GuestLink_Click(object sender, RoutedEventArgs e)
        {
            // Załaduj stronę gościa
            GuestWindow GuestWindow = new GuestWindow();
            GuestWindow.Show();

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
                bool success = await _apiService.RegisterAsync(login, password, email);
                if (success)
                {
                    MessageBox.Show("Rejestracja zakończona sukcesem!");
                    // Możesz tutaj przejść do strony logowania, np. NavigationService.Navigate(...)
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