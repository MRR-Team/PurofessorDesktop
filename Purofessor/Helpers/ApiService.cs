using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Purofessor.Models;
using Purofessor.Properties;

namespace Purofessor.Helpers
{
    public class ApiService : ObservableObject
    {
        private static readonly ApiService _instance = new ApiService();
        public static ApiService Instance => _instance;

        internal AuthApi Auth { get; }
        internal ChampionApi Champions { get; }
        internal UserApi Users { get; }

        internal HttpClient Client { get; }
        public string? AuthToken { get; internal set; } = string.Empty;

        private User? _loggedUser;
        public User? LoggedUser
        {
            get => _loggedUser;
            set => SetField(ref _loggedUser, value);
        }

        private ApiService()
        {
            Client = new HttpClient { BaseAddress = new Uri(Settings.Default.ApiBaseUrl) };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Auth = new AuthApi(this);
            Champions = new ChampionApi(this);
            Users = new UserApi(this);
        }
        internal ApiService(HttpClient httpClient)
        {
            Client = httpClient;
            Client.BaseAddress ??= new Uri("https://localhost/api/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Auth = new AuthApi(this);
            Champions = new ChampionApi(this);
            Users = new UserApi(this);
        }
    }
}
