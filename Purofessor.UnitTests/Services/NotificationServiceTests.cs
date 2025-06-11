using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Purofessor.UnitTests.Helpers;
using Purofessor.Helpers;

namespace Purofessor.UnitTests.Services
{
    public class UserApiNotificationTests : ServiceTestBase
    {
        [Fact]
        public async Task SendNotificationAsync_ValidData_ReturnsTrue()
        {
            // Arrange
            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)); // symulacja udanej odpowiedzi

            var apiService = CreateTestApiService(handler);
            var userApi = new UserApi(apiService);

            // Act
            var result = await userApi.SendNotificationAsync("Test title", "Test body", "info");

            // Assert
            Assert.True(result);
        }
    }
}
