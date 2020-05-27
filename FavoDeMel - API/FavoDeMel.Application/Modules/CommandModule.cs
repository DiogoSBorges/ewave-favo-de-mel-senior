
using FavoDeMel.Application.Commands;
using FavoDeMel.Commands;
using FavoDeMel.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;

using System.Linq;

namespace FavoDeMel.Application.Modules
{
    public static class CommandModule
    {
        public static void CommandModuleRegister(this IServiceCollection services)
        {
            var handlers = typeof(FooCommand).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>))
            );

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)), handler);
            }
            
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        }
    }
}
