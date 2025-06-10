using System.Windows;
using System.Windows.Controls;
using Purofessor.Views.Pages.Admin;
using Purofessor.Views.Windows.Admin;
using Purofessor.Helpers;

namespace Purofessor.components
{
    public partial class TopPanel_Admin : UserControl
    {
        private Button? _previousTabButton;

        public TopPanel_Admin()
        {
            InitializeComponent();
            _previousTabButton = RotationButton;
        }

        private void Rotation_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(RotationButton, ref _previousTabButton);
            NavigateTo(new Rotations());
        }

        private void Logs_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(LogsButton, ref _previousTabButton);
            NavigateTo(new Logs());
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(StatsButton, ref _previousTabButton);
            NavigateTo(new Stats());
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(UsersButton, ref _previousTabButton);
            NavigateTo(new Users());
        }

        private void Notify_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(NotifyButton, ref _previousTabButton);
            NavigateTo(new Notification());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this)?.Close();
        }

        private void NavigateTo(Page page)
        {
            var parentWindow = Window.GetWindow(this) as AdminWindow;
            parentWindow?.MainFrame.Navigate(page);
        }
    }
}
