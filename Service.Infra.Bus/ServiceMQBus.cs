namespace Service.Infra.Bus ;
using System.Text;
using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services.Domain.Core.Bus;
using Services.Domain.Core.Commands;
using Services.Domain.Core.Events;

    public class ServiceMQBus : IEventBus
    {
        private readonly List<Type> _eventTypes;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly IMediator _mediator;
        private readonly Dictionary<string, string> _queuesClass;
        private readonly ServiceMqSettings _serviceMqSettings;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public ServiceMQBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory, IOptions<ServiceMqSettings> serviceMqSettings)
        {
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
            _queuesClass = new Dictionary<string, string>();
            _serviceMqSettings = serviceMqSettings.Value;
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

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Subscribe<T, TH>(string queue)
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);
            _queuesClass.Add(queue, eventName);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException($"El handler exception {handlerType.Name} ya fue registrado anteriormente por '{eventName}'",
                    nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>(queue);
        }

        private async void StartBasicConsume<T>(string queue) where T : Event
        {
            var client = new ServiceBusClient(_serviceMqSettings.Endpoint);
            var processor = client.CreateProcessor(queue);


            var successFullConecction = false;
            var counterRetries = 0;
            var exServiceBus = string.Empty;

            try
            {
                processor.ProcessMessageAsync += Consumer_Received;

                // add handler to process any errors
                processor.ProcessErrorAsync += ErrorHandler;

                // start processing 
                await processor.StartProcessingAsync();
                /*
                var connection = factory.CreateConnection();
                successFullConecction = true;
                var channel = connection.CreateModel();

                var eventName = typeof(T).Name;

                channel.QueueDeclare(eventName, false, false, false, null);

                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.Received += Consumer_Received;

                channel.BasicConsume(eventName, true, consumer);
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Retry=> {counterRetries}");
                Thread.Sleep(2000);
                counterRetries++;
                exServiceBus = ex.Message;
            }
        }

        private async Task Consumer_Received(ProcessMessageEventArgs args)
        {
            var queue = args.EntityPath;

            var eventName = _queuesClass[queue];
            var message = Encoding.UTF8.GetString(args.Message.Body);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            {
            }
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptions = _handlers[eventName];


                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription); //Activator.CreateInstance(subscription);
                        if (handler == null)
                        {
                            continue;
                        }
                        var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                        var @event = JsonConvert.DeserializeObject(message, eventType);
                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new[] { @event });
                    }
                }
            }
        }
    }
