using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Models;
using Purofessor.Views.Windows.Admin;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Helpers;
using UserModel = Purofessor.Models.User;
using Purofessor.Localization;

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
                _allUsers = await ApiService.Instance.Users.GetUsersAsync();
                UsersDataGrid.ItemsSource = _allUsers;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Messages.FailedLoadingUsers, Messages.Error, MessageBoxButton.OK);
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
                        _allUsers = await ApiService.Instance.Users.GetUsersAsync();
                        UsersDataGrid.ItemsSource = null;
                        UsersDataGrid.ItemsSource = _allUsers;
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show(Messages.FailedRefreshingList, Messages.Error, MessageBoxButton.OK);
                    }
                }
            }
        }

        private async void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is UserModel selectedUser)
            {
                var confirm = CustomMessageBox.Show(
                    Messages.DeleteUserWarning, Messages.Warning,
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (confirm == true)
                {
                    try
                    {
                        await ApiService.Instance.Users.DeleteUserAsync(selectedUser.Id);
                        _allUsers = await ApiService.Instance.Users.GetUsersAsync();
                        UsersDataGrid.ItemsSource = null;
                        UsersDataGrid.ItemsSource = _allUsers;
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show(Messages.DeleteUserError, Messages.Error, MessageBoxButton.OK);
                    }
                }
            }
        }

    }
}
