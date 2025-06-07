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
using System.Windows.Shapes;
using Purofessor.Views.Windows.Admin;

namespace Purofessor
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            var user = App.ApiService.LoggedUser;
            if (user != null && user.IsAdmin)
            {
                AdminButton.Visibility = Visibility.Visible;
            }
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
{
    // Zamknij wszystkie inne okna
    foreach (Window window in Application.Current.Windows)
    {
        if (window != this) // nie zamykamy okna admina, bo jeszcze go nie otworzyliśmy
        {
            window.Close();
        }
    }

    // Otwórz AdminWindow
    AdminWindow adminWindow = new AdminWindow();
    adminWindow.Show();

    // Zamknij to okno (SettingsWindow)
    this.Close();
}
    }
}
