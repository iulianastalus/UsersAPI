using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging((ctx, loggingbuilder) =>
{
    loggingbuilder.AddConfiguration(ctx.Configuration.GetSection("Logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});
builder.Services.AddOcelot();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseOcelot();

app.Run();
