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
    public class UserTests : ServiceTestBase
    {
        [Fact]
        public async Task GetUserAsync_ValidId_ReturnsUser()
        {
            var expectedUser = new User { Id = 1, Name = "Test", Email = "test@test.com" };
            var json = JsonSerializer.Serialize(expectedUser);

            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });

            var service = CreateTestApiService(handler);

            // ✅ Przeniesione do podserwisu Users
            var result = await service.Users.GetUserAsync(1);

            Assert.NotNull(result);
            Assert.Equal(expectedUser.Name, result.Name);
        }

        [Fact]
        public async Task UpdateUserAsync_WithNameOnly_Succeeds()
        {
            var handler = new StubHttpMessageHandler(async req =>
            {
                var body = await req.Content!.ReadAsStringAsync();
                Assert.Contains("name", body);
                Assert.Contains("new name", body);
                return new HttpResponseMessage(HttpStatusCode.OK);
            });

            var service = CreateTestApiService(handler);

            // ✅ Przeniesione do podserwisu Users
            var result = await service.Users.UpdateUserAsync(1, name: "new name");

            Assert.True(result);
        }

        [Fact]
        public async Task RegisterAsync_ValidData_ReturnsTrue()
        {
            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK));

            var service = CreateTestApiService(handler);

            // ✅ Przeniesione do podserwisu Auth
            var result = await service.Auth.RegisterAsync("Tester", "pass123", "email@test.com");

            Assert.True(result);
        }
    }
}
