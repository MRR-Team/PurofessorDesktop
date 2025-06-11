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

namespace Purofessor.components
{
    /// <summary>
    /// Interaction logic for ToastContainer.xaml
    /// </summary>
    public partial class ToastContainer : UserControl
    {
        public static ToastContainer Instance { get;  set; }

        public ToastContainer()
        {
            InitializeComponent();
            Instance = this;
        }

        public void ShowNotification(string title, string message)
        {
            var toast = new ToastNotification(title, message);
            NotificationPanel.Children.Insert(0, toast);
        }
    }
}
