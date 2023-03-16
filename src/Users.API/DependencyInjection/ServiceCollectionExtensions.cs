
using EventBus.Messages;
using EventBus.Messages.Events.Interfaces;
using MassTransit;
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
                cfg.Host(configuration.GetSection(nameof(RabbitConfig)).GetSection("ConnectionString").Value);
            }));
            services.Configure<MassTransitHostOptions>(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(30);
                options.StopTimeout = TimeSpan.FromMinutes(1);
            });
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
