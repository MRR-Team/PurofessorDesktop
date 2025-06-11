using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Purofessor.Models;
using Purofessor.Helpers;

namespace Purofessor.Helpers
{
    internal class ChampionApi
    {
        private readonly ApiService _api;

        public ChampionApi(ApiService api)
        {
            _api = api;
        }

        public async Task<List<Champion>> GetChampionsAsync()
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync("champions");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var champions = JsonSerializer.Deserialize<List<Champion>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Champion>();

                    foreach (var champ in champions)
                    {
                        champ.Name = StringHelper.CapitalizeFirstLetter(champ.Name);
                    }

                    return champions;
                }

                throw new Exception($"Nie udało się pobrać championów: {response.StatusCode}");
            });
        }

        public async Task<List<string>> GetCounterAsync(string role, string enemyChampion)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync($"counter/{role}/{enemyChampion}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var champions = JsonSerializer.Deserialize<List<Champion>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Champion>();

                    return champions.Select(i => StringHelper.CapitalizeFirstLetter(i.Name)).ToList();
                }

                throw new Exception($"Nie udało się pobrać kontr: {response.StatusCode}");
            });
        }

        public async Task<List<string>> GetBuildAsync(string enemyChampionId, string myChampionId)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync($"build/{enemyChampionId}/against/{myChampionId}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var items = JsonSerializer.Deserialize<List<Item>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Item>();

                    return items.Select(i => StringHelper.CapitalizeFirstLetter(i.Name)).ToList();
                }

                throw new Exception($"Nie udało się pobrać builda: {response.StatusCode}");
            });
        }

        public async Task<List<Champion>> GetFreeRotationAsync()
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync("available-champions");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var champions = JsonSerializer.Deserialize<List<Champion>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Champion>();

                    foreach (var champ in champions)
                    {
                        champ.Name = StringHelper.CapitalizeFirstLetter(champ.Name);
                    }

                    return champions;
                }

                throw new Exception($"Nie udało się pobrać rotacji: {response.StatusCode}");
            });
        }

        public async Task<bool> ToggleChampionAvailabilityAsync(int championId)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var request = new HttpRequestMessage(HttpMethod.Patch, $"champions/{championId}/toggle-availability")
                {
                    Content = new StringContent("", Encoding.UTF8, "application/json")
                };

                var response = await _api.Client.SendAsync(request);
                return response.IsSuccessStatusCode;
            });
        }

        public async Task<List<ChampionSearchStats>> GetChampionSearchStatsAsync()
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync("stats/counter-search");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var stats = JsonSerializer.Deserialize<List<ChampionSearchStats>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<ChampionSearchStats>();

                    foreach (var stat in stats)
                    {
                        if (!string.IsNullOrWhiteSpace(stat.Champion?.Name))
                            stat.Champion.Name = StringHelper.CapitalizeFirstLetter(stat.Champion.Name);
                    }

                    return stats;
                }

                throw new Exception($"Nie udało się pobrać statystyk wyszukiwania championów: {response.StatusCode}");
            });
        }
        public async Task<ServerStatusResponse> GetServerStatusAsync(string region)
        {
            return await InternetCheckHelper.ExecuteIfOnlineAsync(async () =>
            {
                var response = await _api.Client.GetAsync($"riot/status/{region}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var status = JsonSerializer.Deserialize<ServerStatusResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return status!;
                }

                throw new Exception($"Nie udało się pobrać statusu serwera: {response.StatusCode}");
            });
        }
    }
}