using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Purofessor.Helpers
{
    internal class GoogleAuthListener
    {
        private readonly string _baseUrl;
        private const string RedirectUrl = "http://localhost:45678/oauth-success/";

        public GoogleAuthListener(string baseUrl)
        {
            _baseUrl = baseUrl.TrimEnd('/');
        }

        public async Task<string> StartLoginFlowAsync()
        {
            string loginUrl = $"{_baseUrl}/auth/redirect/google?redirect_uri={HttpUtility.UrlEncode(RedirectUrl)}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = loginUrl,
                UseShellExecute = true
            });

            return await ListenForTokenAsync();
        }

        private async Task<string> ListenForTokenAsync()
        {
            using var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:45678/"); listener.Start();

            var context = await listener.GetContextAsync();
            string token = context.Request.QueryString["token"];

            string responseHtml = "<html><body><h2>Logowanie zakończone. Możesz zamknąć tę stronę.</h2></body></html>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseHtml);
            context.Response.ContentLength64 = buffer.Length;
            await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();

            return token;
        }
    }
}
