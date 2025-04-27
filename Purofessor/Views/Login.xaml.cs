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

namespace Purofessor.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string haslo = PasswordBox.Password;

            if (LoginTextBox.Text == "admin" && PasswordBox.Password == "1234")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                Window.GetWindow(this)?.Close(); 
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło!");
            }
        }
    }
}
