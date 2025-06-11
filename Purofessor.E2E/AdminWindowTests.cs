using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using Xunit;
using System.IO;
using System.Linq;

namespace Purofessor.E2E
{
    public class AdminWindowTests : IDisposable
    {
        private readonly Application _app;
        private readonly UIA3Automation _automation;
        public AdminWindowTests()
        {
            var appPath = Path.GetFullPath(@"..\..\..\..\Purofessor\bin\Debug\net8.0-windows\Purofessor.exe");
            _app = Application.Launch(appPath);
            _automation = new UIA3Automation();
        }
        [Fact]
        public void AdminPanel_Displayed_WhenAdminClicks()
        {
            LogInAndOpenAdminPanel(out var adminWindow);

            // Sprawdzamy, czy okno admina istnieje i ma tytuł "Admin"
            Assert.NotNull(adminWindow);
            Assert.Contains("Admin", adminWindow.Title);
        }

        public void Dispose()
        {
            _automation.Dispose();
            _app.Close();
        }
        private void DumpAllAutomationIds(Window window)
        {
            var elements = window.FindAllDescendants();
            foreach (var e in elements)
            {
                if (!string.IsNullOrEmpty(e.AutomationId))
                {
                    Console.WriteLine($"Id: {e.AutomationId}, Name: {e.Name}, Type: {e.ControlType}");
                }
            }
        }
        [Fact]
        public void AdminPanel_Loads_LogsPage_WhenLogsButtonClicked()
        {
            LogInAndOpenAdminPanel(out var adminWindow);

            var logsButton = adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("LogsButton"))?.AsButton();
            Assert.NotNull(logsButton);
            logsButton.Invoke();

            var logsGrid = Retry.WhileNull(
                () => adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("LogsDataGrid")),
                TimeSpan.FromSeconds(5)
            ).Result;

            Assert.NotNull(logsGrid);
        }

        [Fact]
        public void AdminPanel_Loads_StatsPage_WhenStatsButtonClicked()
        {
            LogInAndOpenAdminPanel(out var adminWindow);

            var statsButton = adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("StatsButton"))?.AsButton();
            Assert.NotNull(statsButton);
            statsButton.Invoke();

            var statsGrid = Retry.WhileNull(
                () => adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("StatsDataGrid")),
                TimeSpan.FromSeconds(5)
            ).Result;

            Assert.NotNull(statsGrid);
        }

        [Fact]
        public void AdminPanel_Loads_UsersPage_WhenUsersButtonClicked()
        {
            LogInAndOpenAdminPanel(out var adminWindow);

            var usersButton = adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("UsersButton"))?.AsButton();
            Assert.NotNull(usersButton);
            usersButton.Invoke();

            var usersGrid = Retry.WhileNull(
                () => adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("UsersDataGrid")),
                TimeSpan.FromSeconds(5)
            ).Result;

            Assert.NotNull(usersGrid);
        }
        [Fact]
        public void AdminPanel_Loads_RotationPage_WhenRotationButtonClicked()
        {
            LogInAndOpenAdminPanel(out var adminWindow);

            var rotationButton = adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("RotationButton"))?.AsButton();
            Assert.NotNull(rotationButton);
            rotationButton.Invoke();

            var championList = Retry.WhileNull(
                () => adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("ChampionListBox")),
                TimeSpan.FromSeconds(5)
            ).Result;

            Assert.NotNull(championList);
        }
        [Fact]
        public void AdminPanel_Loads_NotificationPage_WhenNotificationButtonClicked()
        {
            LogInAndOpenAdminPanel(out var adminWindow);

            var notificationButton = adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("NotificationButton"))?.AsButton();
            Assert.NotNull(notificationButton);
            notificationButton.Invoke();

            var titleTextBox = Retry.WhileNull(
                () => adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("TitleTextBox")),
                TimeSpan.FromSeconds(5)
            ).Result;
            var bodyTextBox = adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("BodyTextBox"));
            var typeComboBox = adminWindow.FindFirstDescendant(cf => cf.ByAutomationId("TypeComboBox"));

            Assert.NotNull(titleTextBox);
            Assert.NotNull(bodyTextBox);
            Assert.NotNull(typeComboBox);
        }

        private void LogInAndOpenAdminPanel(out Window adminWindow)
        {
            var loginWindow = _app.GetMainWindow(_automation);

            loginWindow.FindFirstDescendant(cf => cf.ByAutomationId("LoginTextBox"))?.AsTextBox()
                       ?.Enter("admin@example.com");
            loginWindow.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox()
                       ?.Enter("password");
            loginWindow.FindFirstDescendant(cf => cf.ByAutomationId("LoginButton"))?.AsButton()
                       ?.Invoke();

            var mainWindow = Retry.WhileNull(
                () =>
                {
                    var w = _app.GetMainWindow(_automation);
                    return w.FindFirstDescendant(cf => cf.ByAutomationId("SettingsButton")) != null ? w : null;
                },
                TimeSpan.FromSeconds(10)
            ).Result;

            var settingsButton = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("SettingsButton"))?.AsButton();
            Assert.NotNull(settingsButton);
            settingsButton.Focus();
            var point = settingsButton.TryGetClickablePoint(out var p) ? p : throw new Exception("SettingsButton not clickable");
            FlaUI.Core.Input.Mouse.Click(p);

            var settingsWindow = Retry.WhileNull(
                () => _app.GetAllTopLevelWindows(_automation)
                          .FirstOrDefault(w => w.Title.Contains("Ustawienia") || w.Title.Contains("Settings")),
                TimeSpan.FromSeconds(5)
            ).Result;
            Assert.NotNull(settingsWindow);

            var adminButton = settingsWindow.FindFirstDescendant(cf => cf.ByAutomationId("AdminButton"))?.AsButton();
            Assert.NotNull(adminButton);
            adminButton.Invoke();

            adminWindow = Retry.WhileNull(
                () => _app.GetAllTopLevelWindows(_automation)
                          .FirstOrDefault(w => w.Title.Contains("Admin")),
                TimeSpan.FromSeconds(5)
            ).Result;
            Assert.NotNull(adminWindow);
        }

    }
}
