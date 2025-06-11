using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using Purofessor.Helpers;
using Purofessor.Properties;
using Purofessor.Views.Windows.Guest;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Localization;

namespace Purofessor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ApiService? ApiService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {

            LanguageHelper.SetLang(Settings.Default.lang);

            ApiService = ApiService.Instance;
            base.OnStartup(e);
            InternetCheckHelper.InternetUnavailable += OnInternetUnavailable;
        }
        private void OnInternetUnavailable()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                CustomMessageBox.Show(Messages.ConnectionLost,
                                Messages.NoConnection, MessageBoxButton.OK, MessageBoxImage.Warning);

                var loginWindow = new LoginWindow();
                loginWindow.Show();

                // Zamknij wszystkie inne okna
                foreach (var window in Current.Windows)
                {
                    if (window is Window w && w is not LoginWindow)
                        w.Close();
                }
            });
        }
    }
}
