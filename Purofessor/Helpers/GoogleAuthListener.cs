using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace Purofessor.Helpers
{
    internal class GoogleAuthListener
    {
        private readonly string _baseUrl;
        private const string RedirectUrl = "http://localhost:5005/callback/";

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
            listener.Prefixes.Add("http://localhost:5005/callback/");
            listener.Start();

            string? token = null;

            while (token == null)
            {
                var context = await listener.GetContextAsync();
                token = context.Request.QueryString["token"];

                string responseHtml;

                if (!string.IsNullOrEmpty(token))
                {
                    responseHtml = @"
                                    <html>
                                    <head>
                                        <meta charset='UTF-8'>
                                        <title>Logowanie zakończone</title>
                                        <style>
                                            body {
                                                background: linear-gradient(135deg, #0f2027, #203a43, #2c5364);
                                                font-family: 'Segoe UI', sans-serif;
                                                color: #fff;
                                                display: flex;
                                                justify-content: center;
                                                align-items: center;
                                                height: 100vh;
                                                margin: 0;
                                            }
                                            .container {
                                                background-color: rgba(255, 255, 255, 0.05);
                                                padding: 40px;
                                                border-radius: 12px;
                                                box-shadow: 0 4px 30px rgba(0, 0, 0, 0.3);
                                                text-align: center;
                                            }
                                            h2 {
                                                margin: 0 0 10px;
                                                font-size: 24px;
                                            }
                                            p {
                                                font-size: 16px;
                                                opacity: 0.85;
                                            }
                                        </style>
                                    </head>
                                    <body>
                                        <div class='container'>
                                            <h2>Logowanie zakończone</h2>
                                            <p>Możesz zamknąć tę stronę i wrócić do aplikacji.</p>
                                        </div>
                                    </body>
                                    </html>";
                }
                else
                {
                    responseHtml = "<html><body><h2>Oczekiwanie na zakończenie logowania...</h2></body></html>";
                }

                byte[] buffer = Encoding.UTF8.GetBytes(responseHtml);
                context.Response.ContentLength64 = buffer.Length;
                await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
            }

            listener.Stop();
            return token;
        }
    }
}
