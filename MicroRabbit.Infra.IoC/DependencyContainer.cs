namespace MicroRabbit.Infra.IoC;

using Bus;
using MicroRabbit.Domain.Core.Bus;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

public static class DependencyContainer
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {

        //MediatR Mediator
        services.AddMediatR(Assembly.GetExecutingAssembly());

        //Domain Bus
        services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
        {
            var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            var optionsFactory = sp.GetService<IOptions<RabbitMQSettings>>();
            return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
        });


        return services;
    }
}
