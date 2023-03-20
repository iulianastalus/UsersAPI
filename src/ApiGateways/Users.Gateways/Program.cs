using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging((ctx, loggingbuilder) =>
{
    loggingbuilder.AddConfiguration(ctx.Configuration.GetSection("Logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
}).ConfigureAppConfiguration((ctx,cfg) =>
{
    cfg.AddJsonFile($"gatewayconfig.{ctx.HostingEnvironment.EnvironmentName}.json",true,true);
});
builder.Services.AddOcelot();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseOcelot().Wait();

app.Run();
