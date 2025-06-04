using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Purofessor.Models;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using MyItem = Purofessor.Models.Item;
public class ApiService
{
    MyItem item = new MyItem();
    public User LoggedUser { get; private set; }
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
            var userElement = doc.RootElement.GetProperty("user").GetRawText();

            // Deserializacja użytkownika
            LoggedUser = JsonSerializer.Deserialize<User>(userElement, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            AuthToken = token;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return token;
        }

        throw new Exception("Nie udało się zalogować. Sprawdź dane.");
    }
    public async Task<bool> UpdateUserAsync(int id, string name, string email, string password)
{
    var payload = new Dictionary<string, object>();

    // Tylko jeśli użytkownik wprowadził nowe wartości
    if (!string.IsNullOrWhiteSpace(name))
        payload["name"] = name;

    if (!string.IsNullOrWhiteSpace(email))
        payload["email"] = email;

    if (!string.IsNullOrWhiteSpace(password))
        payload["password"] = password;

    // Nie wysyłamy pustego payloadu!
    if (payload.Count == 0)
        throw new Exception("Nie podano żadnych danych do aktualizacji.");

    var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
    var response = await _client.PutAsync($"users/{id}", content);

    return response.IsSuccessStatusCode;
}

    public async Task LogoutAsync()
    {
        if (string.IsNullOrEmpty(AuthToken))
            throw new InvalidOperationException("Brak tokenu autoryzacyjnego.");

        var request = new HttpRequestMessage(HttpMethod.Post, "logout");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

        var response = await _client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Wylogowanie nie powiodło się: {response.StatusCode}");
        }

        // Wyczyść stan klienta
        AuthToken = null;
        LoggedUser = null;
        _client.DefaultRequestHeaders.Authorization = null;
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
    public async Task<List<string>> GetCounterAsync(string role, string enemyChampion)
    {
        var response = await _client.GetAsync($"counter/{role}/{enemyChampion}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            var champions = JsonSerializer.Deserialize<List<Champion>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return champions.Select(c => c.Name).ToList();
        }

        throw new Exception($"Nie udało się pobrać kontr: {response.StatusCode}");
    }
    public async Task<List<Champion>> GetChampionsAsync()
    {
        var response = await _client.GetAsync("champions");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            var champions = JsonSerializer.Deserialize<List<Champion>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return champions;
        }

        throw new Exception($"Nie udało się pobrać championów: {response.StatusCode}");
    }
    public async Task<List<string>> GetBuildAsync(string enemyChampionId, string myChampionId)
    {
        var response = await _client.GetAsync($"build/{enemyChampionId}/against/{myChampionId}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var items = JsonSerializer.Deserialize<List<MyItem>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return items.Select(i => i.Name).ToList();
        }

        throw new Exception($"Nie udało się pobrać builda: {response.StatusCode}");
    }
    public async Task<List<ChampionSearchStats>> GetChampionSearchStatsAsync()
    {
        var response = await _client.GetAsync("stats/counter-search");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            var stats = JsonSerializer.Deserialize<List<ChampionSearchStats>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return stats;
        }

        throw new Exception($"Nie udało się pobrać statystyk wyszukiwania championów: {response.StatusCode}");
    }

}
