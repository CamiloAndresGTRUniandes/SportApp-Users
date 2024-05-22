namespace ServiceBus.Infra.IoC ;

using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Service.Infra.Bus;
using Services.Domain.Core.Bus;

    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //MediatR Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Domain Bus
            services.AddSingleton<IEventBus, ServiceMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<ServiceMqSettings>>();
                return new ServiceMQBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
            });


            return services;
        }
    }
