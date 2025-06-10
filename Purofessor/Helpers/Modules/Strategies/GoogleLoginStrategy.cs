using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Purofessor.Models;
using Purofessor.Properties;
using Purofessor.Views.Windows.Dialogs;

namespace Purofessor.Helpers.Modules.Strategies
{
    internal class GoogleLoginStrategy : ILoginStrategy
    {
        private readonly ApiService _api;

        public GoogleLoginStrategy(ApiService api)
        {
            _api = api;
        }

        public async Task<string?> LoginAsync()
        {
            var listener = new GoogleAuthListener(Settings.Default.ApiBaseUrl);
            string token = await listener.StartLoginFlowAsync();

            if (string.IsNullOrEmpty(token))
                throw new Exception("Nie udało się uzyskać tokenu Google.");

            _api.AuthToken = token;
            _api.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _api.Client.GetAsync("users/me");
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                string message = "Nie udało się pobrać danych użytkownika.";
                using var errorDoc = JsonDocument.Parse(json);
                if (errorDoc.RootElement.TryGetProperty("message", out var msgProp))
                    message = msgProp.GetString() ?? message;

                throw new Exception(message);
            }

            _api.LoggedUser = JsonSerializer.Deserialize<User>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return token;
        }
    }
}
