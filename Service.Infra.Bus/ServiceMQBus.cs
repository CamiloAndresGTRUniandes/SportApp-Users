namespace Service.Infra.Bus ;


using System.Text;
using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services.Domain.Core.Bus;
using Services.Domain.Core.Events;

    public class ServiceMQBus : IEventBus
    {
        private readonly List<Type> _eventTypes;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly IMediator _mediator;
        private readonly ServiceMqSettings _serviceMqSettings;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly List<string> mensajes;

        public ServiceMQBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory, IOptions<ServiceMqSettings> rabbitMQSettings)
        {
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
            _serviceMqSettings = rabbitMQSettings.Value;
        }

        public async Task<bool> Publish<T>(T @event) where T : Event
        {
            var client = new ServiceBusClient(_serviceMqSettings.Endpoint);
            var sender = client.CreateSender(@event.Queue);

            try
            {
                var messageSerialize = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(messageSerialize);
                var message = new ServiceBusMessage(body);
                await sender.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }


            return true;
        }
    }
