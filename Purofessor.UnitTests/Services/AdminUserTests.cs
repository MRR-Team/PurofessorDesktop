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
    public class AdminUserTests : ServiceTestBase
    {
        [Fact]
        public async Task GetUsersAsync_ReturnsList()
        {
            var json = JsonSerializer.Serialize(new
            {
                data = new[]
                {
            new User { Id = 1, Name = "Admin", Email = "a@a.com" }
        }
            });

            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });

            var service = CreateTestApiService(handler);

            var users = await service.Users.GetUsersAsync();

            Assert.Single(users);
            Assert.Equal("Admin", users[0].Name);
        }


        [Fact]
        public async Task DeleteUserAsync_ValidId_ReturnsTrue()
        {
            var handler = new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK));

            var service = CreateTestApiService(handler);

            var result = await service.Users.DeleteUserAsync(99);

            Assert.True(result);
        }
    }
}