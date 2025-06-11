using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Purofessor.Models;
using Purofessor.UnitTests.Helpers;
using Purofessor.Helpers;

namespace Purofessor.UnitTests.Services
{
    public class LogoutTests : ServiceTestBase
    {
        [Fact]
        public async Task LogoutAsync_ClearsUserAndToken()
        {
            var handler = new StubHttpMessageHandler(req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.NotNull(req.Headers.Authorization);
                Assert.Equal("Bearer test-token", req.Headers.Authorization.ToString());

                return new HttpResponseMessage(HttpStatusCode.OK);
            });

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://fake.api")
            };

            // ✅ Konstrukcja ApiService z podserwisami
            var service = new ApiService(client)
            {
                LoggedUser = new User { Name = "Test" },
                AuthToken = "test-token"
            };

            // ✅ Użycie Auth.LogoutAsync
            await service.Auth.LogoutAsync();

            Assert.Null(service.LoggedUser);
            Assert.Null(service.AuthToken);
        }
    }
}
