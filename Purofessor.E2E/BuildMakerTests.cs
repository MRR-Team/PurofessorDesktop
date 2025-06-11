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
    public class BuildMakerTests : IDisposable
    {
        private readonly Application _app;
        private readonly UIA3Automation _automation;

        public BuildMakerTests()
        {
            var appPath = Path.GetFullPath(@"..\..\..\..\Purofessor\bin\Debug\net8.0-windows\Purofessor.exe");
            _app = Application.Launch(appPath);
            _automation = new UIA3Automation();
        }

        [Fact]
        public void GenerateBuild_ForTestChampion_ShowsResults()
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
                    return w != null && w.FindFirstDescendant(cf => cf.ByAutomationId("BuildMakerButton")) != null ? w : null;
                },
                TimeSpan.FromSeconds(10)
            ).Result;

            Assert.NotNull(mainWindow);

            // Kliknij przycisk "Generuj przedmioty"
            var buildMakerButton = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("BuildMakerButton"))?.AsButton();
            Assert.NotNull(buildMakerButton);
            buildMakerButton.Invoke();

            // Poczekaj na załadowanie strony BuildMaker
            Thread.Sleep(1500); // lub Retry na textboxy

            // Znajdź pola tekstowe do wprowadzenia championów
            var myChampTextBox = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("MyChampionTextBox"))?.AsTextBox();
            var enemyChampTextBox = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("EnemyChampionTextBox"))?.AsTextBox();
            Assert.NotNull(myChampTextBox);
            Assert.NotNull(enemyChampTextBox);

            myChampTextBox.Enter("Ashe");
            enemyChampTextBox.Enter("Ashe");
            // Kliknij przycisk generowania
            var generateButton = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("GenerateBuildButton"))?.AsButton();
            Assert.NotNull(generateButton);
            generateButton.Invoke();


            // Poczekaj na wygenerowanie wyników
            var resultsContainer = Retry.WhileNull(
                () => mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("BuildResultsItemsControl")),
                TimeSpan.FromSeconds(15)
            ).Result;

            Assert.NotNull(resultsContainer);

            var resultItems = resultsContainer.FindAllChildren();
            Assert.True(resultItems.Length > 0, "Oczekiwano przynajmniej jednego wygenerowanego przedmiotu.");
        }

        public void Dispose()
        {
            _automation.Dispose();
            _app.Close();
        }
    }
}
