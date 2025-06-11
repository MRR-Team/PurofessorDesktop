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
    public class CounterpickTests : IDisposable
    {
        private readonly Application _app;
        private readonly UIA3Automation _automation;

        public CounterpickTests()
        {
            var appPath = Path.GetFullPath(@"..\..\..\..\Purofessor\bin\Debug\net8.0-windows\Purofessor.exe");
            _app = Application.Launch(appPath);
            _automation = new UIA3Automation();
        }

        [Fact]
        public void GenerateCounter_ForValidChampion_ShowsResults()
        {
            var window = _app.GetMainWindow(_automation);

            // ------ logowanie ------
            var loginBox = window.FindFirstDescendant(cf => cf.ByAutomationId("LoginTextBox"))?.AsTextBox();
            var passwordBox = window.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox();
            var loginButton = window.FindFirstDescendant(cf => cf.ByAutomationId("LoginButton"))?.AsButton();

            Assert.NotNull(loginBox);
            Assert.NotNull(passwordBox);
            Assert.NotNull(loginButton);

            loginBox.Enter("admin@example.com");
            passwordBox.Enter("password");
            loginButton.Invoke();

            // Daj chwilę na załadowanie nowego okna
            Thread.Sleep(2000);

            var mainWindow = _app.GetAllTopLevelWindows(_automation)
                                 .FirstOrDefault(w => w.Title.Contains("Purofessor"));

            Assert.NotNull(mainWindow);

            // ------ Counterpick ------
            var champBox = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("EnemyChampTextBox"))?.AsTextBox();
            var midRadio = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("RadioMid"))?.AsRadioButton();
            var generateButton = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("GenerateCounterButton"))?.AsButton();

            Assert.NotNull(champBox);
            Assert.NotNull(midRadio);
            Assert.NotNull(generateButton);

            champBox.Enter("Ashe");
            midRadio.Patterns.SelectionItem.Pattern.Select();
            generateButton.Invoke();
            Thread.Sleep(2000);

            // ------ wyniki ------
            var resultsContainer = Retry.WhileNull(
                () => mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("CounterResultsItemsControl")),
                TimeSpan.FromSeconds(10)
            ).Result;

            Assert.NotNull(resultsContainer);

            var resultItems = resultsContainer.FindAllChildren();
            Assert.True(resultItems.Length > 0, "Oczekiwano co najmniej jednego kontrpicka.");
        }

        public void Dispose()
        {
            _automation.Dispose();
            _app.Close();
        }
    }
}
