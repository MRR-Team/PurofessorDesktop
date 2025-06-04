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

namespace Purofessor.Views.Admin
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Page
    {
        private readonly ApiService _apiService = new ApiService();

        public Stats()
        {
            InitializeComponent();
            Loaded += Stats_Loaded;
        }

        private async void Stats_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var stats = await _apiService.GetChampionSearchStatsAsync();

                // Capitalize first letter
                foreach (var stat in stats)
                {
                    stat.Champion.Name = char.ToUpper(stat.Champion.Name[0]) + stat.Champion.Name.Substring(1);
                }

                StatsListView.ItemsSource = stats.OrderByDescending(s => s.Total).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas pobierania statystyk: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
