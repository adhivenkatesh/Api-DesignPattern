using API_DesignPattern.HelperClass;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseMiddleware<StatusCodeMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.UseExceptionHandler(options =>
//{
//    options.Run(async context =>
//    {
//        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
//        context.Response.ContentType = "application/json";

//        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
//        if (exceptionFeature is not null)
//        {
//            var error = new { message = "An unexpected error occurred" };
//            await context.Response.WriteAsJsonAsync(error);
//        }
//    });
//});

//app.UseExceptionHandler(exceptionHandlerApp
//    => exceptionHandlerApp.Run(async context
//        => await Results.Problem()
//                     .ExecuteAsync(context)));

//app.MapGet("/exception", () =>
//{
//    //throw new Exception("Sample Exception");

//});

//app.MapGet("/", () => "Test by calling /exception");

//app.Use(async (context, next) =>
//{
//    await next();
//    var statuscode =context.Response.StatusCode;

//    if (context.Response.StatusCode == 404)
//    {
//        //context.Response.Redirect("/Home/Error");
//        context.Response.WriteAsync("Page Not found").ToString();
//        return;
//    } ;
//});

app.UseExceptionHandler("/Home/Error");



app.Run();
