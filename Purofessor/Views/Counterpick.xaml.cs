using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Helpers;

namespace Purofessor.Views
{
    public partial class Counterpick : Page
    {
        private List<Champion> _allChampions = new();
        private readonly ApiService _apiService = new();
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
                _allChampions = await _apiService.GetChampionsAsync();
                _autocompleteHelper.SetChampionList(_allChampions);
                _autocompleteHelper.Attach(EnemyChampTextBox, SuggestionsPopup, SuggestionsListBox);
            }
            catch (Exception ex)
            {
                ShowError("Błąd pobierania championów", ex);
            }
        }

        private async void OnGenerateCounterClick(object sender, RoutedEventArgs e)
        {
            string championName = EnemyChampTextBox.Text.Trim();
            string position = GetSelectedPosition();

            if (string.IsNullOrWhiteSpace(championName) || string.IsNullOrWhiteSpace(position))
            {
                ShowMessage("Wpisz nazwę championa i wybierz pozycję.");
                return;
            }

            var champion = _allChampions.FirstOrDefault(c =>
                string.Equals(c.Name, championName, StringComparison.OrdinalIgnoreCase));

            if (champion == null)
            {
                ShowMessage($"Nie znaleziono championa o nazwie: {championName}");
                return;
            }

            try
            {
                var result = await _apiService.GetCounterAsync(position, champion.Id.ToString());
                DisplayCounterResults(result, championName, position);
            }
            catch (Exception ex)
            {
                ShowError("Błąd pobierania danych", ex);
            }
        }

        private void DisplayCounterResults(IEnumerable<string> results, string name, string pos)
        {
            ResultBorder.Visibility = Visibility.Visible;

            if (results == null || !results.Any())
            {
                ResultTextBlock.Text = $"Brak kontr dla {name} ({pos}).";
                return;
            }

            ResultTextBlock.Text = $"Kontry na {name} ({pos}):\n• {string.Join("\n• ", results)}";
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

        private void ShowMessage(string message) => MessageBox.Show(message);
        private void ShowError(string title, Exception ex) => MessageBox.Show($"{title}: {ex.Message}");
    }
}
