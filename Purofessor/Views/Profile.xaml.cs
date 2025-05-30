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

namespace Purofessor.Views
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
                UsernameTextBox.Text = user.name;
                EmailTextBox.Text = user.email;
            }
            else
            {
                MessageBox.Show("Nie jesteś zalogowany!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            try
            {
                if (_apiService.LoggedUser == null)
                {
                    MessageBox.Show("Musisz być zalogowany, aby zaktualizować profil.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                bool success = await _apiService.UpdateUserAsync(_apiService.LoggedUser.id, username, email, password);

                if (success)
                {
                    _apiService.LoggedUser.name = username;
                    _apiService.LoggedUser.email = email;
                    MessageBox.Show("Dane zostały zaktualizowane!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować danych.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
