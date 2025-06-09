using Purofessor.Helpers;
using Purofessor.Models;
using Purofessor.Views.Windows.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Purofessor.Views.Pages.User
{
    public partial class BuildMaker : Page
    {
        private List<Champion> _champions;
        private readonly ApiService _apiService;
        private readonly ChampionAutocompleteHelper _autocompleteHelper;

        public BuildMaker()
        {
            InitializeComponent();
            _autocompleteHelper = new ChampionAutocompleteHelper();
            Loaded += BuildMaker_Loaded;
        }

        private async void BuildMaker_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _champions = await ApiService.Instance.Champions.GetChampionsAsync();

                _autocompleteHelper.SetChampionList(_champions);
                _autocompleteHelper.Attach(MyChampionTextBox, MyChampPopup, MyChampSuggestions);
                _autocompleteHelper.Attach(EnemyChampionTextBox, EnemyChampPopup, EnemyChampSuggestions);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Błąd pobierania championów: " + ex.Message);
            }
        }

        private async void GenerateBuild_Click(object sender, RoutedEventArgs e)
        {
            string myChampion = MyChampionTextBox.Text.Trim();
            string enemyChampion = EnemyChampionTextBox.Text.Trim();

            if (string.IsNullOrEmpty(myChampion) || string.IsNullOrEmpty(enemyChampion))
            {
                CustomMessageBox.Show("Wprowadź nazwę obu championów.");
                return;
            }

            var myChamp = _champions.FirstOrDefault(c => c.Name.Equals(myChampion, StringComparison.OrdinalIgnoreCase));
            var enemyChamp = _champions.FirstOrDefault(c => c.Name.Equals(enemyChampion, StringComparison.OrdinalIgnoreCase));

            if (myChamp == null || enemyChamp == null)
            {
                CustomMessageBox.Show("Nie znaleziono jednego z championów.");
                return;
            }

            try
            {
                var buildItems = await ApiService.Instance.Champions.GetBuildAsync(enemyChamp.Id.ToString(), myChamp.Id.ToString());

                ResultScrollViewer.Visibility = Visibility.Visible;

                if (buildItems == null || !buildItems.Any())
                {
                    BuildResultsItemsControl.ItemsSource = null;
                    CustomMessageBox.Show("Brak rekomendowanych przedmiotów.");
                    return;
                }

                var buildItemList = buildItems.Select(item => new
                {
                    Name = item,
                    IconUrl = $"https://cdn.purofessor.com/items/icons/{item}.png" // dopasuj URL do realnej struktury
                });

                BuildResultsItemsControl.ItemsSource = buildItemList;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Błąd generowania builda: " + ex.Message);
            }
        }
    }
}
