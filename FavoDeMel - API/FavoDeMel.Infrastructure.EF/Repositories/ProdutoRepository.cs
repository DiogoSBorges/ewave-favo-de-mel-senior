using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.EF.Data;

namespace FavoDeMel.Infrastructure.EF.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDataContext dataContext) : base(dataContext)
        {

        }
    }
}
