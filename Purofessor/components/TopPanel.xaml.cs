using Purofessor.Views.Pages.User;
using System;
using System.Windows;
using System.Windows.Controls;
using Purofessor.Helpers;
using Purofessor.Views.Windows.Guest;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Views.Windows.User;

namespace Purofessor.components
{
    /// <summary>
    /// Logika interakcji dla klasy TopPanel.xaml
    /// </summary>
    public partial class TopPanel : UserControl
    {
        private Button? _previousTabButton;

        public TopPanel()
        {
            InitializeComponent();
            DataContext = App.ApiService;
            _previousTabButton = KontraButton;
        }

        private void Kontra_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(KontraButton, ref _previousTabButton);
            (Window.GetWindow(this) as MainWindow)?.MainFrame.Navigate(new Counterpick());
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(StatusButton, ref _previousTabButton);
            (Window.GetWindow(this) as MainWindow)?.MainFrame.Navigate(new ServerStatus());
        }

        private void ShowRotations_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(ShowRotationsButton, ref _previousTabButton);
            (Window.GetWindow(this) as MainWindow)?.MainFrame.Navigate(new ShowRotations());
        }

        private void BuildMaker_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(BuildMakerButton, ref _previousTabButton);
            (Window.GetWindow(this) as MainWindow)?.MainFrame.Navigate(new BuildMaker());
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(null, ref _previousTabButton); // clear highlight
            (Window.GetWindow(this) as MainWindow)?.MainFrame.Navigate(new Profile());
        }
        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new NotificationWindow();
            window.Show();
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }
    }
}
