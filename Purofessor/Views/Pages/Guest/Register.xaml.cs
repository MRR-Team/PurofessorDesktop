﻿using System;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Helpers;
using Purofessor.Localization;
using Purofessor.Views.Pages.User;
using Purofessor.Views.Windows.Dialogs;
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
                CustomMessageBox.Show(Messages.FillAllError,Messages.Warning,MessageBoxButton.OK);
                return;
            }

            if (password != confirmPassword)
            {
                CustomMessageBox.Show(Messages.PasswordMismatchError, Messages.Error, MessageBoxButton.OK);
                return;
            }

            try
            {
                bool success = await ApiService.Instance.Auth.RegisterAsync(login, password, email);
                if (success)
                {
                    CustomMessageBox.Show(Messages.RegisterComplete, Messages.Success, MessageBoxButton.OK);
                    var parentWindow = Window.GetWindow(this) as LoginWindow;
                    parentWindow?.LoginFrame.Navigate(new Login());
                }
                else
                {
                    CustomMessageBox.Show(Messages.RegisterFailed, Messages.Error, MessageBoxButton.OK  );
                }
            }
            catch (Exception)
            {
                CustomMessageBox.Show(Messages.RegisterError, Messages.Error, MessageBoxButton.OK);
            }
        }
    }
}
