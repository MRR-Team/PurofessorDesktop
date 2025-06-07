using Purofessor.Helpers;
using Purofessor.Models;
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
            _apiService = new ApiService();
            _autocompleteHelper = new ChampionAutocompleteHelper();
            Loaded += BuildMaker_Loaded;
        }

        private async void BuildMaker_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _champions = await _apiService.GetChampionsAsync();

                _autocompleteHelper.SetChampionList(_champions);
                _autocompleteHelper.Attach(MyChampionTextBox, MyChampPopup, MyChampSuggestions);
                _autocompleteHelper.Attach(EnemyChampionTextBox, EnemyChampPopup, EnemyChampSuggestions);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd pobierania championów: " + ex.Message);
            }
        }

        private async void GenerateBuild_Click(object sender, RoutedEventArgs e)
        {
            string myChampion = MyChampionTextBox.Text.Trim();
            string enemyChampion = EnemyChampionTextBox.Text.Trim();

            if (string.IsNullOrEmpty(myChampion) || string.IsNullOrEmpty(enemyChampion))
            {
                MessageBox.Show("Wprowadź nazwę obu championów.");
                return;
            }

            var myChamp = _champions.FirstOrDefault(c => c.Name.Equals(myChampion, StringComparison.OrdinalIgnoreCase));
            var enemyChamp = _champions.FirstOrDefault(c => c.Name.Equals(enemyChampion, StringComparison.OrdinalIgnoreCase));

            if (myChamp == null || enemyChamp == null)
            {
                MessageBox.Show("Nie znaleziono jednego z championów.");
                return;
            }

            try
            {
                var buildItems = await _apiService.GetBuildAsync(enemyChamp.Id.ToString(), myChamp.Id.ToString());

                ResultBorder.Visibility = Visibility.Visible;

                if (buildItems == null || !buildItems.Any())
                {
                    ResultTextBlock.Text = "Brak rekomendowanych przedmiotów.";
                    return;
                }

                var text = string.Join("\n", buildItems.Select(i => "• " + i));
                ResultTextBlock.Text = $"Sugerowany build dla {myChampion} przeciwko {enemyChampion}:\n{text}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd generowania builda: " + ex.Message);
            }
        }
    }
}
