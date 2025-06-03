using System.Windows;
using System.Windows.Controls;
using Purofessor.Views;
using Purofessor.Views.Admin;

namespace Purofessor.components
{
    public partial class TopPanel_Admin : UserControl
    {
        public TopPanel_Admin()
        {
            InitializeComponent();
        }

        private void Rotation_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new Rotations());
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new Stats());
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new Users());
        }

        private void Notify_Click(object sender, RoutedEventArgs e)
        {
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
