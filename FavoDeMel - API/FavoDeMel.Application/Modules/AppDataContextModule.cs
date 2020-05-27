using FavoDeMel.Infrastructure.EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FavoDeMel.Application.Modules
{
   public static class AppDataContextModule
    {
        public static void ContextModuleRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("FavoDeMel");

            services.AddDbContext<AppDataContext>(opt => {
                opt
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
            });
           
             services.AddScoped<AppDataContext>();
        }
    }
}
