using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Purofessor.Models;
using Purofessor.Properties;
using Purofessor.Helpers;
using Purofessor.Views.Windows.Dialogs;
using Purofessor.Helpers.Modules.Strategies; // Dodane

namespace Purofessor.Helpers
{
    internal class AuthApi
    {
        private readonly ApiService _api;

        public AuthApi(ApiService api)
        {
            _api = api;
        }

        public async Task<string?> LoginAsync(ILoginStrategy strategy)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(() => strategy.LoginAsync());
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
        public async Task SendResetLinkAsync(string email)
        {
            await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var payload = new { email };
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                var response = await _api.Client.PostAsync("forgot-password", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Błąd wysyłania linku resetującego: {response.StatusCode}\n{error}");
                }
            });
        }
    }
}
