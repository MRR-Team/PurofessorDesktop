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
using Purofessor.Helpers;
using Purofessor.Views.Windows.Guest;
using Purofessor.Localization;

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
                CustomMessageBox.Show(Messages.YoureNotloggedin,Messages.Error, MessageBoxButton.OK, MessageBoxImage.Warning);
                Window parentWindow = Window.GetWindow(this);
                var loginWindow = new LoginWindow();
                loginWindow.Show();
            }

        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (password != confirmPassword)
            {
                CustomMessageBox.Show(Messages.PasswordMismatchError, Messages.Warning, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var user = _apiService.LoggedUser;
            if (user is null)
            {
                CustomMessageBox.Show(Messages.YoureNotloggedin,
                                      Messages.Warning,
                                      MessageBoxButton.OK,
                                      MessageBoxImage.Warning);
                return;
            }
            try
            {
                bool success = await _apiService.Users.UpdateUserAsync(user.Id, username, email, password);

                if (success)
                {
                    user.Name = username;
                    user.Email = email;
                    CustomMessageBox.Show(Messages.DataUpdated, Messages.Success, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CustomMessageBox.Show(Messages.DataUpdatedFailed, Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                CustomMessageBox.Show(Messages.DataUpdatedError, Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
