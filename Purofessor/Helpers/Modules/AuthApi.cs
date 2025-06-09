using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Purofessor.Models;
using Purofessor.Properties;
using Purofessor.Helpers;
using System.Windows;
using Purofessor.Views.Windows.Dialogs;

namespace Purofessor.Helpers
{
    internal class AuthApi
    {
        private readonly ApiService _api;

        public AuthApi(ApiService api)
        {
            _api = api;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var payload = new { email, password };
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
            });
        }



        public async Task<bool> RegisterAsync(string login, string password, string email)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var payload = new
                {
                    name = login,
                    email,
                    password,
                    password_confirmation = password
                };

                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                var response = await _api.Client.PostAsync("register", content);

                return response.IsSuccessStatusCode;
            });
        }

        public async Task LogoutAsync()
        {
            await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                if (string.IsNullOrEmpty(_api.AuthToken))
                    throw new InvalidOperationException("Brak tokenu autoryzacyjnego.");

                var request = new HttpRequestMessage(HttpMethod.Post, "logout");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _api.AuthToken);

                var response = await _api.Client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Wylogowanie nie powiodło się: {response.StatusCode}");

                _api.AuthToken = null;
                _api.LoggedUser = null;
                _api.Client.DefaultRequestHeaders.Authorization = null;
            });
        }

        public async Task<string?> LoginWithGoogleAsync()
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
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
            });
        }



    }
}
