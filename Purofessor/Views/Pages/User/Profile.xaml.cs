using Purofessor.Views.Windows.Dialogs;
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

namespace Purofessor.Views.Pages.User
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private readonly ApiService _apiService = App.ApiService;
        public Profile()
        {
            InitializeComponent();
            var user = App.ApiService.LoggedUser;

            if (user != null)
            {
                UsernameTextBox.Text = user.Name;
                EmailTextBox.Text = user.Email;
            }
            else
            {
                CustomMessageBox.Show("Nie jesteś zalogowany!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            try
            {

                bool success = await _apiService.UpdateUserAsync(_apiService.LoggedUser.Id, username, email, password);

                if (success)
                {
                    _apiService.LoggedUser.Name = username;
                    _apiService.LoggedUser.Email = email;
                    CustomMessageBox.Show("Dane zostały zaktualizowane!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CustomMessageBox.Show("Nie udało się zaktualizować danych.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
