﻿using System;
using System.Windows.Controls;
using Purofessor.Models;

namespace Purofessor.Views.Pages.User
{
    public partial class ServerStatus : Page
    {
        public ServerStatus()
        {
            InitializeComponent();
        }

        private async void RegionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RegionComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string? region = selectedItem.Content?.ToString();
                if (string.IsNullOrWhiteSpace(region))
                {
                    StatusTextBlock.Text = "Nie wybrano regionu.";
                    return;
                }

                region = region.ToLowerInvariant(); // 🔻 Zamiana na małe litery

                try
                {
                    var status = await App.ApiService.Champions.GetServerStatusAsync(region);
                    StatusTextBlock.Text = $"Region: {status.Name} ({status.Id})\n" +
                                           $"Lokalizacje: {string.Join(", ", status.Locales ?? Enumerable.Empty<string>())}\n" +
                                           $"Maintenance: {status.Maintenances?.Count ?? 0}, Incidents: {status.Incidents?.Count ?? 0}";
                }
                catch (Exception ex)
                {
                    StatusTextBlock.Text = $"Błąd pobierania statusu: {ex.Message}";
                }
            }
        }

    }
}
