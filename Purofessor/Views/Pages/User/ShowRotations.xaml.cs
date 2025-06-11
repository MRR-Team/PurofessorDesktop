using System.Windows;
using System.Windows.Controls;
using Purofessor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Helpers;
using Purofessor.Localization;

namespace Purofessor.Views.Pages.User
{
    public partial class ShowRotations : Page
    {
        private readonly ApiService _apiService = App.ApiService;

        public ShowRotations()
        {
            InitializeComponent();
            Loaded += ShowRotations_Loaded;
        }

        private async void ShowRotations_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var champions = await _apiService.Champions.GetFreeRotationAsync();
                RotationListBox.ItemsSource = champions;
            }
            catch (Exception)
            {
                CustomMessageBox.Show(Messages.RotationShowError, Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
