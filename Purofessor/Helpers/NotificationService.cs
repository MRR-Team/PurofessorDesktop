using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Purofessor.components;

namespace Purofessor.Helpers
{
    public static class NotificationService
    {
        public static void Notify(string title, string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ToastContainer.Instance?.ShowNotification(title, message);
            });
        }
    }
}
