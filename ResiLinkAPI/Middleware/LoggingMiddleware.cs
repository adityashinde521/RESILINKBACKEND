using log4net;

namespace ResiLinkAPI.Middleware
{

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog _logger;

        public LoggingMiddleware(RequestDelegate next, ILog logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Error($"An unhandled exception occurred: {ex}");

                // Optionally, you can re-throw the exception to propagate it further
                // throw;
            }
        }
    }
}
