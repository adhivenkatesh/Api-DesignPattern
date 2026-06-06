using System.Net;
using System.Text.Json;

namespace API_DesignPattern.HelperClass
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // 👈 passes context forward
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                if (!context.Response.HasStarted)
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var result = JsonSerializer.Serialize(new
                    {
                        status = 500,
                        message = "Internal Server Error",
                        traceId = context.TraceIdentifier
                    });

                    await context.Response.WriteAsync(result);
                }
            }
        }
    }
}
