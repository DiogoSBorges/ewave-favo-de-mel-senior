
using FavoDeMel.Application.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FavoDeMel.Application.Modules
{
    public static class CommandQueryModule
    {
        public static void CommandQueryModuleRegister(this IServiceCollection services, Type handlerInterface)
        {
            var handlers = typeof(FooCommand).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
            );

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }
            
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        }
    }
}
