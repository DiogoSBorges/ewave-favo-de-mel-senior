using FavoDeMel.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FavoDeMel.Application.Modules
{
    public static class QueryModule
    {
        public static void QueryModuleRegister(this IServiceCollection services)
        {
            var queries = typeof(FooQuery).Assembly.GetTypes()
             .Where(t => t.Name.EndsWith("Query") && !t.Name.Equals("FooQuery") && !t.Name.Equals("BaseQuery"));

            foreach (var query in queries)
            {
                services.AddScoped(query.GetInterfaces()[0], query);
            }
        }
    }
}
