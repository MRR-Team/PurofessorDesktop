using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Models;
using Purofessor.Views.Windows.Admin;
using Purofessor.Views.Windows.Dialogs;
using UserModel = Purofessor.Models.User;

namespace Purofessor.Views.Pages.Admin
{
    public partial class Users : Page
    {
        private List<UserModel> _allUsers = new();

        public Users()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _allUsers = await ApiService.Instance.GetUsersAsync();
                UsersDataGrid.ItemsSource = _allUsers;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Błąd ładowania użytkowników: {ex.Message}");
            }
        }

        private async void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is UserModel selectedUser)
            {
                var editWindow = new AdminUserEditWindow(ApiService.Instance, selectedUser);
                bool? result = editWindow.ShowDialog();

                if (result == true)
                {
                    try
                    {
                        _allUsers = await ApiService.Instance.GetUsersAsync();
                        UsersDataGrid.ItemsSource = null;
                        UsersDataGrid.ItemsSource = _allUsers;
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"Błąd odświeżania listy: {ex.Message}");
                    }
                }
            }
        }

        private async void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is UserModel selectedUser)
            {
                var confirm = CustomMessageBox.Show(
                    $"Czy na pewno chcesz usunąć użytkownika '{selectedUser.Name}'?",
                    "Potwierdzenie",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (confirm == true)
                {
                    try
                    {
                        await ApiService.Instance.DeleteUserAsync(selectedUser.Id);
                        _allUsers = await ApiService.Instance.GetUsersAsync();
                        UsersDataGrid.ItemsSource = null;
                        UsersDataGrid.ItemsSource = _allUsers;
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"Błąd podczas usuwania użytkownika: {ex.Message}");
                    }
                }
            }
        }

    }
}
