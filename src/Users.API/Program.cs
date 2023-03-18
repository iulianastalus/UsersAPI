

using System.Runtime.CompilerServices;
using Users.API.DependencyInjection;
using Users.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterConfigurations(builder.Configuration);
builder.Services.RegisterCommonServices(builder.Configuration);
builder.Services.RegisterSpecificServices();
builder.Services.RegisterDbConnection();
builder.Services.AddHostedService<MessageWorker>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
