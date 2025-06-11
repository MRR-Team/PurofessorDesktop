using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Purofessor.Models;
using Purofessor.Helpers;
using Purofessor.UnitTests.Helpers;
using Purofessor.Helpers.Modules.Strategies; // Dodaj to, jeśli jeszcze nie masz

namespace Purofessor.UnitTests.Services
{
    public class ApiServiceTests
    {
        [Fact]
        public async Task LoginAsync_ZwracaTokenIUstawiaUsera_GdySukces()
        {
            // arrange
            var expectedToken = "abc123";
            var fakeUser = new { id = 1, name = "Teemo", email = "teemo@lol.gg" };

            var handler = new StubHttpMessageHandler(req =>
            {
                var json = JsonSerializer.Serialize(new { token = expectedToken, user = fakeUser });
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            });

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://fakeapi.test/")
            };

            var api = new ApiService(client);

            // 🔧 Zamiast api.Auth.LoginAsync(...)
            var loginStrategy = new EmailPasswordLoginStrategy(api, "teemo@lol.gg", "123");
            var token = await loginStrategy.LoginAsync();

            // assert
            Assert.Equal(expectedToken, token);
            Assert.NotNull(api.LoggedUser);
            Assert.Equal("Teemo", api.LoggedUser.Name);
        }
    }
}
