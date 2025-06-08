using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Purofessor.Models;
using Xunit;
using System.Text;
using System.Text.Json;
using Purofessor;
using Purofessor.Helpers;
using Purofessor.UnitTests.Helpers;


namespace Purofessor.UnitTests.Services
{
    public class LoginTests : ServiceTestBase
    {
        [Fact]
        public async Task LoginAsync_ValidCredentials_ReturnsTokenAndSetsUser()
        {
            // Arrange
            var expectedToken = "test-token";
            var expectedUser = new User { Id = 1, Name = "Test User", Email = "test@example.com" };

            var responseContent = JsonSerializer.Serialize(new
            {
                token = expectedToken,
                user = expectedUser
            });

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
                });

            var client = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://fakeapi.test/")
            };

            var service = new ApiService(client);

            // Act
            var token = await service.LoginAsync("test@example.com", "password");

            // Assert
            Assert.Equal(expectedToken, token);
            Assert.NotNull(service.LoggedUser);
            Assert.Equal(expectedUser.Name, service.LoggedUser.Name);
            Assert.Equal(expectedUser.Email, service.LoggedUser.Email);
        }

        [Fact]
        public async Task LoginAsync_InvalidCredentials_ThrowsExceptionWithMessage()
        {
            // Arrange
            var errorMessage = "Invalid credentials.";
            var responseContent = JsonSerializer.Serialize(new
            {
                message = errorMessage
            });

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
                });

            var client = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://fakeapi.test/")
            };

            var service = new ApiService(client);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => service.LoginAsync("wrong@example.com", "badpass"));
            Assert.Contains(errorMessage, exception.Message);
        }
    }
}
