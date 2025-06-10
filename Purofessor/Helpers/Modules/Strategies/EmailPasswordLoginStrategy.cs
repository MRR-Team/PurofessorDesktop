using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Purofessor.Models;

namespace Purofessor.Helpers.Modules.Strategies
{
    internal class EmailPasswordLoginStrategy : ILoginStrategy
    {
        private readonly ApiService _api;
        private readonly string _email;
        private readonly string _password;

        public EmailPasswordLoginStrategy(ApiService api, string email, string password)
        {
            _api = api;
            _email = email;
            _password = password;
        }

        public async Task<string?> LoginAsync()
        {
            var payload = new { email = _email, password = _password };
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await _api.Client.PostAsync("login", content);
            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                using var doc = JsonDocument.Parse(json);
                string? token = doc.RootElement.GetProperty("token").GetString();
                if (string.IsNullOrWhiteSpace(token))
                    throw new Exception("Nieprawidłowa odpowiedź serwera: token jest pusty.");

                var userElement = doc.RootElement.GetProperty("user").GetRawText();
                _api.LoggedUser = JsonSerializer.Deserialize<User>(userElement, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _api.AuthToken = token;
                _api.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return token;
            }

            string message = "Nie udało się zalogować.";
            using var errorDoc = JsonDocument.Parse(json);
            if (errorDoc.RootElement.TryGetProperty("message", out var msgProp))
                message = msgProp.GetString() ?? message;

            throw new Exception(message);
        }
    }
}
