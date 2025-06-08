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

namespace Purofessor.Views.Windows.Dialogs
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        private bool? _result = null;

        public CustomMessageBox(string message, string title, MessageBoxButton buttons, MessageBoxImage icon)
        {
            InitializeComponent();
            this.Title = title;
            MessageText.Text = message;

            switch (buttons)
            {
                case MessageBoxButton.OK:
                    OkButton.Visibility = Visibility.Visible;
                    break;

                case MessageBoxButton.YesNo:
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.Visibility = Visibility.Visible;
                    break;
            }

            // Ikony możesz obsłużyć np. dodając Image w XAML
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            _result = true;
            this.DialogResult = _result;
            this.Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            _result = true;
            this.DialogResult = _result;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            _result = false;
            this.DialogResult = _result;
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove(); // pozwala przeciągać okno
            }
        }

        public static bool? Show(string message, string title = "Informacja", MessageBoxButton buttons = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None)
        {
            var box = new CustomMessageBox(message, title, buttons, icon);
            return box.ShowDialog();
        }
    }

}
