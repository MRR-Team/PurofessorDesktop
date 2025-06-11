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
            MainFrame.Navigate(new Counterpick());

        }


    }
}
