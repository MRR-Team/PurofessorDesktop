using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace Purofessor.Helpers
{
    public class ChampionAutocompleteHelper
    {
        private List<Champion> _champions = new();

        public void SetChampionList(List<Champion> champions)
        {
            _champions = champions ?? new List<Champion>();
        }

        public void Attach(TextBox textBox, Popup popup, ListBox listBox)
        {
            textBox.TextChanged += (s, e) =>
            {
                string typedText = textBox.Text.ToLowerInvariant();

                if (string.IsNullOrWhiteSpace(typedText))
                {
                    popup.IsOpen = false;
                    return;
                }

                var filtered = _champions
                    .Where(c => c.Name.ToLowerInvariant().Contains(typedText))
                    .Select(c => char.ToUpper(c.Name[0]) + c.Name[1..])
                    .ToList();

                listBox.ItemsSource = filtered;
                popup.IsOpen = filtered.Any();
            };

            listBox.MouseLeftButtonUp += (s, e) =>
            {
                if (listBox.SelectedItem is string selectedName)
                {
                    textBox.Text = selectedName;
                    popup.IsOpen = false;
                }
            };
        }
    }
}
