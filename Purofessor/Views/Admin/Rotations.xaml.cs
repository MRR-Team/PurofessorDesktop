using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Models;

namespace Purofessor.Views.Admin
{
    public partial class Rotations : Page
    {
        private readonly ApiService _apiService = new ApiService();
        private List<Champion> _champions;

        public Rotations()
        {
            InitializeComponent();
            LoadChampions();
        }

        private async void LoadChampions()
        {
            try
            {
                _champions = await _apiService.GetChampionsAsync();
                ChampionListBox.ItemsSource = _champions.OrderBy(c => c.Name).ToList();
            }
            catch
            {
                MessageBox.Show("Nie udało się pobrać championów.");
            }
        }

        private async void OnCheckboxToggled(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is int id)
            {
                try
                {
                    bool success = await _apiService.ToggleChampionAvailabilityAsync(id);
                    if (!success)
                    {
                        MessageBox.Show("Nie udało się zaktualizować rotacji.");
                        // cofnij zmianę checkboxa
                        var champ = _champions.FirstOrDefault(c => c.Id == id);
                        if (champ != null) champ.IsAvailable = !champ.IsAvailable;
                        ChampionListBox.Items.Refresh();
                    }
                }
                catch
                {
                    MessageBox.Show("Wystąpił błąd przy aktualizacji rotacji.");
                }
            }
        }
    }
}
