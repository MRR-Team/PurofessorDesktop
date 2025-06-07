using System;
using System.Windows;
using Purofessor.Models;
using Purofessor.Helpers;

namespace Purofessor.Views.Windows.Admin
{
    public partial class AdminUserEditWindow : Window
    {
        private readonly ApiService _apiService;
        private readonly User _user;

        public AdminUserEditWindow(ApiService apiService, User user)
        {
            InitializeComponent();
            _apiService = apiService;
            _user = user;

            NameTextBox.Text = _user.name;
            EmailTextBox.Text = _user.email;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text.Trim();
                string email = EmailTextBox.Text.Trim();
                string password = PasswordBox.Password.Trim();

                bool updated = await _apiService.UpdateUserAsync(_user.id, name, email, password);

                if (updated)
                {
                    MessageBox.Show("Użytkownik zaktualizowany.");
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować użytkownika.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas aktualizacji: {ex.Message}");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
