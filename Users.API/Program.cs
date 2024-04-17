using MicroRabbit.Infra.Bus;
using Microsoft.EntityFrameworkCore;
using Users.API.Middleware;
using Users.Aplication;
using Users.Infraestructure;
using Users.Infraestructure.Persistence;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Domain.Core.Bus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddApplicationServices();
    builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
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
