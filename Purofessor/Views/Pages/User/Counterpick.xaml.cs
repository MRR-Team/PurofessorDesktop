using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Helpers;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Localization;

namespace Purofessor.Views.Pages.User
{
    public partial class Counterpick : Page
    {
        private List<Champion> _allChampions = new();
        private readonly ChampionAutocompleteHelper _autocompleteHelper = new();

        public Counterpick()
        {
            InitializeComponent();
            Loaded += OnChampionsLoaded;
        }

        private async void OnChampionsLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _allChampions = await ApiService.Instance.Champions.GetChampionsAsync();
                _autocompleteHelper.SetChampionList(_allChampions);
                _autocompleteHelper.Attach(EnemyChampTextBox, SuggestionsPopup, SuggestionsListBox);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Messages.DownloadChampionsError);
            }
        }

        private async void OnGenerateCounterClick(object sender, RoutedEventArgs e)
        {
            string championName = EnemyChampTextBox.Text.Trim();
            string position = GetSelectedPosition();

            if (string.IsNullOrWhiteSpace(championName) || string.IsNullOrWhiteSpace(position))
            {
                CustomMessageBox.Show(Messages.EnterChampionAndPosition, Messages.Warning, MessageBoxButton.OK);
                return;
            }

            var champion = _allChampions.FirstOrDefault(c =>
                string.Equals(c.Name, championName, StringComparison.OrdinalIgnoreCase));

            if (champion == null)
            {
                CustomMessageBox.Show(Messages.ChampionNotFound + $"{championName}", Messages.Warning, MessageBoxButton.OK);
                return;
            }

            try
            {
                var result = await ApiService.Instance.Champions.GetCounterAsync(position, champion.Id.ToString());
                DisplayCounterResults(result, championName, position);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Messages.CounterGetError, Messages.Error, MessageBoxButton.OK);
            }
        }

        private void DisplayCounterResults(IEnumerable<string> results, string name, string pos)
        {
            ResultScrollViewer.Visibility = Visibility.Visible;

            var championItems = results.Select(r => new
            {
                Name = r,
                IconUrl = $"https://cdn.purofessor.com/champions/icons/{r}.png" // lub ścieżka z API
            });

            CounterResultsItemsControl.ItemsSource = championItems;
        }

        private string GetSelectedPosition()
        {
            if (RadioSupp.IsChecked == true) return "support";
            if (RadioBottom.IsChecked == true) return "bottom";
            if (RadioMid.IsChecked == true) return "mid";
            if (RadioJungle.IsChecked == true) return "jungle";
            if (RadioTop.IsChecked == true) return "top";
            return null;
        }


    }
}
