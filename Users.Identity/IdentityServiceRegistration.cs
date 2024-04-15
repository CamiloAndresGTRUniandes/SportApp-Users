using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Users.Aplication.Contracts.Identity;
using Users.Aplication.Models.Identity;
using Users.Identity.Services;
using Users.Identity.Models;

namespace Users.Identity
{
    public static class IdentityServiceRegistration
    {

        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration  )
        {

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<CleanArquitectureIdentityDbContext>(options=>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"),
                b=> b.MigrationsAssembly(typeof(CleanArquitectureIdentityDbContext).Assembly.FullName)  
                )
            );

            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<CleanArquitectureIdentityDbContext>()
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
            
            ;

            return services;
        }
    }
}
