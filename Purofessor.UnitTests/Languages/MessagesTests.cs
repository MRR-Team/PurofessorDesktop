using Purofessor.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Purofessor.UnitTests.Languages
{
    public class MessagesTests
    {
        public MessagesTests()
        {
            // Mock zasobów
            Messages.ResourceLookup = key =>
            {
                return key switch
                {
                    "Error" => "Błąd",
                    _ => null
                };
            };
        }

        [Fact]
        public void Error_ReturnsLocalizedString_WhenExists()
        {
            var result = Messages.Error;
            Assert.Equal("Błąd", result);
        }

        [Fact]
        public void Get_ReturnsKeyInBrackets_WhenResourceMissing()
        {
            Messages.ResourceLookup = key => null;

            var method = typeof(Messages).GetMethod("Get", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var result = method.Invoke(null, new object[] { "MissingKey" }) as string;

            Assert.Equal("[MissingKey]", result);
        }
    }

}
