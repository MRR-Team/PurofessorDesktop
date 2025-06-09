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
    public class RotationTests : ServiceTestBase
    {
        [Fact]
        public async Task GetFreeRotationAsync_ReturnsChampions()
        {
            var json = JsonSerializer.Serialize(new[]
            {
                new Champion { Name = "annie" },
                new Champion { Name = "garen" }
            });

            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });

            var service = CreateTestApiService(handler);

            // ✅ Zmieniamy dostęp do metody na przez podserwis Champions
            var rotation = await service.Champions.GetFreeRotationAsync();

            Assert.Equal(2, rotation.Count);
            Assert.Equal("Annie", rotation[0].Name);
        }
    }
}
