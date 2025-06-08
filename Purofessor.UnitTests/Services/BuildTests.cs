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

    public class BuildTests : ServiceTestBase
    {
        [Fact]
        public async Task GetBuildAsync_ReturnsCapitalizedItemNames()
        {
            var json = JsonSerializer.Serialize(new[]
            {
            new Item { Name = "liandrys torment" },
            new Item { Name = "void staff" }
        });

            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });

            var service = CreateTestApiService(handler);

            var items = await service.GetBuildAsync("ahri", "zed");

            Assert.Equal(new[] { "Liandrys torment", "Void staff" }, items);
        }
    }
}