using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using WebApiServerConsole.Services;

namespace WebApiServerConsole.Middleware
{
    public class RequestLoggingMiddleware: OwinMiddleware
    {
        private readonly ILoggerService _logger;

        public RequestLoggingMiddleware(OwinMiddleware next, ILoggerService logger) : base(next)
        {
            _logger = logger;
        }

        public override async Task Invoke(IOwinContext context)
        {
            await Measure(context).ConfigureAwait(false); ;
        }

        private async Task Measure(IOwinContext context)
        {
            var watch = Stopwatch.StartNew();
            await Next.Invoke(context).ConfigureAwait(false);
            watch.Stop();
            _logger.Info($"Request: {context.Request.Uri.PathAndQuery},   Duration: {watch.ElapsedMilliseconds} ms");
        }
    }
}