
using EventBus.Messages;
using EventBus.Messages.Events.Interfaces;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Configuration;
using System.Reflection;
using Users.ApplicationCore.Commands;
using Users.ApplicationCore.Domain;
using Users.ApplicationCore.Interfaces;
using Users.ApplicationCore.Mappers;
using Users.ApplicationCore.ValueObjects;
using Users.Infrastructure.Data;
using Users.Infrastructure.Handlers;
using Users.Infrastructure.Interfaces;
using Users.Infrastructure.Models;
using Users.Infrastructure.Stores;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Users.API.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCommonServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAutoMapper(typeof(ApplicationProfile).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateUserHandler))));
            services.AddScoped(typeof(IEventSourcingHandler<UserAggregate>), typeof(EventSourcingHandler));
            services.AddMassTransit(cfg=> cfg.UsingRabbitMq((ctx,cfg) =>
            {
                //cfg.Host(configuration.GetSection(nameof(RabbitConfig)).GetSection("ConnectionString").Value);
                cfg.Host(new Uri("amqp://guest:guest@rabbitmq:5672/"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

            }));
            services.Configure<MassTransitHostOptions>(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(30);
                options.StopTimeout = TimeSpan.FromMinutes(1);
            });
        }

        public static void RegisterDbConnection(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(services =>
            {
                var mongoSettings = services.GetRequiredService<IOptions<DbSettings>>();
                return new MongoClient(mongoSettings.Value.ConnectionString);
            });
        }

        public static void RegisterConfigurations(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<DbSettings>(configuration.GetSection(nameof(DbSettings)));
        }



        public static void RegisterSpecificServices(this IServiceCollection services)
        {
            
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<IEventProducer, EventProducer>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IContext, UsersContext>();
            services.AddScoped<IEventStoreRepository<EventModel>, EventStoreRepository>();
        }
    }
}
