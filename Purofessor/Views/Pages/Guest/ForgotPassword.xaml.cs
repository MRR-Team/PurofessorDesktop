using Purofessor.Helpers;
using Purofessor.Views.Pages.Admin;
using Purofessor.Views.Pages.Guest;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Localization;

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

            if (string.IsNullOrWhiteSpace(email)|| !email.Contains('@'))
            {
                CustomMessageBox.Show(Messages.EnterVaildEmail, Messages.Warning);
                return;
            }

            try
            {
                await ApiService.Instance.Auth.SendResetLinkAsync(email); 
                CustomMessageBox.Show(Messages.PasswordResetMail, Messages.Success,MessageBoxButton.OK);
                NavigationService?.Navigate(new Login());
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Messages.PasswordResetMailError, Messages.Error, MessageBoxButton.OK);
            }
        }

        private void BackToLoginLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Login());
        }
    }
}
