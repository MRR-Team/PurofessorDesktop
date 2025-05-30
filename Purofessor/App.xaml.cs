using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using Purofessor.Helpers;
using Purofessor.Properties;

namespace Purofessor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ApiService ApiService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {

            LanguageHelper.SetLang(Settings.Default.lang);

            ApiService = new ApiService();

            base.OnStartup(e);
        }
    }
}
