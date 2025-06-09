using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Purofessor.Models;
using System.Windows;

namespace Purofessor.Helpers
{
    internal class UserApi
    {
        private readonly ApiService _api;

        public UserApi(ApiService api)
        {
            _api = api;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync("users");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);

                    var usersElement = doc.RootElement.GetProperty("data").GetRawText();

                    return JsonSerializer.Deserialize<List<User>>(usersElement, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }

                throw new Exception($"Nie udało się pobrać użytkowników: {response.StatusCode}");
            });
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync($"users/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }

                throw new Exception($"API zwróciło: {response.StatusCode}");
            });
        }

        public async Task<bool> UpdateUserAsync(int id, string name = null, string email = null, string password = null)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var payload = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(name)) payload["name"] = name;
                if (!string.IsNullOrWhiteSpace(email)) payload["email"] = email;
                if (!string.IsNullOrWhiteSpace(password))
                {
                    payload["password"] = password;
                    payload["password_confirmation"] = password;
                }

                if (payload.Count == 0)
                    throw new Exception("Nie podano żadnych danych do aktualizacji.");

                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                var response = await _api.Client.PutAsync($"users/{id}", content);

                if (response.IsSuccessStatusCode)
                    return true;

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Nie udało się zaktualizować użytkownika: {response.StatusCode}\n{error}");
            });
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.DeleteAsync($"users/{userId}");

                if (response.IsSuccessStatusCode)
                    return true;

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Nie udało się usunąć użytkownika: {response.StatusCode}\n{error}");
            });
        }
        public async Task<List<ActivityLog>> GetLogsAsync()
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync("stats/logs");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    var logsJson = doc.RootElement.GetProperty("data").GetRawText();

                    return JsonSerializer.Deserialize<List<ActivityLog>>(logsJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }

                throw new Exception($"Nie udało się pobrać logów: {response.StatusCode}");
            });
        }
    }

}
