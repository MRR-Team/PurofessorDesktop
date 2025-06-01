using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Purofessor.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Counterpick.xaml
    /// </summary>
    public partial class Counterpick : Page
    {
        private List<Champion> _allChampions = new List<Champion>();
        private readonly ApiService _apiService;

        public Counterpick()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Loaded += Champions_Loaded;
        }

        private async void Champions_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _allChampions = await _apiService.GetChampionsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd pobierania championów: " + ex.Message);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string championName = MyTextBox.Text.Trim();
            string position = GetSelectedPosition();

            if (string.IsNullOrEmpty(championName) || string.IsNullOrEmpty(position))
            {
                MessageBox.Show("Wpisz nazwę championa i wybierz pozycję.");
                return;
            }

            // Szukamy championa po nazwie (ignorując wielkość liter)
            var champion = _allChampions.FirstOrDefault(c =>
                string.Equals(c.Name, championName, StringComparison.OrdinalIgnoreCase));

            if (champion == null)
            {
                MessageBox.Show($"Nie znaleziono championa o nazwie: {championName}");
                return;
            }

            try
            {
                // Wysyłamy zapytanie z ID
                var result = await _apiService.GetCounterAsync(position, champion.Id.ToString());

                // Pokazujemy border, nawet jeśli wynik pusty
                ResultBorder.Visibility = Visibility.Visible;

                if (result == null || !result.Any())
                {
                    ResultTextBlock.Text = $"Brak kontr dla {championName} ({position}).";
                    return;
                }

                var formattedResult = string.Join("\n", result.Select(r => "• " + r));
                ResultTextBlock.Text = $"Kontry na {championName} ({position}):\n{formattedResult}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd pobierania danych: " + ex.Message);
            }
        }

        private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string typedText = MyTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(typedText))
            {
                SuggestionsPopup.IsOpen = false;
                return;
            }

            var filtered = _allChampions
                .Where(c => c.Name.ToLower().Contains(typedText))
                .Select(c => char.ToUpper(c.Name[0]) + c.Name.Substring(1)) // Wielka litera
                .ToList();

            if (filtered.Any())
            {
                SuggestionsListBox.ItemsSource = filtered;
                SuggestionsPopup.IsOpen = true;
            }
            else
            {
                SuggestionsPopup.IsOpen = false;
            }
        }

        private void SuggestionsListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SuggestionsListBox.SelectedItem != null)
            {
                MyTextBox.Text = SuggestionsListBox.SelectedItem.ToString();
                SuggestionsPopup.IsOpen = false;
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Tu chyba nieużywane – można usunąć, jeśli zbędne
        }
    }
}
