﻿namespace Users.Infraestructure ;
using System.Text;
using Aplication.Contracts.Identity;
using Aplication.Contracts.Infraestructure;
using Aplication.Contracts.Persistence;
using Aplication.Models;
using Aplication.Models.Identity;
using Dominio;
using Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Services;

    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));


            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<UsersDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UserConnectionString"),
                    b => b.MigrationsAssembly(typeof(UsersDbContext).Assembly.FullName)
                    )
                );

            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<UsersDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
                ).
                AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    }
                );


            return services;
        }
    }
