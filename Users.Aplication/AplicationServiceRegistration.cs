namespace Users.Aplication ;
using System.Reflection;
using Application.EventHandlers;
using Application.Events;
using Behavious;
using Contracts.Aplications;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services.Domain.Core.Bus;
using Util;

    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IUtils, Utils>();
            services.AddTransient<IEventHandler<PlanEnrolledEvent>, PlanEnrolledEventHandler>();
            services.AddTransient<PlanEnrolledEventHandler>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));
            return services;
        }
    }
