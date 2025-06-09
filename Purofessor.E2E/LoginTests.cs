using System;
using System.IO;
using System.Threading;
using FlaUI.Core;
using FlaUI.UIA3;
using FlaUI.Core.AutomationElements;
using Xunit;
using FlaUI.Core.Tools;

namespace Purofessor.E2E
{
    public class LoginTests : IDisposable
    {
        private readonly Application _app;
        private readonly AutomationBase _automation;

        public LoginTests()
        {
            // Ścieżka do zbudowanej aplikacji
            var appPath = Path.GetFullPath(@"..\..\..\..\Purofessor\bin\Debug\net8.0-windows\Purofessor.exe");

            _app = Application.Launch(appPath);
            _automation = new UIA3Automation();
        }

        [Fact]
        public void Login_WithValidCredentials_OpensMainWindow()
        {
            var window = _app.GetMainWindow(_automation);

            // znajdź pola
            var loginBox = window.FindFirstDescendant(cf => cf.ByAutomationId("LoginTextBox"))?.AsTextBox();
            var passwordBox = window.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox(); // PasswordBox może być trudny, zależnie od UIA

            var loginButton = window.FindFirstDescendant(cf => cf.ByAutomationId("LoginButton"))?.AsButton();

            Assert.NotNull(loginBox);
            Assert.NotNull(passwordBox);
            Assert.NotNull(loginButton);

            // podaj dane
            loginBox.Enter("admin@example.com");
            passwordBox.Enter("password");

            loginButton.Invoke();

            // poczekaj na przejście do nowego okna
            Thread.Sleep(2000);

            var allWindows = _app.GetAllTopLevelWindows(_automation);
            var mainWindow = allWindows.FirstOrDefault(w => w.Title.Contains("Purofessor"));

            Assert.NotNull(mainWindow);
        }
        [Fact]
        public void Login_WithInvalidCredentials_ShowsErrorMessageBox()
        {
            var window = _app.GetMainWindow(_automation);

            var usernameBox = window.FindFirstDescendant(cf => cf.ByAutomationId("LoginTextBox"))?.AsTextBox();
            var passwordBox = window.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox();
            var loginButton = window.FindFirstDescendant(cf => cf.ByAutomationId("LoginButton"))?.AsButton();

            Assert.NotNull(usernameBox);
            Assert.NotNull(passwordBox);
            Assert.NotNull(loginButton);

            usernameBox.Enter("invalid_user");
            passwordBox.Enter("wrong_password");
            loginButton.Invoke();

            var errorWindow = Retry.WhileNull(
                () => _app.GetAllTopLevelWindows(_automation)
                          .FirstOrDefault(w => w.Title.Contains("Błąd")),
                TimeSpan.FromSeconds(3)
            ).Result;

            Assert.NotNull(errorWindow);

            var closeButton = errorWindow.FindFirstDescendant(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Button))?.AsButton();
            closeButton?.Invoke();
        }



        public void Dispose()
        {
            _automation.Dispose();
            _app.Close();
        }
    }
}
