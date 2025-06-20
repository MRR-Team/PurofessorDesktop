﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Models;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Helpers;
using Purofessor.Localization;

namespace Purofessor.Views.Pages.Admin
{
    public partial class Rotations : Page
    {
        private List<Champion>? _champions;
        
        public Rotations()
        {
            InitializeComponent();
            LoadChampions();
        }

        private async void LoadChampions()
        {
            try
            {
                _champions = await ApiService.Instance.Champions.GetChampionsAsync();
                ChampionListBox.ItemsSource = _champions.OrderBy(c => c.Name).ToList();
            }
            catch
            {
                CustomMessageBox.Show(Messages.ShowChampionsError, Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void OnCheckboxToggled(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is int id)
            {
                try
                {
                    bool success = await ApiService.Instance.Champions.ToggleChampionAvailabilityAsync(id);
                    if (!success)
                    {
                        CustomMessageBox.Show(Messages.UpdateRotationError , Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                        
                        var champ = _champions?.FirstOrDefault(c => c.Id == id);
                        if (champ != null) champ.IsAvailable = !champ.IsAvailable;
                        ChampionListBox.Items.Refresh();
                    }
                }
                catch
                {
                    CustomMessageBox.Show(Messages.UpdateRotationError, Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                    ChampionListBox.Items.Refresh();
                }
            }
        }
    }
}
