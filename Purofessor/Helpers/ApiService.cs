using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Purofessor.Models;
public class ApiService
{
    private readonly HttpClient _client;
    public string AuthToken { get; private set; }
    public ApiService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost/api/");
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "TWÓJ_TOKEN"); jeśli chcemy "zapamiętaj mnie"
    }

    public async Task<User> GetUserAsync(int id)
    {
        var response = await _client.GetAsync($"users/{id}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        throw new HttpRequestException($"API zwróciło: {response.StatusCode}");
    }
    public async Task<string> LoginAsync(string email, string password)
    {
        var payload = new
        {
            email = email,
            password = password
        };

        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("login", content);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(json);
            string token = doc.RootElement.GetProperty("token").GetString();

            // Zapamiętujemy token
            AuthToken = token;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return token;
        }

        throw new Exception("Nie udało się zalogować. Sprawdź dane.");
    }

    public async Task<bool> RegisterAsync(string login, string password, string email)
    {
        var payload = new
        {
            name = login,
            email = email,
            password = password,
            password_confirmation = password
        };

        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("users", content);
        return response.IsSuccessStatusCode;
    }
}
