using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.EF.Data;

namespace FavoDeMel.Infrastructure.EF.Repositories
{
    public class TesteRepository : Repository<ComandaSituacao>, ITesteRepository
    {
        public TesteRepository (AppDataContext dataContext):base(dataContext)
        {

        }
    }
}
