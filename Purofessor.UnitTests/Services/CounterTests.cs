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
    public class CounterTests : ServiceTestBase
    {
        [Fact]
        public async Task GetCounterAsync_ReturnsCapitalizedNames()
        {
            var json = JsonSerializer.Serialize(new[]
            {
                new Champion { Name = "ahri" },
                new Champion { Name = "zed" }
            });

            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });

            var service = CreateTestApiService(handler);

            var result = await service.GetCounterAsync("mid", "yasuo");

            Assert.Equal(new[] { "Ahri", "Zed" }, result);
        }
    }
}
