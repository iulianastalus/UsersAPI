﻿

using EventBus.Messages.Events;
using EventBus.Messages.Events.Interfaces;
using MassTransit;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace EventBus.Messages;
public class EventProducer :IEventProducer
{
    private readonly ProducerConfig _config;
    private readonly IPublishEndpoint _publishEndPoint;

    public EventProducer(IOptions<ProducerConfig> config, IPublishEndpoint publishEndPoint)
    {
        _config = config.Value;
        _publishEndPoint = publishEndPoint;
    }

    public async Task ProduceAsync<T>(T @event) where T : IntegrationBaseEvent
    {
        await _publishEndPoint.Publish<UserCreatedEvent>(@event);       
    }
}

