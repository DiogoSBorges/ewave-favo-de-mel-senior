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
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Favo De Mel - API", Version = "v1" });

               
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
               
            });

            services.AddSignalR();
            services.AddOptions();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.Configure<DBProvider>(dbProvider => dbProvider.FavoDeMel = Configuration.GetConnectionString("FavoDeMel"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.ContextModuleRegister(Configuration);
            services.CommandModuleRegister();
            services.RepositoryModuleRegister();    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
                endpoint.MapHub<FavoDeMelHub>("/favodemelhub");
            });
        }
    }
}
