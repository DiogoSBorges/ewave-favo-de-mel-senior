using FavoDeMel.Infrastructure.Data;
using FavoDeMel.Infrastructure.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FavoDeMel.Application.Modules
{
    public static class RepositoryModule
    {
        public static void RepositoryModuleRegister(this IServiceCollection services)
        {

            var repositories = typeof(FooRepository).Assembly.GetTypes()
             .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>) && !t.IsAbstract));

            foreach (var repository in repositories)
            {
                services.AddScoped(repository.GetInterfaces()[1], repository);
            }
        }
    }
}
