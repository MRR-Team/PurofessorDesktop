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
    public class ChampionTests : ServiceTestBase
    {
        [Fact]
        public async Task GetChampionsAsync_ReturnsList()
        {
            var json = JsonSerializer.Serialize(new[]
            {
                new Champion { Name = "ahri" }, new Champion { Name = "teemo" }
            });

            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });

            var service = CreateTestApiService(handler); // <-- użycie helpera
            var result = await service.GetChampionsAsync();

            Assert.Equal(2, result.Count);
            Assert.Equal("Ahri", result[0].Name);
        }

        [Fact]
        public async Task ToggleChampionAvailabilityAsync_ValidId_ReturnsTrue()
        {
            var handler = new StubHttpMessageHandler(req =>
            {
                Assert.Equal(HttpMethod.Patch, req.Method);
                return new HttpResponseMessage(HttpStatusCode.OK);
            });

            var service = CreateTestApiService(handler); // <-- użycie helpera
            var result = await service.ToggleChampionAvailabilityAsync(123);

            Assert.True(result);
        }
    }
}
