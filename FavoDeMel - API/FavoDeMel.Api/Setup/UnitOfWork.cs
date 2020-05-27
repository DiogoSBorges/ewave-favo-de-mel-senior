using FavoDeMel.Infrastructure.Data;
using FavoDeMel.Infrastructure.EF.Data;
using System;
using System.Threading.Tasks;

namespace FavoDeMel.Api.Setup
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext DataContext;

        public UnitOfWork(AppDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task CommitAsync()
        {
            try
            {                
                await DataContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DataContext.Dispose();
            }
        }
    }
}
