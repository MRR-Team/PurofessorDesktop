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
    /// Interaction logic for ToastNotification.xaml
    /// </summary>
    public partial class ToastNotification : UserControl
    {
        public ToastNotification(string title, string message, int durationMs = 3000)
        {
            InitializeComponent();
            DataContext = new { Title = title, Message = message };
            _ = AutoHideAsync(durationMs);
        }

        private async Task AutoHideAsync(int delay)
        {
            await Task.Delay(delay);
            (this.Parent as Panel)?.Children.Remove(this);
        }
    }

}
