using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Models;
using Purofessor.Helpers;

namespace Purofessor.Views.Pages.Admin
{
    /// <summary>
    /// Interaction logic for Logs.xaml
    /// </summary>
    public partial class Logs : Page
    {
        public Logs()
        {
            InitializeComponent();
            _ = LoadLogsAsync();
        }

        private async Task LoadLogsAsync()
        {
            try
            {
                var logs = await ApiService.Instance.Users.GetLogsAsync();
                LogsDataGrid.ItemsSource = logs; // <- Zmienione z LogsListView na LogsDataGrid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd wczytywania logów:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
