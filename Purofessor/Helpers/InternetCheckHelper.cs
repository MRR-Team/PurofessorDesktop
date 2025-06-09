using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Purofessor.Helpers
{
    public static class InternetCheckHelper
    {
        public static event Action InternetUnavailable;

        public static async Task<bool> IsInternetAvailableAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(3);
                using var response = await client.GetAsync("https://www.google.com");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public static async Task ExecuteIfOnlineAsync(Func<Task> action)
        {
            if (!await IsInternetAvailableAsync())
            {
                InternetUnavailable?.Invoke();
                throw new Exception("Brak połączenia z internetem.");
            }

            await action();
        }

        public static async Task<T> ExecuteIfOnlineAsync<T>(Func<Task<T>> action)
        {
            if (!await IsInternetAvailableAsync())
            {
                InternetUnavailable?.Invoke();
                throw new Exception("Brak połączenia z internetem.");
            }

            return await action();
        }
    }

}
