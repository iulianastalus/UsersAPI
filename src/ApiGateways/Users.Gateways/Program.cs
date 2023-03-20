var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging((ctx, loggingbuilder) =>
{
    loggingbuilder.AddConfiguration(ctx.Configuration.GetSection("Logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
