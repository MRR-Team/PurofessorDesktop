using System.Windows;

namespace Purofessor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Views.Counterpick());
        }


    }
}
