using Purofessor.Models;
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
using Purofessor.Helpers;

namespace Purofessor.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Counterpick.xaml
    /// </summary>
    public partial class Counterpick : Page
    {
        private List<string> _allChampions = new List<string>();

        private readonly ApiService _apiService;
        public Counterpick()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Loaded += Champions_Loaded;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string champion = MyTextBox.Text.Trim();
            string position = GetSelectedPosition();

            if (string.IsNullOrEmpty(champion) || string.IsNullOrEmpty(position))
            {
                MessageBox.Show("Wpisz nazwę championa i wybierz pozycję.");
                return;
            }

            try
            {
                var result = await _apiService.GetCounterAsync(position, champion);
                ResultTextBlock.Text = $"Kontry na {champion} ({position}):\n" + string.Join(", ", result);
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
                SuggestionsListBox.Visibility = Visibility.Collapsed;
                return;
            }

            var filtered = _allChampions
                .Where(c => c.ToLower().Contains(typedText))
                .ToList();

            if (filtered.Any())
            {
                SuggestionsListBox.ItemsSource = filtered;
                SuggestionsListBox.Visibility = Visibility.Visible;
            }
            else
            {
                SuggestionsListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void SuggestionsListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SuggestionsListBox.SelectedItem != null)
            {
                MyTextBox.Text = SuggestionsListBox.SelectedItem.ToString();
                SuggestionsListBox.Visibility = Visibility.Collapsed;
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
    }
}
