using System;
using System.Net.Http;
using Purofessor.Helpers;

namespace Purofessor.UnitTests.Helpers
{
    public abstract class ServiceTestBase
    {
        protected ApiService CreateTestApiService(HttpMessageHandler handler)
        {
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://fake.api") // Wymagane, żeby URI był absolutny
            };

            return new ApiService(client);
        }
    }
}
