

namespace NetCore_I2E_Sandip_poojara.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log request details
            _logger.LogInformation("Incoming Request: {method} {url} from {ip}",
                context.Request.Method,
                context.Request.Path,
                context.Connection.RemoteIpAddress);

            // Call the next middleware in the pipeline
            await _next(context);

            // Log response details
            _logger.LogInformation("Outgoing Response: {statusCode} for {method} {url}",
                context.Response.StatusCode,
                context.Request.Method,
                context.Request.Path);
        }
    }
        public static class RequestLoggingMiddlewareExtensions
        {
            public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<RequestLoggingMiddleware>();
            }
    }
}
