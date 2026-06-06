using System.Text.Json;

namespace API_DesignPattern.HelperClass
{
    public class StatusCodeMiddleware
    {
        private readonly RequestDelegate _next;

        public StatusCodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context); // 👈 let request execute first

            if (context.Response.HasStarted) return;


            if (context.Response.StatusCode == 404 &&
                !context.Request.Path.StartsWithSegments("/api"))
            {
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    status = 404,
                    message = "Resource not found",
                    traceId = context.TraceIdentifier
                });

                //await context.Response.WriteAsync(result);

                //context.Response.Redirect("/api/Home/Error");
                context.Response.Redirect("/Home/Error");

            }
        }
    }
}
