using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Purofessor.Models;
using System.Windows;
using System.Threading.Tasks;
using Purofessor.Helpers;

namespace Purofessor.Views.Windows.User;

public partial class NotificationWindow : Window
{
    public NotificationWindow()
    {
        InitializeComponent();
        LoadNotifications();
    }

    private async void LoadNotifications()
    {
        try
        {
            List<Notification> notifications = await ApiService.Instance.Users.GetNotificationsAsync();
            NotificationsDataGrid.ItemsSource = notifications;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd ładowania powiadomień", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
