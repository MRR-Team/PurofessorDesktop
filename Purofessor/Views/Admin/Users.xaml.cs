using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Models;

namespace Purofessor.Views.Admin
{
    public partial class Users : Page
    {
        private readonly ApiService _apiService = new();
        private List<User> _allUsers = new();

        public Users()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _allUsers = await _apiService.GetUsersAsync();
                UsersDataGrid.ItemsSource = _allUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania użytkowników: {ex.Message}");
            }
        }

        private async void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is User selectedUser)
            {
                var editWindow = new AdminUserEditWindow(_apiService, selectedUser);
                bool? result = editWindow.ShowDialog();

                if (result == true)
                {
                    try
                    {
                        _allUsers = await _apiService.GetUsersAsync();
                        UsersDataGrid.ItemsSource = null;
                        UsersDataGrid.ItemsSource = _allUsers;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd odświeżania listy: {ex.Message}");
                    }
                }
            }
        }
    }
}
