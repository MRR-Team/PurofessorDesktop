using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Purofessor.Models;
using Purofessor.UnitTests.Helpers;

namespace Purofessor.UnitTests.Services
{
    public class StatsTests : ServiceTestBase
    {
        [Fact]
        public async Task GetChampionSearchStatsAsync_ReturnsStatsWithCapitalizedNames()
        {
            var json =
                JsonSerializer.Serialize(new[]
            {
            new ChampionSearchStats
            {
                Total = 42,
                Champion = new Champion { Name = "ahri" }
            }
            });

            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });

            var service = CreateTestApiService(handler);

            var stats = await service.Champions.GetChampionSearchStatsAsync();

            Assert.Single(stats);
            Assert.Equal("Ahri", stats[0].Champion.Name);
            Assert.Equal(42, stats[0].Total);
        }
    }
}