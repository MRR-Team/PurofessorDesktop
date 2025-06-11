using System;
using System.Windows;
using Purofessor.Models;
using Purofessor.Helpers;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Localization;

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

            NameTextBox.Text = _user.Name;
            EmailTextBox.Text = _user.Email;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text.Trim();
                string email = EmailTextBox.Text.Trim();
                string password = PasswordBox.Password.Trim();
                string confirmPassword = ConfirmPasswordBox.Password.Trim();

                if (!string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(confirmPassword))
                {
                    if (password != confirmPassword)
                    {
                        CustomMessageBox.Show(Messages.PasswordMismatchError, Messages.Error, MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                bool updated = await _apiService.Users.UpdateUserAsync(_user.Id, name, email, password);

                if (updated)
                {
                    CustomMessageBox.Show(Messages.DataUpdated, Messages.Success, MessageBoxButton.OK);
                    DialogResult = true;
                    Close();
                }
                else
                {
                    CustomMessageBox.Show(Messages.DataUpdatedFailed);
                }
            }
            catch (Exception)
            {
                CustomMessageBox.Show(Messages.DataUpdatedError, Messages.Error, MessageBoxButton.OK);
            }
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
