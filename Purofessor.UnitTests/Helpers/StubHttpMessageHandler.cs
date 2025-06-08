using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Purofessor.UnitTests.Helpers
{
    internal class StubHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _asyncHandler;

        public StubHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> syncHandler)
        {
            _asyncHandler = req => Task.FromResult(syncHandler(req));
        }

        public StubHttpMessageHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> asyncHandler)
        {
            _asyncHandler = asyncHandler;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _asyncHandler(request);
        }
    }
}
