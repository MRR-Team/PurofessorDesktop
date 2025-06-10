using Purofessor.Helpers;
using Purofessor.Views.Pages.Guest;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Purofessor.Views.Pages.Guest
{
    public partial class ForgotPassword : Page
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private async void SendResetLinkButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Podaj poprawny adres e-mail.");
                return;
            }

            try
            {
                await ApiService.Instance.Auth.SendResetLinkAsync(email); MessageBox.Show("Sprawdź skrzynkę – wysłaliśmy link do resetu hasła.");
                NavigationService?.Navigate(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się wysłać linku.\n{ex.Message}");
            }
        }

        private void BackToLoginLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Login());
        }
    }
}
