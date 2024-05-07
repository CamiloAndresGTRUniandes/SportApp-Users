using Microsoft.EntityFrameworkCore;
using Service.Infra.Bus;
using ServiceBus.Infra.IoC;
using Services.Domain.Core.Bus;
using Users.API.Middleware;
using Users.Aplication;
using Users.Application.EventHandlers;
using Users.Application.Events;
using Users.Infraestructure;
using Users.Infraestructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddApplicationServices();
    builder.Services.Configure<ServiceMqSettings>(builder.Configuration.GetSection("ServiceMqSettings"));
    builder.Services.RegisterServices(builder.Configuration);

    builder.Services.AddCors(
        options =>
        {
            options.AddPolicy
                (
                    "CorsPolicy",
                    builder =>
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod().
                            AllowAnyHeader()
                );
        }
        );


    var app = builder.Build();

    var eventBus = app.Services.GetRequiredService<IEventBus>();
    eventBus.Subscribe<PlanEnrolledEvent, PlanEnrolledEventHandler>("sportapp.users.planenrolled");

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseMiddleware<ExceptionMiddleware>();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseCors("CorsPolicy");
    app.MapControllers();
    ApplyMigration();
    app.Run();

    void ApplyMigration()
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
        if (db.Database.GetPendingMigrations().Any())
        {
            db.Database.Migrate();
        }
    }
