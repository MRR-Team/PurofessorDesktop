using System;
using System.IO;
using System.Linq;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using Xunit;

namespace Purofessor.E2E
{
    public class CheckRotationTests : IDisposable
    {
        private readonly Application _app;
        private readonly UIA3Automation _automation;

        public CheckRotationTests()
        {
            var appPath = Path.GetFullPath(@"..\..\..\..\Purofessor\bin\Debug\net8.0-windows\Purofessor.exe");
            _app = Application.Launch(appPath);
            _automation = new UIA3Automation();
        }

        [Fact]
        public void ShowRotation_DisplaysChampions()
        {
            var loginWindow = _app.GetMainWindow(_automation);
            Assert.NotNull(loginWindow);
            loginWindow.FindFirstDescendant(cf => cf.ByAutomationId("LoginTextBox"))?.AsTextBox()
                       ?.Enter("admin@example.com");
            loginWindow.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox()
                       ?.Enter("password");
            loginWindow.FindFirstDescendant(cf => cf.ByAutomationId("LoginButton"))?.AsButton()
                       ?.Invoke();

            var mainWindow = Retry.WhileNull(
                () => {
                    var w = _app.GetMainWindow(_automation);
                    return w != null && w.FindFirstDescendant(cf => cf.ByAutomationId("ShowRotationsButton")) != null ? w : null;
                },
                TimeSpan.FromSeconds(10)
            ).Result;

            Assert.NotNull(mainWindow);

            var rotationButton = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("ShowRotationsButton"))?.AsButton();
            Assert.NotNull(rotationButton);
            rotationButton.Invoke();

            // 🔍 znajdź Frame, zakładamy że ma x:Name="MainFrame"
            var mainFrame = Retry.WhileNull(
                () => mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("MainFrame")),
                TimeSpan.FromSeconds(5)
            ).Result;
            Assert.NotNull(mainFrame);

            // ⏳ czekamy na załadowanie zawartości strony wewnątrz frame
            var rotationListBox = Retry.WhileNull(
                () => mainFrame.FindFirstDescendant(cf => cf.ByAutomationId("RotationListBox")),
                TimeSpan.FromSeconds(10)
            ).Result;

            Assert.NotNull(rotationListBox);

            var rotationItemsResult = Retry.While(
                () => rotationListBox!.FindAllChildren(), // użyj `!` do wyciszenia ostrzeżenia
                result => result.Length == 0,
                TimeSpan.FromSeconds(10),
                TimeSpan.FromMilliseconds(500)
            );
        }


        public void Dispose()
        {
            _automation.Dispose();
            _app.Close();
        }
    }
}
