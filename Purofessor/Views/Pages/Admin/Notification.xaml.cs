using System;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Helpers;
using Purofessor.Localization;
using Purofessor.Views.Windows.Dialogs;

namespace Purofessor.Views.Pages.Admin
{
    public partial class Notification : Page
    {
        private readonly UserApi _userApi;

        public Notification()
        {
            InitializeComponent();

            // Załaduj ApiService z kontenera lub singletona jak masz
            _userApi = new UserApi(App.ApiService);
        }

        private async void SendNotification_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text.Trim();
            string body = BodyTextBox.Text.Trim();
            string? type = (TypeComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString()?.ToLower();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(type))
            {
                CustomMessageBox.Show(Messages.FillAllError, Messages.Warning, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var success = await _userApi.SendNotificationAsync(title, body, type);

                if (success)
                {
                    CustomMessageBox.Show(Messages.NotificationSent, Messages.Success, MessageBoxButton.OK, MessageBoxImage.Information);
                    TitleTextBox.Clear();
                    BodyTextBox.Clear();
                    TypeComboBox.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
                CustomMessageBox.Show(Messages.NotificationError, Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
