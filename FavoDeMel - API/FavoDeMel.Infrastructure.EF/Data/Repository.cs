using FavoDeMel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavoDeMel.Infrastructure.EF.Data
{
    public abstract class Repository<T> : IRepository<T> where T : class
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
            throw new NotImplementedException();
        }

        public Task<T> GetByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
