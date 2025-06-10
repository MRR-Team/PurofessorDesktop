using System.Windows;
using System.Windows.Controls;

namespace Purofessor.Helpers
{
    internal static class ActiveButtonHelper
    {
        private static readonly Thickness ActiveThickness = new(0, 0, 0, 3);   // highlighted
        private static readonly Thickness InactiveThickness = new(0, 0, 0, 2); // normal

        public static void SetActiveTab(Button? newActiveButton, ref Button? previousButton)
        {
            if (newActiveButton is null)
            {
                if (previousButton is not null)
                    previousButton.BorderThickness = InactiveThickness;

                return;
            }

            if (ReferenceEquals(previousButton, newActiveButton))
                return; // nothing to change

            if (previousButton is not null)
                previousButton.BorderThickness = InactiveThickness;

            newActiveButton.BorderThickness = ActiveThickness;
            previousButton = newActiveButton;
        }
    }
}