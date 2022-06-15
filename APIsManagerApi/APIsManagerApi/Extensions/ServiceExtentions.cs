using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace APIsManagerApi.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["sqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureCors(this IServiceCollection services)
       {
           services.AddCors(options =>
           {
               options.AddPolicy("EnableCORS", builder =>
               {
                   builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
               });
           });
       }

        public static void AddAuthenticationOption(this IServiceCollection service)
        {
            service.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:5001/",
                        ValidAudience = "https://localhost:5001/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                    };
                });
          }


    }

}
