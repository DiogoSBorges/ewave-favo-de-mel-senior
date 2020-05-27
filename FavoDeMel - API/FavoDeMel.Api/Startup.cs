using FavoDeMel.Api.Hubs;
using FavoDeMel.Api.Setup;
using FavoDeMel.Application.Modules;
using FavoDeMel.Application.Providers;
using FavoDeMel.Domain.Commands;
using FavoDeMel.Infrastructure.Data;
using FavoDeMel.Infrastructure.EF.Data;
using FavoDeMel.Infrastructure.EF.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace FavoDeMel.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                
                 builder.SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());      
            });

            services.AddSignalR();
            services.AddOptions();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.Configure<DBProvider>(dbProvider => dbProvider.FavoDeMel = Configuration.GetConnectionString("FavoDeMel"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.ContextModuleRegister(Configuration);
            services.CommandModuleRegister();
                        

            var repositories = typeof(FooRepository).Assembly.GetTypes()
              .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>) && !t.IsAbstract));

            foreach (var repository in repositories)
            {
                services.AddScoped(repository.GetInterfaces()[1], repository);
            }


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");

            /*app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
            });*/

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
                endpoint.MapHub<FavoDeMelHub>("/favodemelhub");
            });
        }
    }
}
