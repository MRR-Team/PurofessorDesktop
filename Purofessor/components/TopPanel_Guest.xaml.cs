using Purofessor.Views;
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
using Purofessor.Views.Windows.Guest;
using Purofessor.Views.Pages.User;
using Purofessor.Helpers;
using Purofessor.Views.Windows.Dialogs;

namespace Purofessor.components
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class TopPanel_Guest : UserControl
    {
        private Button? _previousTabButton;

        public TopPanel_Guest()
        {
            InitializeComponent();
            _previousTabButton = KontraButton;
        }

        private void Kontra_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(KontraButton, ref _previousTabButton);
            (Window.GetWindow(this) as GuestWindow)?.GuestFrame.Navigate(new Counterpick());
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(StatusButton, ref _previousTabButton);
            (Window.GetWindow(this) as GuestWindow)?.GuestFrame.Navigate(new ServerStatus());
        }

        private void ShowRotations_Click(object sender, RoutedEventArgs e)
        {
            ActiveButtonHelper.SetActiveTab(ShowRotationsButton, ref _previousTabButton);
            (Window.GetWindow(this) as GuestWindow)?.GuestFrame.Navigate(new ShowRotations());
        }

        private void LoginLink_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}
