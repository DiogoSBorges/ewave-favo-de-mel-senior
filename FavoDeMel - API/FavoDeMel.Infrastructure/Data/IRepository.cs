using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavoDeMel.Infrastructure.Data
{
    public interface IRepository<T> where T : IEntity
    {      
        Task<T> GetByAsync(int id);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
