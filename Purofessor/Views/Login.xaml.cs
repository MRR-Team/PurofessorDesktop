﻿using Microsoft.Win32;
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

namespace Purofessor.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            try
            {
                // używamy globalnego ApiService
                string token = await App.ApiService.LoginAsync(login, password);

                var user = App.ApiService.LoggedUser;

                // sprawdzenie roli
                if (user.is_admin)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }

                // zamknij okno logowania
                Window.GetWindow(this)?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd logowania:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterLink_Click(object sender, RoutedEventArgs e)
        {
            // Załaduj stronę rejestracji
            this.NavigationService?.Navigate(new Register());
        }
        private void GuestLink_Click(object sender, RoutedEventArgs e)
        {
            // Załaduj stronę gościa
            GuestWindow GuestWindow = new GuestWindow();
            GuestWindow.Show();

            Window.GetWindow(this)?.Close();
        }
    }
}
