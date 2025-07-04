﻿using Purofessor.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Views.Windows.Guest;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Localization;

namespace Purofessor.components.PanelComponents
{
    public partial class LogoutButton : UserControl
    {
        public LogoutButton()
        {
            InitializeComponent();
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await App.ApiService.Auth.LogoutAsync();
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                Window.GetWindow(this)?.Close();


            }
            catch (Exception)
            {
                CustomMessageBox.Show(Messages.LogoutFailed, Messages.Error, MessageBoxButton.OK);
            }
        }
    }
}
