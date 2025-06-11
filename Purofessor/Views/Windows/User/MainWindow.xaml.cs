using System.Windows;
using Purofessor.components;
using Purofessor.Views.Pages.User;

namespace Purofessor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ToastContainer.Instance = ToastOverlay; // <-- to musi być
            MainFrame.Navigate(new Counterpick());

        }


    }
}
