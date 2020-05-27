using FavoDeMel.Infrastructure.Data;
using FavoDeMel.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.Infrastructure.EF.Data
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected AppDataContext DataContext { get; }

        protected Repository(AppDataContext context)
        {
            DataContext = context;
        }

        public async Task AddAsync(T entity)
        {
            await DataContext.Set<T>().AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            DataContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> GetByAsync(int id)
        {
            var entity = DataContext.Set<T>().Local.SingleOrDefault(x => x.Id == id);

            if (entity.IsNull())
            {
                entity = await DataContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            }

            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            DataContext.Entry<T>(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
