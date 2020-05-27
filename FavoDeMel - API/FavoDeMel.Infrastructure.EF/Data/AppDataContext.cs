using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FavoDeMel.Infrastructure.EF.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
