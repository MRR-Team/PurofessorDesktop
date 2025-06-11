using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Purofessor.UnitTests.Helpers;
using Purofessor.Helpers;
using Purofessor.Models;
using System.Collections.Generic;

namespace Purofessor.UnitTests.Services
{
    public class UserApiLogsTests : ServiceTestBase
    {
        [Fact]
        public async Task GetLogsAsync_ReturnsList()
        {
            // Arrange
            var logList = new List<ActivityLog>
            {
                new ActivityLog
                {
                    Id = 1,
                    Description = "Log entry",
                    CreatedAt = "2025-06-10T12:00:00Z"
                }
            };

            var json = JsonSerializer.Serialize(new { data = logList });

            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });

            var apiService = CreateTestApiService(handler);
            var userApi = new UserApi(apiService);

            // Act
            var result = await userApi.GetLogsAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal("Log entry", result[0].Description);
        }
    }
}
