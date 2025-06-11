using Purofessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.UnitTests.Models
{
    public class ServerStatusResponseTests
    {
        [Fact]
        public void ServerStatusResponse_CanStoreLocalesAndIncidents()
        {
            var response = new ServerStatusResponse
            {
                Id = "euw1",
                Name = "Europe West",
                Locales = new List<string> { "en_GB", "pl_PL" },
                Maintenances = new List<object>(),
                Incidents = new List<object> { new { issue = "Lag" } }
            };

            Assert.Equal("euw1", response.Id);
            Assert.Contains("pl_PL", response.Locales);
            Assert.Single(response.Incidents);
        }

    }
}
