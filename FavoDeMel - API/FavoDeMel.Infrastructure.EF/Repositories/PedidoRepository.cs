using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.EF.Data;

namespace FavoDeMel.Infrastructure.EF.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDataContext dataContext) : base(dataContext)
        {

        }
    }
}
